using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ProjectManager.Constants;
using ProjectManager.Models;
using ProjectManager.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace ProjectManager.Api.Controllers
{
    /// <summary>
    /// Input Advisor Controller for updating saving changes from all the input advisor screens listed below
    /// 1. Objective
    /// 2. Population
    /// 3. Enrollment
    /// 4. Design
    /// 5. Operational Cost
    /// 6. Market Access
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}")]
    [ApiController]

    public class InputAdvisorController : ControllerBase
    {
        private readonly IProjectService projectService;

        public InputAdvisorController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        /// <summary>
        /// Post Endpoint for creating Input Advisor inputs
        /// </summary>
        /// <param name="inputAdvisorInput">Input Advisor Input Object</param>
        /// <param name="pageID">Page Identifier from where Save is triggered</param>
        /// <returns></returns>
        [HttpPost("inputadvisor/{pageID}")]
        public ActionResult CreateInputAdvisorInputs(InputAdvisor inputAdvisorInput, string pageID)
        {
            if (projectService.IsProjectIDExistsForResourceID(inputAdvisorInput.ProjectID, inputAdvisorInput.ResourceID))
            {
                string jsonObj = Convert.ToString(inputAdvisorInput.Object);
                if (!string.IsNullOrEmpty(jsonObj) && jsonObj.StartsWith("{") && jsonObj.EndsWith("}"))
                {
                    projectService.ValidateInputAdvisorJson(pageID, inputAdvisorInput.Object);
                }
                InputAdvisor createdInputAdvisorInputs = projectService.CreateInputAdvisorInputs(inputAdvisorInput);
                return Created(ResponseMessages.INPUT_ADVISOR_INPUTS_CREATED, createdInputAdvisorInputs);
            }
            else
            {
                return NotFound(string.Format(ValidationErrors.PROJECT_ID_DOES_NOT_EXISTS_RESOURCE_ID_VAL_MSG, inputAdvisorInput.ProjectID, inputAdvisorInput.ResourceID));
            }
        }

        /// <summary>
        /// Get Endpoint for retrieving last updated Input advisor inputs
        /// </summary>
        /// <param name="resourceID">Resource ID</param>
        /// <param name="projectID">Project ID</param>
        /// <returns>Recently Inserted Input Advisor Input Object</returns>
        [HttpGet("inputadvisor/{resourceID}/{projectID}")]
        public ActionResult<JObject> GetInputAdvisorInputs(int resourceID, int projectID)
        {
            if (projectService.IsProjectIDExistsForResourceID(projectID, resourceID))
            {
                JObject jsonObject = projectService.GetInputAdvisorInputs(resourceID, projectID);
                return Ok(jsonObject);
            }
            else
            {
                return NotFound(string.Format(ValidationErrors.PROJECT_ID_DOES_NOT_EXISTS_RESOURCE_ID_VAL_MSG, projectID, resourceID));
            }
        }

        /// <summary>
        /// Get endpoint for listing the statistical engines
        /// </summary>
        /// <returns></returns>
        [HttpGet("inputadvisor/statisticalengines")]
        public ActionResult<IEnumerable<StatisticalEngines>> GetStatisticalEngines()
        {
            IEnumerable<StatisticalEngines> statisticalEngines = projectService.GetStatisticalEngines();
            return Ok(statisticalEngines);
        }

        /// <summary>
        /// Get endpoint for listing the statistical engine details
        /// </summary>
        /// <param name="name"></param>
        /// <param name="version"></param>
        /// <param name="releaseDate"></param>
        /// <returns></returns>
        [HttpGet("inputadvisor/statisticalengines/{name}/{version}")]
        public ActionResult<StatisticalEngineDetails> GetStatisticalEngineDetails(string name, string version)
        {
            StatisticalEngineDetails statisticalEngineDetails = projectService.GetStatisticalEngineDetails(name, version);

            return Ok(statisticalEngineDetails);
        }
    }
}
