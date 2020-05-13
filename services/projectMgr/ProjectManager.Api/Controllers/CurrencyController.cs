using Microsoft.AspNetCore.Mvc;
using ProjectManager.Models;
using ProjectManager.Service.Interfaces;
using System.Collections.Generic;

namespace ProjectManagement.Api.Controllers
{
    /// <summary>
    /// Controller created for performing GET action on Currency resource
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/currencies")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly IProjectService projectService;
        public CurrencyController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        /// <summary>
        /// GET endpoint created for getting the list of currencies.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Currency>> GetCurrencies()
        {
            IEnumerable<Currency> currencies = projectService.GetCurrencies();
            return Ok(currencies);
        }
    }
}
