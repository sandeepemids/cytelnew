using Storage.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Storage.DataAccess.Factory
{
    class StorageDBHandlerFactory
    {
        private string connectionString;

        public StorageDBHandlerFactory(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public IStorageDBHandler CreateDatabase()
        {
            IStorageDBHandler database = new PostgreSQLDataAccess(connectionString);
            return database;
        }
    }
}
