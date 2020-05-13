using Microsoft.AspNetCore.Mvc;
using QueryService.Service.Interfaces;

namespace QueryService.Api.Controllers
{
    /// <summary>
    /// Controller Class definition for defining various operations on Solaris Designs
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/queryservice")]
    [ApiController]
    public class QueryServiceController : ControllerBase
    {
        private readonly IQueryFwService queryService;

        /// <summary>
        /// QueryServiceController Constructor Definition
        /// </summary>
        /// <param name="queryService"></param>
        public QueryServiceController(IQueryFwService queryService)
        {
            this.queryService = queryService;
        }
    }

    
}