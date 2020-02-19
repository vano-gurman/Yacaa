using Microsoft.EntityFrameworkCore;
using Yacaa.Services.DataAccess.Configuration;
using Yacaa.Shared.Models;
using Yacaa.Shared.Models.Dictionaries;

namespace Yacaa.Services.DataAccess.Contexts
{
    public class ContractsContext : BaseContext
    {

        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ContractType> ContractTypes { get; set; }
        public DbSet<Currency> Currencies { get; set; }

        public ContractsContext(DatabaseConfiguration databaseConfiguration) : base(databaseConfiguration)
        {
        }
    }

}