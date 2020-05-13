using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjectManagement.Api.Controllers;
using ProjectManager.Api.Test.TestData;
using ProjectManager.Models;
using ProjectManager.Service.Interfaces;
using System.Collections.Generic;
using Xunit;

namespace ProjectManager.Api.Test
{
    public class CurrencyControllerTest
    {
        [Fact]
        public void GetCurrency()
        {
            //Arrange
            List<Currency> currencies = Currencies.CurrencyList;

            var projectService = new Mock<IProjectService>();

            projectService.Setup(service => service.GetCurrencies())
                        .Returns(currencies);
            var controller = new CurrencyController(projectService.Object);

            // Act
            var values = controller.GetCurrencies();
            var result = values.Result as OkObjectResult;


            //Assert
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(currencies, result.Value);
        }
    }
}