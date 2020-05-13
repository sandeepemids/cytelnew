using Microsoft.AspNetCore.Mvc;
using ProjectManager.Models;
using ProjectManager.Service.Interfaces;
using System.Collections.Generic;

namespace ProjectManager.Api.Controllers
{
    /// <summary>
    /// Controller created for performing GET action on Geography resource
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/geographies")]
    [ApiController]
    public class GeographyController : ControllerBase
    {
        private readonly IInputAdvisorService inputAdvisorService;
        public GeographyController(IInputAdvisorService inputAdvisorService)
        {
            this.inputAdvisorService = inputAdvisorService;
        }

        /// <summary>
        /// Get end point created for listing available geographies
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Geography>> GetGeographies()
        {
            IEnumerable<Geography> geographies = inputAdvisorService.GetGeographies();
            return Ok(geographies);
        }
    }
}