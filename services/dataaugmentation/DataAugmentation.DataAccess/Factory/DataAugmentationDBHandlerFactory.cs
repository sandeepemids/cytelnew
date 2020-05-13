using DataAugmentation.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAugmentation.DataAccess.Factory
{
    public class DataAugmentationDBHandlerFactory
    {
        private string connectionString;

        public DataAugmentationDBHandlerFactory(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public IDataAugmentationDBHandler CreateDatabase()
        {
            IDataAugmentationDBHandler database = new PostgreSQLDataAccess(connectionString);
            return database;
        }
    }
}
