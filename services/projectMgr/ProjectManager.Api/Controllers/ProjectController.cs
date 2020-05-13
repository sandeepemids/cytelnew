using Microsoft.AspNetCore.Mvc;
using ProjectManager.Constants;
using ProjectManager.Models;
using ProjectManager.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace ProjectManager.Api.Controllers
{
    /// <summary>
    /// Project Controller for performing get, post actions on Project resource 
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService projectService;
        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        /// <summary>
        /// Get endpoint for listing the projects
        /// </summary>
        /// <returns></returns>
        [HttpGet("projects/{resourceID}")]
        public ActionResult<IEnumerable<Project>> GetProjects(int resourceID)
        {
            if (projectService.IsProjectExistsForResourceID(resourceID))
            {
                IEnumerable<Project> projects = projectService.GetProjects(resourceID);
                return Ok(projects);
            }
            else
            {
                return NotFound(String.Format(ValidationErrors.PROJECT_DOES_NOT_EXISTS_RESOURCE_ID_VAL_MSG, resourceID));
            }

        }

        /// <summary>
        /// POST endpoint for creating projects
        /// </summary>
        /// <param name="newProject"></param>
        /// <returns></returns>
        [HttpPost("projects")]
        public ActionResult CreateProject(NewProject newProject)
        {
            if (projectService.IsProjectNameExists(newProject.ProjectName.Trim()))
            {
                return Conflict(new ErrorDetails
                {
                    ExceptionMessage = ResponseMessages.PROJECT_NAME_EXISTS,
                    StatusCode = ResponseCodes.STATUS_CODE_CONFLICT
                });
            }
            else if (projectService.IsProtocolIDExists(newProject.ProtocolID.Trim()))
            {
                return Conflict(new ErrorDetails
                {
                    ExceptionMessage = ResponseMessages.PROTOCOL_ID_EXISTS,
                    StatusCode = ResponseCodes.STATUS_CODE_CONFLICT
                });
            }
            else
            {

                Project project = projectService.CreateProject(newProject);
                return Created(ResponseMessages.PROJECT_CREATED, project);
            }
        }
    }
}