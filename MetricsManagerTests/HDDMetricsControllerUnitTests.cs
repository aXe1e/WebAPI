using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsManagerTests
{
    public class HDDMetricsControllerUnitTests
    {
        private HddMetricsController controller;
        private int agentId;

        public HDDMetricsControllerUnitTests()
        {
            controller = new HddMetricsController();
            agentId = 1;
        }

        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            //Arrange

            //Act
            var result = controller.GetMetricsFromAgent(agentId);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void GetMetricsFromAllCluster_ReturnsOk()
        {
            //Arrange

            //Act
            var result = controller.GetMetricsFromAllCluster();

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
