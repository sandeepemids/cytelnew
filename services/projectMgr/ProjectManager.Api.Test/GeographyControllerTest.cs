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
    public class GeographyControllerTest
    {
        [Fact]
        public void GetGeographies()
        {
            //Arrange
            List<Geography> geographies = Geographies.GeographyList;

            var inputAdvisorService = new Mock<IInputAdvisorService>();

            inputAdvisorService.Setup(service => service.GetGeographies())
                        .Returns(geographies);
            var controller = new GeographyController(inputAdvisorService.Object);

            // Act
            var values = controller.GetGeographies();
            var result = values.Result as OkObjectResult;


            //Assert
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(geographies, result.Value);
        }
    }
}