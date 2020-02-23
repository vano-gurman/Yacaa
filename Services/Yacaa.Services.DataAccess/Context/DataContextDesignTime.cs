using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Yacaa.Services.DataAccess.Configuration;
using Yacaa.Shared.Models;
using Yacaa.Shared.Models.Auth;
using Yacaa.Shared.Models.Dictionaries;

namespace Yacaa.Services.DataAccess.Context
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        private DatabaseConfiguration _databaseConfiguration;
        public DataContext CreateDbContext(string[] args)
        {
            _databaseConfiguration = new DatabaseConfiguration
            {
                ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=testDB1;Trusted_Connection=True;"
            };            
                
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer(_databaseConfiguration.ConnectionString);

            return new DataContext(_databaseConfiguration);
        }
    }
}
