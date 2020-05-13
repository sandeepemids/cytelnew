using QueryService.DataAccess.Interfaces;

namespace QueryService.DataAccess.Factory
{
    class QueryServiceDBHandlerFactory
    {
        private string connectionString;

        public QueryServiceDBHandlerFactory(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public IQueryServiceDBHandler CreateDatabase()
        {
            IQueryServiceDBHandler database = new PostgreSQLDataAccess(connectionString);
            return database;
        }
    }
}
