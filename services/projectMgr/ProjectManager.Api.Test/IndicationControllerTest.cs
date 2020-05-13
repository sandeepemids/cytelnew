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
    public class IndicationControllerTest
    {
        [Fact]
        public void GetIndications()
        {
            //Arrange
            List<Indication> indications = Indications.IndicationsList;

            var projectService = new Mock<IProjectService>();

            projectService.Setup(service => service.GetIndications())
                        .Returns(indications);
            var controller = new IndicationController(projectService.Object);

            // Act
            var values = controller.GetIndications();
            var result = values.Result as OkObjectResult;


            //Assert
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(indications, result.Value);
        }
    }
}