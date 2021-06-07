using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsManagerTests
{
    public class NetworkMetricsControllerUnitTests
    {
        private NetworkMetricsController controller;
        private TimeSpan fromTime;
        private TimeSpan toTime;

        public NetworkMetricsControllerUnitTests()
        {
            controller = new NetworkMetricsController();
            fromTime = TimeSpan.FromSeconds(0);
            toTime = TimeSpan.FromSeconds(100);
        }

        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            //Arrange

            //Act
            var result = controller.GetMetrics(fromTime, toTime);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
