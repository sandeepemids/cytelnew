using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjectManager.Api.Controllers;
using ProjectManager.Api.Test.TestData;
using ProjectManager.Models;
using ProjectManager.Service.Interfaces;
using System.Collections.Generic;
using Xunit;

namespace ProjectManager.Api.Test
{
    public class StatusControllerTest
    {
        [Fact]
        public void GetStatuses()
        {

            //Arrange
            List<Status> statuses = Statuses.StatusList;

            var projectService = new Mock<IProjectService>();
            projectService.Setup(service => service.GetStatuses())
                        .Returns(statuses);

            var controller = new StatusController(projectService.Object);

            // Act
            var values = controller.GetStatuses();
            var result = values.Result as OkObjectResult;


            //Assert
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(statuses, result.Value);
        }
    }
}
