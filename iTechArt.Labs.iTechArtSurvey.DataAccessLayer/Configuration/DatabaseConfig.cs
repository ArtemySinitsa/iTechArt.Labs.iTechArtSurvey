using System.Collections.Specialized;
using System.Configuration;
using System.Data.SqlClient;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer
{
    public static class DatabaseConfig
    {
        public static string GetConnectionStringWithCredentials(string name)
        {
            var connectionString = AddCredentials(ConfigurationManager.ConnectionStrings[name].ConnectionString);
            return connectionString;
        }

        private static string AddCredentials(string connectionString)
        {
            var databaseConfiguration = (NameValueCollection)ConfigurationManager.GetSection("DatabaseConfig");
            var builder = new SqlConnectionStringBuilder(connectionString);
            builder.Add("User Id", databaseConfiguration["UserId"]);
            builder.Add("Password", databaseConfiguration["Password"]);
            return builder.ConnectionString;
        }
    }
}