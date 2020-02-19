using Microsoft.EntityFrameworkCore;
using Yacaa.Shared.Models;
using Yacaa.Shared.Models.Dictionaries;

namespace Yacaa.Services.DataAccess.Contexts
{
    public class ContractsContext : BaseContext
    {
        protected ContractsContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ContractType> ContractTypes { get; set; }
        public DbSet<Currency> Currencies { get; set; }
    }

}