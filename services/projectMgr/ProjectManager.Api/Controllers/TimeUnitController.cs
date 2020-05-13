using Microsoft.AspNetCore.Mvc;
using ProjectManager.Models;
using ProjectManager.Service.Interfaces;
using System.Collections.Generic;

namespace ProjectManager.Api.Controllers
{
    /// <summary>
    /// TimeUnit Controller for Getting TimeUnit Details
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/timeunits")]
    [ApiController]
    public class TimeUnitController : ControllerBase
    {
        private readonly IProjectService projectService;
        public TimeUnitController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProjectTimeUnit>> GetTimeUnits()
        {
            IEnumerable<ProjectTimeUnit> timeUnits = projectService.GetTimeUnits();
            return Ok(timeUnits);
        }
    }
}