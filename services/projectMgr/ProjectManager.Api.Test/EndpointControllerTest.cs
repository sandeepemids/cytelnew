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
    public class EndpointControllerTest
    {
        [Fact]
        public void GetEndpoints()
        {
            //Arrange
            List<Endpoint> endpoints = Endpoints.EndpointList;

            var projectService = new Mock<IProjectService>();

            projectService.Setup(service => service.GetEndpoints())
                        .Returns(endpoints);
            var controller = new EndpointController(projectService.Object);

            // Act
            var values = controller.GetEndpoints();
            var result = values.Result as OkObjectResult;


            //Assert
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(endpoints, result.Value);
        }
    }
}