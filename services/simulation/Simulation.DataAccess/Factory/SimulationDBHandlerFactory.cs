using Simulation.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Simulation.DataAccess.Factory
{
    class SimulationDBHandlerFactory
    {
        private string connectionString;

        public SimulationDBHandlerFactory(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public ISimulationDBHandler CreateDatabase()
        {
            ISimulationDBHandler database = new PostgreSQLDataAccess(connectionString);
            return database;
        }
    }
}
