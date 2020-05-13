using Moq;
using Simulation.Api.Controllers;
using Simulation.Models;
using Simulation.Service;
using Simulation.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Simulation.Api.Test.TestData
{
    public class SimulationControllerTest
    {
        [Fact]
        public void Simulate()
        {
            var request = new SimulationRequestModel
            {
                ProjectId = 1,
                ResourceId = 4,
                StatisticalEngineId = 1,
                CreatedBy = "test user"
            };
            var expectedResult = new SimulationResponseModel()
            {
                NoOfModels = 120,
                TimeInSeconds = 600
            };

            var projectService = new Mock<ISimulationService>();
            projectService.Setup(service => service.Simulate(request.ProjectId, request.ResourceId, request.StatisticalEngineId, request.CreatedBy))
                        .Returns(expectedResult);
            var controller = new SimulationController(projectService.Object);
            var actualResult = controller.Simulate(request);
            Assert.Equal(expectedResult.NoOfModels, actualResult.Value.NoOfModels);
            Assert.Equal(expectedResult.TimeInSeconds, actualResult.Value.TimeInSeconds);
        }
    }
}
