using Microsoft.EntityFrameworkCore;
using Yacaa.Shared.Models.Auth;

namespace Yacaa.Services.DataAccess.Contexts
{
    public class UsersContext : DbContext
    {
        public UsersContext(string connectionString) : base (connectionString) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}