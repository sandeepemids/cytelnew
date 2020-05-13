using Microsoft.AspNetCore.Mvc;
using Simulation.Service.Interfaces;
using Simulation.Models;
using Simulation.Service;

namespace Simulation.Api.Controllers
{
    /// <summary>
    /// Controller Class definition for defining various operations on Solaris Designs
    /// 1. Simulate Design
    /// 2. Get the Model Count
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/simulation")]
    [ApiController]
    public class SimulationController : ControllerBase
    {
        private readonly ISimulationService simulationService;

        /// <summary>
        /// SimulationController Constructor Definition
        /// </summary>
        /// <param name="simulationService"></param>
        public SimulationController(ISimulationService simulationService)
        {
            this.simulationService = simulationService;
        }

        /// <summary>
        /// POST endpoint for Simulating the Solaris Design
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<SimulationResponseModel> Simulate(SimulationRequestModel simulationModelRequest)
        {
            return simulationService.Simulate(simulationModelRequest.ProjectId, simulationModelRequest.ResourceId, 
                   simulationModelRequest.StatisticalEngineId, simulationModelRequest.CreatedBy);
        }

        /// <summary>
        /// Get endpoint for getting the Models count
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetModelCount()
        {
            return Ok("Success");
        }
    }
}
