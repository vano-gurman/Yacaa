using Microsoft.EntityFrameworkCore;
using Yacaa.Shared.Models;
using Yacaa.Shared.Models.Dictionaries;

namespace Yacaa.Services.DataAccess.Contexts
{
    public class ContractsContext : DbContext
    {
        public ContractsContext(DbContextOptions options) : base (options) { }

        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ContractType> ContractTypes { get; set; }
        public DbSet<Currency> Currencies { get; set; }
    }
}