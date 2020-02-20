using System;
using Yacaa.Services.DataAccess.Configuration;
using Yacaa.Services.DataAccess.Context;

namespace Yacaa.Services.DataAccess
{
    public class DataService
    {
        public Func<DataContext> DataContextFactory { get; }
        public DatabaseConfiguration DatabaseConfiguration { get; }
        public bool IsConnectionValidated { get; set; }

        public DataService(Func<DataContext> dataContextFactory, DatabaseConfiguration databaseConfiguration)
        {
            DataContextFactory = dataContextFactory;
            DatabaseConfiguration = databaseConfiguration;
        }
    }
}