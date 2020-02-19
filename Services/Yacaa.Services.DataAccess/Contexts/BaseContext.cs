using System;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Yacaa.Services.DataAccess.Configuration;

namespace Yacaa.Services.DataAccess.Contexts
{
    public class BaseContext : DbContext
    {
        private readonly string _connectionString;

        protected BaseContext(DatabaseConfiguration databaseConfiguration)
        {
            _connectionString = databaseConfiguration.ConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public bool CheckConnection()
        {
            Database.OpenConnection();
            if (Database.GetDbConnection().State != ConnectionState.Open) return false;
            Console.WriteLine(@"INFO: ConnectionString: " + Database.GetDbConnection().ConnectionString 
                                                          + "\n DataBase: " + Database.GetDbConnection().Database 
                                                          + "\n DataSource: " + Database.GetDbConnection().DataSource 
                                                          + "\n ServerVersion: " + Database.GetDbConnection().ServerVersion 
                                                          + "\n TimeOut: " + Database.GetDbConnection().ConnectionTimeout);
            Database.CloseConnection();
            return true;
        }
        
        
    }
}