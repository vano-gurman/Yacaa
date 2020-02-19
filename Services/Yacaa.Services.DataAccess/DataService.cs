using System;
using Microsoft.Data.SqlClient;
using Yacaa.Services.DataAccess.Contexts;

namespace Yacaa.Services.DataAccess
{
    public class DataService
    {
        public Func<AuthContext> AuthContextFactory { get; }
        public Func<ContractsContext> ContractsContextFactory { get; }

        public DataService(
            Func<AuthContext> authContextFactory,
            Func<ContractsContext> contractsContextFactory)
        {
            AuthContextFactory = authContextFactory;
            ContractsContextFactory = contractsContextFactory;
        }

        public bool ValidateConnection(string connectionString)
        {
            try
            {
                using var connection = new SqlConnection(connectionString: connectionString);
                connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}