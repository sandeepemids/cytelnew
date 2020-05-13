using Microsoft.AspNetCore.Mvc;
using ProjectManager.Models;
using ProjectManager.Service.Interfaces;
using System.Collections.Generic;

namespace ProjectManager.Api.Controllers
{
    /// <summary>
    /// Controller created for performing GET action on Indication resource
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/indications")]
    [ApiController]
    public class IndicationController : ControllerBase
    {
        private readonly IProjectService projectService;
        public IndicationController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        /// <summary>
        /// Get End point created for listing indications
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Indication>> GetIndications()
        {
            IEnumerable<Indication> indications = projectService.GetIndications();
            return Ok(indications);
        }
    }
}