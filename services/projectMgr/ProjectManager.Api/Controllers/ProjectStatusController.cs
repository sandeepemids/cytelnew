using Microsoft.AspNetCore.Mvc;
using ProjectManager.Constants;
using ProjectManager.Models;
using ProjectManager.Service.Interfaces;
using System;

namespace ProjectManager.Api.Controllers
{
    /// <summary>
    /// Project Status Controller for updating Project status
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}")]
    [ApiController]
    public class ProjectStatusController : ControllerBase
    {
        private readonly IProjectService projectService;
        public ProjectStatusController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        [HttpPost("projectstatus")]
        public ActionResult UpdateProjectStatus(ProjectStatus projStatus)
        {
            if (projectService.IsProjectIDExists(projStatus.ProjectID))
            {
                projectService.UpdateStatus(projStatus);
                return Ok();
            }
            else
            {
                return NotFound(String.Format(ValidationErrors.STATUS_PROJECT_ID_VAL_MSG, projStatus.ProjectID));
            }

        }
    }
}