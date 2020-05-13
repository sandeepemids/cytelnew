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
    public class InputAdvisorControllerTest
    {
        static List<InputAdvisor> inputAdvisorInputs = InputAdvisorInputs.InputAdvisorInputsList;

        [Fact]
        public void GetInputAdvisorInputs()
        {
            int projectID = 4;
            int resourceID = 1;

            var projectService = new Mock<IProjectService>();

            projectService.Setup(service => service.IsProjectIDExistsForResourceID(projectID, resourceID))
                        .Returns(true);

            projectService.Setup(service => service.GetInputAdvisorInputs(resourceID, projectID))
                        .Returns(inputAdvisorInputs[2].Object);

            var controller = new InputAdvisorController(projectService.Object);

            var values = controller.GetInputAdvisorInputs(resourceID, projectID);
            var result = values.Result as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
            Assert.Equal(inputAdvisorInputs[2].Object, result.Value);
        }

        [Fact]
        public void CreateInputAdvisorInputs()
        {
            int projectID = 1;
            int resourceID = 1;

            var projectService = new Mock<IProjectService>();

            projectService.Setup(service => service.IsProjectIDExistsForResourceID(projectID, resourceID))
                       .Returns(true);

            projectService.Setup(service => service.CreateInputAdvisorInputs(inputAdvisorInputs[1]))
                       .Returns(inputAdvisorInputs[1]);

            var controller = new InputAdvisorController(projectService.Object);

            // Act
            var values = controller.CreateInputAdvisorInputs(inputAdvisorInputs[1], APIConstants.PAGE_OBJECTIVE);
            var result = values as CreatedResult;


            //Assert
            Assert.Equal(201, result.StatusCode);
            Assert.Equal(ResponseMessages.INPUT_ADVISOR_INPUTS_CREATED, result.Location);
        }

        [Fact]
        public void CreateInputAdvisorInputsForObjective()
        {
            int projectID = 1;
            int resourceID = 1;

            var projectService = new Mock<IProjectService>();

            projectService.Setup(service => service.IsProjectIDExistsForResourceID(projectID, resourceID))
                       .Returns(true);

            projectService.Setup(service => service.ValidateInputAdvisorJson(InputAdvisorConstants.PAGE_OBJECTIVE, inputAdvisorInputs[3].Object));

            projectService.Setup(service => service.CreateInputAdvisorInputs(inputAdvisorInputs[3]))
                       .Returns(inputAdvisorInputs[3]);

            var controller = new InputAdvisorController(projectService.Object);

            // Act
            var values = controller.CreateInputAdvisorInputs(inputAdvisorInputs[3], InputAdvisorConstants.PAGE_OBJECTIVE);
            var result = values as CreatedResult;

            //Assert
            Assert.Equal(201, result.StatusCode);
            Assert.Equal(ResponseMessages.INPUT_ADVISOR_INPUTS_CREATED, result.Location);
        }

        [Fact]
        public void CreateInputAdvisorInputsForPopulation()
        {
            int projectID = 1;
            int resourceID = 1;

            var projectService = new Mock<IProjectService>();

            projectService.Setup(service => service.IsProjectIDExistsForResourceID(projectID, resourceID))
                       .Returns(true);

            projectService.Setup(service => service.ValidateInputAdvisorJson(InputAdvisorConstants.PAGE_POPULATION, inputAdvisorInputs[3].Object));

            projectService.Setup(service => service.CreateInputAdvisorInputs(inputAdvisorInputs[3]))
                       .Returns(inputAdvisorInputs[3]);

            var controller = new InputAdvisorController(projectService.Object);

            // Act
            var values = controller.CreateInputAdvisorInputs(inputAdvisorInputs[3], InputAdvisorConstants.PAGE_POPULATION);
            var result = values as CreatedResult;

            //Assert
            Assert.Equal(201, result.StatusCode);
            Assert.Equal(ResponseMessages.INPUT_ADVISOR_INPUTS_CREATED, result.Location);
        }

        [Fact]
        public void CreateInputAdvisorInputsForEnrollment()
        {
            int projectID = 1;
            int resourceID = 1;

            var projectService = new Mock<IProjectService>();

            projectService.Setup(service => service.IsProjectIDExistsForResourceID(projectID, resourceID))
                       .Returns(true);

            projectService.Setup(service => service.ValidateInputAdvisorJson(InputAdvisorConstants.PAGE_ENROLLMENT, inputAdvisorInputs[3].Object));

            projectService.Setup(service => service.CreateInputAdvisorInputs(inputAdvisorInputs[3]))
                       .Returns(inputAdvisorInputs[3]);

            var controller = new InputAdvisorController(projectService.Object);

            // Act
            var values = controller.CreateInputAdvisorInputs(inputAdvisorInputs[3], InputAdvisorConstants.PAGE_ENROLLMENT);
            var result = values as CreatedResult;

            //Assert
            Assert.Equal(201, result.StatusCode);
            Assert.Equal(ResponseMessages.INPUT_ADVISOR_INPUTS_CREATED, result.Location);
        }

        [Fact]
        public void CreateInputAdvisorInputsForOperationalCost()
        {
            int projectID = 1;
            int resourceID = 1;

            var projectService = new Mock<IProjectService>();

            projectService.Setup(service => service.IsProjectIDExistsForResourceID(projectID, resourceID))
                       .Returns(true);

            projectService.Setup(service => service.ValidateInputAdvisorJson(InputAdvisorConstants.PAGE_OPERATIONAL_COST, inputAdvisorInputs[3].Object));

            projectService.Setup(service => service.CreateInputAdvisorInputs(inputAdvisorInputs[3]))
                       .Returns(inputAdvisorInputs[3]);

            var controller = new InputAdvisorController(projectService.Object);

            // Act
            var values = controller.CreateInputAdvisorInputs(inputAdvisorInputs[3], InputAdvisorConstants.PAGE_OPERATIONAL_COST);
            var result = values as CreatedResult;

            //Assert
            Assert.Equal(201, result.StatusCode);
            Assert.Equal(ResponseMessages.INPUT_ADVISOR_INPUTS_CREATED, result.Location);
        }

        [Fact]
        public void CreateInputAdvisorInputsForMarketAccess()
        {
            int projectID = 1;
            int resourceID = 1;

            var projectService = new Mock<IProjectService>();

            projectService.Setup(service => service.IsProjectIDExistsForResourceID(projectID, resourceID))
                       .Returns(true);

            projectService.Setup(service => service.ValidateInputAdvisorJson(InputAdvisorConstants.PAGE_MARKET_ACCESS, inputAdvisorInputs[3].Object));

            projectService.Setup(service => service.CreateInputAdvisorInputs(inputAdvisorInputs[3]))
                       .Returns(inputAdvisorInputs[3]);

            var controller = new InputAdvisorController(projectService.Object);

            // Act
            var values = controller.CreateInputAdvisorInputs(inputAdvisorInputs[3], InputAdvisorConstants.PAGE_MARKET_ACCESS);
            var result = values as CreatedResult;

            //Assert
            Assert.Equal(201, result.StatusCode);
            Assert.Equal(ResponseMessages.INPUT_ADVISOR_INPUTS_CREATED, result.Location);
        }

        [Fact]
        public void CreateInputAdvisorInputsForDesign()
        {
            int projectID = 1;
            int resourceID = 1;

            var projectService = new Mock<IProjectService>();

            projectService.Setup(service => service.IsProjectIDExistsForResourceID(projectID, resourceID))
                       .Returns(true);

            projectService.Setup(service => service.ValidateInputAdvisorJson(InputAdvisorConstants.PAGE_DESIGN, inputAdvisorInputs[3].Object));

            projectService.Setup(service => service.CreateInputAdvisorInputs(inputAdvisorInputs[3]))
                       .Returns(inputAdvisorInputs[3]);

            var controller = new InputAdvisorController(projectService.Object);

            // Act
            var values = controller.CreateInputAdvisorInputs(inputAdvisorInputs[3], InputAdvisorConstants.PAGE_DESIGN);
            var result = values as CreatedResult;

            //Assert
            Assert.Equal(201, result.StatusCode);
            Assert.Equal(ResponseMessages.INPUT_ADVISOR_INPUTS_CREATED, result.Location);
        }

        [Fact]
        public void GetStatisticalEngines()
        {
            //Arrange
            List<StatisticalEngines> statisticalEngines = InputAdvisorInputs.statisticalEngineList;

            var projectService = new Mock<IProjectService>();
            projectService.Setup(service => service.GetStatisticalEngines())
                        .Returns(statisticalEngines);

            var controller = new InputAdvisorController(projectService.Object);

            // Act
            var values = controller.GetStatisticalEngines();
            var result = values.Result as OkObjectResult;

            //Assert
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(statisticalEngines, result.Value);
        }

        [Fact]
        public void GetStatisticalEngineDetails()
        {
            //Arrange
            StatisticalEngineDetails statisticalEngineDetails = InputAdvisorInputs.statisticalEngineDetail;

            var projectService = new Mock<IProjectService>();
            projectService.Setup(service => service.GetStatisticalEngineDetails("Fixed Sample", "1.0.0"))
                        .Returns(statisticalEngineDetails);

            var controller = new InputAdvisorController(projectService.Object);

            // Act
            var values = controller.GetStatisticalEngineDetails("Fixed Sample", "1.0.0");
            var result = values.Result as OkObjectResult;

            //Assert
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(statisticalEngineDetails, result.Value);
        }
    }
}
