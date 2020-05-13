using Moq;
using Simulation.Api.Test.TestData;
using Simulation.Models;
using Simulation.Service;
using Simulation.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Simulation.Api.Test
{
    public class SimulationServiceTest
    {
        [Fact]
        public void Simulate()
        {
            var expectedResult = new SimulationResponseModel()
            {
                NoOfModels = 120,
                TimeInSeconds = 600
            };

            var simulationService = new Mock<ISimulationService>();
            simulationService.Setup(service => service.Simulate(1, 4, 1, "test user"))
                .Returns(expectedResult);
            var actualResult = simulationService.Object.Simulate(1, 4, 1, "test user");
            Assert.NotNull(actualResult);
            Assert.Equal(expectedResult.NoOfModels, actualResult.NoOfModels);
            Assert.Equal(expectedResult.TimeInSeconds, actualResult.TimeInSeconds);
        }
    }
}
