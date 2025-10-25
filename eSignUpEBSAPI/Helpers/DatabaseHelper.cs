using eSignUpEBSAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Text.RegularExpressions; // Add this if not present

namespace eSignUpEBSAPI.Helpers
{
    public class DatabaseHelper
    {
        public static string GetConnectionString(string connectionName, IConfiguration configuration)
        {
            SettingsDatabase settingsDatabase = configuration.GetSection(connectionName).Get<SettingsDatabase>() ?? new SettingsDatabase();

            var conStrBuilder = new SqlConnectionStringBuilder(
                configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found."));

            conStrBuilder.DataSource = settingsDatabase.Server;
            conStrBuilder.InitialCatalog = settingsDatabase.Database;

            if (settingsDatabase.UseWindowsAuthentication == true)
            {
                conStrBuilder.IntegratedSecurity = true;
            }
            else
            {
                conStrBuilder.UserID = settingsDatabase.Username;
                conStrBuilder.Password = settingsDatabase.Password;
            }

            string? connectionString = conStrBuilder.ConnectionString;

            //Console.WriteLine(connectionString);
            //Console.ReadKey();

            return connectionString;
        }

        // Basic identifier validation (schema/table names). Adjust pattern as required.
        private static void ValidateSqlIdentifier(string identifier)
        {
            if (string.IsNullOrWhiteSpace(identifier))
                throw new ArgumentException("Identifier is required.", nameof(identifier));

            // Allow [schema].[Table] or [Table] or schema.Table since caller will typically supply bracketed fullTableName.
            // This simple check rejects suspicious characters; tighten as needed.
            if (!Regex.IsMatch(identifier, @"^[A-Za-z0-9_\.\[\]]+$"))
                throw new InvalidOperationException("Invalid SQL identifier.");
        }

        public static async Task InsertWithIdentityAsync<TEntity>(DbContext context, Func<Task> insertAction)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            var entityType = context.Model.FindEntityType(typeof(TEntity))
                ?? throw new InvalidOperationException($"EF model does not contain entity type for CLR type '{typeof(TEntity).FullName}'.");
            
            var tableName = entityType?.GetTableName() ?? "Candidate";
            var schema = entityType?.GetSchema();
            var fullTableName = string.IsNullOrEmpty(schema) ? $"[{tableName}]" : $"[{schema}].[{tableName}]";

            if (string.IsNullOrWhiteSpace(fullTableName)) throw new ArgumentNullException(nameof(fullTableName));
            if (insertAction == null) throw new ArgumentNullException(nameof(insertAction));

            ValidateSqlIdentifier(fullTableName);

            // Ensure connection open on the DbContext so IDENTITY_INSERT applies to this session
            var connection = context.Database.GetDbConnection();
            var openedHere = false;
            if (connection.State != ConnectionState.Open)
            {
                await connection.OpenAsync();
                openedHere = true;
            }

            try
            {
                // Only the identifier must be inlined; validated above.
                await context.Database.ExecuteSqlRawAsync($"SET IDENTITY_INSERT {fullTableName} ON");
                try
                {
                    // Run the caller-provided insert that will call SaveChangesAsync() for entities that map to this table.
                    await insertAction();
                }
                finally
                {
                    // Always try to turn it off
                    await context.Database.ExecuteSqlRawAsync($"SET IDENTITY_INSERT {fullTableName} OFF");
                }
            }
            finally
            {
                if (openedHere)
                    await connection.CloseAsync();
            }
        }
    }
}
