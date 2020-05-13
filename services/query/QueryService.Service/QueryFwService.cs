using Microsoft.Extensions.Options;
using QueryService.DataAccess;
using QueryService.DataAccess.Interfaces;
using QueryService.Models;
using QueryService.Service.Interfaces;
using System;

namespace QueryService.Service
{
    public class QueryFwService : IQueryFwService
    {
        private readonly IQueryServiceDataAccess queryServiceDataAccess;

        public QueryFwService(IOptions<QuerySettings> settings)
        {
            queryServiceDataAccess = new QueryServiceDataAccess(settings.Value.DBConnectionString);
        }
    }
}
