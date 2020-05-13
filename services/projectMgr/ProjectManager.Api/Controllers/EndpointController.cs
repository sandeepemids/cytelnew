using Microsoft.AspNetCore.Mvc;
using ProjectManager.Models;
using ProjectManager.Service.Interfaces;
using System.Collections.Generic;

namespace ProjectManager.Api.Controllers
{
    /// <summary>
    /// Controller created for performing GET action on Endpoint resource
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/endpoints")]
    [ApiController]
    public class EndpointController : ControllerBase
    {
        private readonly IProjectService projectService;
        public EndpointController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        /// <summary>
        /// Get End point created for listing endpoints
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Endpoint>> GetEndpoints()
        {
            IEnumerable<Endpoint> endpoints = projectService.GetEndpoints();
            return Ok(endpoints);
        }
    }
}