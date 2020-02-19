using Microsoft.EntityFrameworkCore;

namespace Yacaa.Services.DataAccess.Contexts
{
    public class BaseContext : DbContext
    {
        private readonly string _connectionString;
        
        public BaseContext(string connectionString) : base()
        {
            _connectionString = connectionString;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}