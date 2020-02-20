using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Yacaa.Services.DataAccess
{
    public static class DataServiceExtensions
    {
        public static bool ValidateAndSetConnectionString(this DataService dataService, string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString)) return false;
            
            try
            {
                using var connection = new SqlConnection(connectionString);
                connection.Open();
                dataService.DatabaseConfiguration.ConnectionString = connectionString;
                using var context = dataService.DataContextFactory();
                context.Database.OpenConnection();
                if (context.Database.GetDbConnection().State != ConnectionState.Open) return false;
                Console.WriteLine(@"INFO: ConnectionString: " + context.Database.GetDbConnection().ConnectionString
                                                              + "\n DataBase: " +
                                                              context.Database.GetDbConnection().Database
                                                              + "\n DataSource: " +
                                                              context.Database.GetDbConnection().DataSource
                                                              + "\n ServerVersion: " +
                                                              context.Database.GetDbConnection().ServerVersion
                                                              + "\n TimeOut: " +
                                                              context.Database.GetDbConnection().ConnectionTimeout);
                context.Database.CloseConnection();
                dataService.IsConnectionValidated = true;
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}