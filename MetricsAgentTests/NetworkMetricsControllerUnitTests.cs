using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using Moq;
using System;
using Xunit;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace MetricsAgentTests
    {
        public class NetworkMetricsControllerUnitTests
    {
            private NetworkMetricsController controller;
            private Mock<INetworkMetricsRepository> mockRepository;
            private readonly Mock<ILogger<NetworkMetricsController>> mockLogger;

            public NetworkMetricsControllerUnitTests()
            {
                mockRepository = new Mock<INetworkMetricsRepository>();
                mockLogger = new Mock<ILogger<NetworkMetricsController>>();
                controller = new NetworkMetricsController(mockLogger.Object, mockRepository.Object);
            }

            [Fact]
            public void GetByTimePeriod_ShouldCall_GetByTimePeriod_From_Repository()
            {
                mockRepository.Setup(repository => repository.GetByTimePeriod(It.IsAny<long>(), It.IsAny<long>())).Returns(new List<NetworkMetric>());
            var result = controller.GetMetrics(DateTimeOffset.UtcNow, DateTimeOffset.UtcNow);
                mockRepository.Verify(repository => repository.GetByTimePeriod(It.IsAny<long>(), It.IsAny<long>()), Times.AtMostOnce());
            }
        }
    }