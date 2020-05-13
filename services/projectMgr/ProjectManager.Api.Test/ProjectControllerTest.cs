using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjectManager.Api.Controllers;
using ProjectManager.Api.Test.TestData;
using ProjectManager.Constants;
using ProjectManager.Models;
using ProjectManager.Service.Interfaces;
using System.Collections.Generic;
using Xunit;

namespace ProjectManager.Api.Test
{
    public class ProjectControllerTest
    {
        [Fact]
        public void GetProjects()
        {

            //Arrange
            List<Project> projects = Projects.ProjectsList;

            var projectService = new Mock<IProjectService>();
            projectService.Setup(service => service.IsProjectExistsForResourceID(1))
                        .Returns(true);

            projectService.Setup(service => service.GetProjects(1))
                        .Returns(projects);

            var controller = new ProjectController(projectService.Object);

            // Act
            var values = controller.GetProjects(1);
            var result = values.Result as OkObjectResult;


            //Assert
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(projects, result.Value);
        }

        [Fact]
        public void CreateProject()
        {

            //Arrange
            Project createdProject = Projects.CreatedProject;

            var projectService = new Mock<IProjectService>();
            NewProject newProject = Projects.NewProject;


            projectService.Setup(service => service.IsProjectNameExists(newProject.ProjectName))
                        .Returns(false);

            projectService.Setup(service => service.IsProtocolIDExists(newProject.ProtocolID))
                       .Returns(false);

            var controller = new ProjectController(projectService.Object);

            // Act
            var values = controller.CreateProject(newProject);
            var result = values as CreatedResult;


            //Assert
            Assert.Equal(201, result.StatusCode);
            Assert.Equal(ResponseMessages.PROJECT_CREATED, result.Location);
        }
    }
}
