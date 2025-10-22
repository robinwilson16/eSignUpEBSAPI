using eSignUpEBSAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration; // Add this if not present

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
    }
}
