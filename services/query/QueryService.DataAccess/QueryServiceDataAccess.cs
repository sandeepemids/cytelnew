using QueryService.DataAccess.Factory;
using QueryService.DataAccess.Interfaces;
using System;

namespace QueryService.DataAccess
{
    public class QueryServiceDataAccess : IQueryServiceDataAccess
    {
        private readonly IQueryServiceDBManager queryServiceDBManager;

        public QueryServiceDataAccess(string dbConnectionString)
        {
            queryServiceDBManager = new QueryServiceDBManager(dbConnectionString);
        }
    }
}
