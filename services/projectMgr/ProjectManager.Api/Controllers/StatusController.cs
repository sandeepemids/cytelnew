using Microsoft.AspNetCore.Mvc;
using ProjectManager.Models;
using ProjectManager.Service.Interfaces;
using System.Collections.Generic;

namespace ProjectManager.Api.Controllers
{
    /// <summary>
    /// Status Controller for Getting Status Details
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IProjectService projectService;
        public StatusController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        [HttpGet("statuses")]
        public ActionResult<IEnumerable<Status>> GetStatuses()
        {
            IEnumerable<Status> statuses = projectService.GetStatuses();
            return Ok(statuses);
        }
    }
}