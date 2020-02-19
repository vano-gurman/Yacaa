using Microsoft.EntityFrameworkCore;

namespace Yacaa.Services.DataAccess.Contexts
{
    public class BaseContext : DbContext
    {
        private readonly string _connectionString;

        protected BaseContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}