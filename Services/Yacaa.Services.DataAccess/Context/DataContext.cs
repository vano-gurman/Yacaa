using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Yacaa.Services.DataAccess.Configuration;
using Yacaa.Shared.Models;
using Yacaa.Shared.Models.Auth;
using Yacaa.Shared.Models.Dictionaries;

namespace Yacaa.Services.DataAccess.Context
{
    public class DataContext : DbContext
    {
        #region Private members
        private readonly DatabaseConfiguration _databaseConfiguration;

        #endregion

        #region Constructors
 
        public DataContext(DatabaseConfiguration databaseConfiguration)
        {
            _databaseConfiguration = databaseConfiguration;
        }

        #endregion

        #region Public properties
        /* Authentication */
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        
        /* Dictionaries */
        public DbSet<Company> Companies { get; set; }
        public DbSet<ContractType> ContractTypes { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        
        /* Content */
        public DbSet<Contract> Contracts { get; set; }
        
        
        #endregion
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseSqlServer(_databaseConfiguration.ConnectionString);
        }
        // test comment
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username);               
        }
    }
}