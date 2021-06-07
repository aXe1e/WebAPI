using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsManagerTests
{
    public class RAMMetricsControllerUnitTests
    {
        private RamMetricsController controller;
        private int agentId;

        public RAMMetricsControllerUnitTests()
        {
            controller = new RamMetricsController();
        }

        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            //Arrange

            //Act
            var result = controller.GetMetrics();

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
