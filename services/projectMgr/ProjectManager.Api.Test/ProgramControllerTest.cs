using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjectManager.Api.Controllers;
using ProjectManager.Api.Test.TestData;
using ProjectManager.Constants;
using ProjectManager.Models;
using ProjectManager.Service.Interfaces;
using System.Collections.Generic;
using Xunit;
using ProgramModel = ProjectManager.Models.Program;

namespace ProjectManager.Api.Test
{
    public class ProgramControllerTest
    {
        [Fact]
        public void GetPrograms()
        {

            //Arrange
            List<ProgramModel> programs = Programs.ProgramsList;

            var projectService = new Mock<IProjectService>();
            projectService.Setup(service => service.GetPrograms(1))
                        .Returns(programs);

            var controller = new ProgramController(projectService.Object);

            // Act
            var values = controller.GetPrograms(1);
            var result = values.Result as OkObjectResult;


            //Assert
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(programs, result.Value);
        }

        [Fact]
        public void CreateProgram()
        {

            //Arrange
            ProgramModel createdProgram = Programs.CreatedProgram;

            NewProgram newProgram = Programs.NewProgram;


            var projectService = new Mock<IProjectService>();
            projectService.Setup(service => service.IsProgramNameExists(createdProgram.Name, createdProgram.ResourceID))
                        .Returns(false);

            var controller = new ProgramController(projectService.Object);

            // Act
            var values = controller.CreateProgram(newProgram);
            var result = values as CreatedResult;


            //Assert
            Assert.Equal(201, result.StatusCode);
            Assert.Equal(ResponseMessages.PROGRAM_CREATED, result.Location);
        }
    }
}