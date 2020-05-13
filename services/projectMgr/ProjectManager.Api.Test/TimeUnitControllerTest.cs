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
    public class TimeUnitControllerTest
    {
        [Fact]
        public void GetTimeUnits()
        {

            //Arrange
            List<ProjectTimeUnit> timeUnits = TimeUnits.TimesUnitList;

            var projectService = new Mock<IProjectService>();
            projectService.Setup(service => service.GetTimeUnits())
                        .Returns(timeUnits);

            var controller = new TimeUnitController(projectService.Object);

            // Act
            var values = controller.GetTimeUnits();
            var result = values.Result as OkObjectResult;


            //Assert
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(timeUnits, result.Value);
        }
    }
}