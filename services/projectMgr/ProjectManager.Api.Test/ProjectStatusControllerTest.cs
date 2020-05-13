using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjectManager.Api.Controllers;
using ProjectManager.Api.Test.TestData;
using ProjectManager.Constants;
using ProjectManager.Models;
using ProjectManager.Service.Interfaces;
using System;
using Xunit;

namespace ProjectManager.Api.Test
{
    public class ProjectStatusControllerTest
    {
        [Fact]
        public void UpdateProjectStatus()
        {

            //Arrange
            ProjectStatus projectStatus = ProjectStatuses.ProjStatus;

            var projectService = new Mock<IProjectService>();
            projectService.Setup(service => service.IsProjectIDExists(projectStatus.ProjectID))
                           .Returns(true);
            ;
            projectService.Setup(service => service.UpdateStatus(projectStatus));

            var controller = new ProjectStatusController(projectService.Object);

            // Act
            var values = controller.UpdateProjectStatus(projectStatus);
            var result = values as OkResult;

            // Assert
            Assert.Equal(200, result.StatusCode);
        }

        /// <summary>
        /// Should return not found response if project id does not exist
        /// </summary>
        [Fact]
        public void ShouldReturnNotFoundResponse()
        {

            //Arrange
            ProjectStatus projectStatus = ProjectStatuses.ProjStatus;

            var projectService = new Mock<IProjectService>();
            projectService.Setup(service => service.IsProjectIDExists(projectStatus.ProjectID))
                           .Returns(false);
            projectService.Setup(service => service.UpdateStatus(projectStatus));

            var controller = new ProjectStatusController(projectService.Object);

            // Act
            var values = controller.UpdateProjectStatus(projectStatus);
            var result = values as NotFoundObjectResult;

            //Assert
            Assert.Equal(404, result.StatusCode);
            Assert.Equal(String.Format(ValidationErrors.STATUS_PROJECT_ID_VAL_MSG, projectStatus.ProjectID), result.Value);
        }
    }
}
