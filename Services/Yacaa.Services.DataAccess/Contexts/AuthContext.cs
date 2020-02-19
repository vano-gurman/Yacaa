using Microsoft.EntityFrameworkCore;
using Yacaa.Services.DataAccess.Configuration;
using Yacaa.Shared.Models.Auth;

namespace Yacaa.Services.DataAccess.Contexts
{
    public class AuthContext : BaseContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public AuthContext(DatabaseConfiguration databaseConfiguration) : base(databaseConfiguration)
        {
            
        }
    }
}