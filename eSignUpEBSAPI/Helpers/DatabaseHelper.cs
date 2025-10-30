using eSignUpEBSAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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

        // Structured logging: logs per-table start/finish, rows affected and full exception objects when failures occur.
        public static async Task<bool?> ClearTables(DbContext context, ILogger? logger = null)
        {
            using var scope = logger?.BeginScope(new Dictionary<string, object>
            {
                ["Operation"] = "ClearTables",
                ["TimestampUtc"] = DateTime.UtcNow
            });

            logger?.LogInformation("Starting ClearTables operation");

            var success = true;

            // Use helper to run operations and log errors but continue, collecting failures.
            async Task<bool> RunAsync(Func<Task<bool?>> op, string tableName, string opName)
            {
                try
                {
                    logger?.LogDebug("{Operation} - starting {OpName} for {Table}", "ClearTables", opName, tableName);
                    var result = await op();
                    if (result != true)
                    {
                        logger?.LogWarning("{Operation} - {OpName} returned false for {Table}", "ClearTables", opName, tableName);
                        return false;
                    }
                    logger?.LogDebug("{Operation} - completed {OpName} for {Table}", "ClearTables", opName, tableName);
                    return true;
                }
                catch (Exception ex)
                {
                    logger?.LogError(ex, "{Operation} - {OpName} threw for {Table}: {Message}", "ClearTables", opName, tableName, ex.Message);
                    return false;
                }
            }

            // Order matters for FK constraints. Adjust as needed for your DB.
            if (!await RunAsync(() => ClearAndReseedTable(context, "EnglishMathsComponent", logger), "EnglishMathsComponent", "ClearAndReseed")) success = false;
            if (!await RunAsync(() => ClearAndReseedTable(context, "HouseholdSituation", logger), "HouseholdSituation", "ClearAndReseed")) success = false;
            if (!await RunAsync(() => ClearAndReseedTable(context, "OnboardingDocument", logger), "OnboardingDocument", "ClearAndReseed")) success = false;
            if (!await RunAsync(() => ClearAndReseedTable(context, "PlacedRecruitment", logger), "PlacedRecruitment", "ClearAndReseed")) success = false;
            if (!await RunAsync(() => ClearAndReseedTable(context, "LLDDAndHealthProblemPeopleSoft", logger), "LLDDAndHealthProblemPeopleSoft", "ClearAndReseed")) success = false;
            if (!await RunAsync(() => ClearAndReseedTable(context, "LLDDAndHealthProblem", logger), "LLDDAndHealthProblem", "ClearAndReseed")) success = false;
            if (!await RunAsync(() => ClearAndReseedTable(context, "EmploymentStatusMonitoring", logger), "EmploymentStatusMonitoring", "ClearAndReseed")) success = false;
            if (!await RunAsync(() => ClearAndReseedTable(context, "LearnerEmploymentStatus", logger), "LearnerEmploymentStatus", "ClearAndReseed")) success = false;
            if (!await RunAsync(() => ClearAndReseedTable(context, "EnglishAndMathsQualification", logger), "EnglishAndMathsQualification", "ClearAndReseed")) success = false;
            if (!await RunAsync(() => ClearAndReseedTable(context, "CustomField", logger), "CustomField", "ClearAndReseed")) success = false;
            if (!await RunAsync(() => ClearTable(context, "ContactPreference", logger), "ContactPreference", "Clear")) success = false;
            if (!await RunAsync(() => ClearAndReseedTable(context, "CandidateQualification", logger), "CandidateQualification", "ClearAndReseed")) success = false;
            if (!await RunAsync(() => ClearAndReseedTable(context, "CandidateNote", logger), "CandidateNote", "ClearAndReseed")) success = false;
            if (!await RunAsync(() => ClearAndReseedTable(context, "CandidateDocument", logger), "CandidateDocument", "ClearAndReseed")) success = false;
            if (!await RunAsync(() => ClearAndReseedTable(context, "ApprenticeshipEmployer", logger), "ApprenticeshipEmployer", "ClearAndReseed")) success = false;
            if (!await RunAsync(() => ClearTable(context, "CandidateExtraFields", logger), "CandidateExtraFields", "Clear")) success = false;
            if (!await RunAsync(() => ClearAndReseedTable(context, "Candidate", logger), "Candidate", "ClearAndReseed")) success = false;

            if (success)
                logger?.LogInformation("ClearTables completed successfully");
            else
                logger?.LogWarning("ClearTables completed with one or more failures. Check previous logs for details.");

            return success;
        }

        public static async Task<bool?> ClearAndReseedTable(DbContext context, string tableName, ILogger? logger = null)
        {
            using var scope = logger?.BeginScope(new Dictionary<string, object>
            {
                ["Operation"] = "ClearAndReseedTable",
                ["Table"] = tableName,
                ["TimestampUtc"] = DateTime.UtcNow
            });

            logger?.LogDebug("ClearAndReseedTable starting for {Table}", tableName);

            try
            {
                var cleared = await ClearTable(context, tableName, logger);
                if (cleared != true)
                {
                    logger?.LogWarning("ClearAndReseedTable: ClearTable returned false for {Table}", tableName);
                    return false;
                }

                var reseeded = await ReseedIdentity(context, tableName, logger);
                if (reseeded != true)
                {
                    logger?.LogWarning("ClearAndReseedTable: ReseedIdentity returned false for {Table}", tableName);
                    return false;
                }

                logger?.LogDebug("ClearAndReseedTable completed for {Table}", tableName);
                return true;
            }
            catch (Exception ex)
            {
                logger?.LogError(ex, "ClearAndReseedTable failed for {Table}", tableName);
                return false;
            }
        }

        public static async Task<bool?> ClearTable(DbContext context, string tableName, ILogger? logger = null)
        {
            using var scope = logger?.BeginScope(new Dictionary<string, object>
            {
                ["Operation"] = "ClearTable",
                ["Table"] = tableName,
                ["TimestampUtc"] = DateTime.UtcNow
            });

            try
            {
                ValidateSqlIdentifier(tableName);

                logger?.LogInformation("Executing DELETE FROM [{Table}]", tableName);
                var rowsAffected = await context.Database.ExecuteSqlRawAsync($"DELETE FROM [{tableName}]");
                logger?.LogInformation("DELETE completed for {Table}. Rows affected: {RowsAffected}", tableName, rowsAffected);

                return true;
            }
            catch (Exception ex)
            {
                // Log the full exception object so stack trace and inner exceptions are captured by the logging provider
                logger?.LogError(ex, "Error clearing table {Table}. Exception: {Message}", tableName, ex.Message);
                return false;
            }
        }

        public static async Task<bool?> ReseedIdentity(DbContext context, string tableName, ILogger? logger = null)
        {
            using var scope = logger?.BeginScope(new Dictionary<string, object>
            {
                ["Operation"] = "ReseedIdentity",
                ["Table"] = tableName,
                ["TimestampUtc"] = DateTime.UtcNow
            });

            try
            {
                logger?.LogInformation("Reseeding identity for {Table}", tableName);
                var result = await context.Database.ExecuteSqlRawAsync($"DBCC CHECKIDENT ('[{tableName}]', RESEED, 0)");
                logger?.LogInformation("DBCC CHECKIDENT result for {Table}: {Result}", tableName, result);
                return result >= 0;
            }
            catch (Exception ex)
            {
                logger?.LogError(ex, "Error reseeding identity for {Table}. Exception: {Message}", tableName, ex.Message);
                return false;
            }
        }
    }
}
