using Microsoft.AspNetCore.Mvc;
using ProjectManager.Constants;
using ProjectManager.Models;
using ProjectManager.Service.Interfaces;
using System.Collections.Generic;
using ProgramModel = ProjectManager.Models.Program;

namespace ProjectManager.Api.Controllers
{
    /// <summary>
    /// Controller created for performaing GET/POST actions on Program resource
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        private readonly IProjectService projectService;
        public ProgramController(IProjectService projectService)
        {
            this.projectService = projectService;

        }

        /// <summary>
        /// Get endpoint created for listing programs
        /// </summary>
        /// <returns></returns>
        [HttpGet("programs/{resourceID}")]
        public ActionResult<IEnumerable<ProgramModel>> GetPrograms(int resourceID)
        {
            IEnumerable<ProgramModel> programs = projectService.GetPrograms(resourceID);
            return Ok(programs);
        }

        /// <summary>
        /// Get endpoint created for creating programs
        /// </summary>
        /// <returns></returns>
        [HttpPost("programs")]
        public ActionResult CreateProgram(NewProgram newProgram)
        {
            // if is program exists throw error message
            if (projectService.IsProgramNameExists(newProgram.ProgramName.Trim(),newProgram.ResourceID))
            {
                return Conflict(new ErrorDetails
                {
                    ExceptionMessage = ResponseMessages.PROGRAM_NAME_EXISTS,
                    StatusCode = ResponseCodes.STATUS_CODE_CONFLICT
                });
            }
            else
            {
                ProgramModel createdProgram = projectService.CreateProgram(newProgram);
                return Created(ResponseMessages.PROGRAM_CREATED, createdProgram);
            }



        }

    }
}