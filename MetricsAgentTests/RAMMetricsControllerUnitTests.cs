using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using Moq;
using System;
using Xunit;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace MetricsAgentTests
    {
        public class RamMetricsControllerUnitTests
        {
            private RamMetricsController controller;
            private Mock<IRamMetricsRepository> mockRepository;
            private readonly Mock<ILogger<RamMetricsController>> mockLogger;

            public RamMetricsControllerUnitTests()
            {
                mockRepository = new Mock<IRamMetricsRepository>();
                mockLogger = new Mock<ILogger<RamMetricsController>>();
                controller = new RamMetricsController(mockLogger.Object, mockRepository.Object);
            }

            [Fact]
            public void GetByTimePeriod_ShouldCall_GetByTimePeriod_From_Repository()
            {
                mockRepository.Setup(repository => repository.GetByTimePeriod(It.IsAny<long>(), It.IsAny<long>())).Returns(new List<RamMetric>());
            var result = controller.GetMetrics(DateTimeOffset.UtcNow, DateTimeOffset.UtcNow);
                mockRepository.Verify(repository => repository.GetByTimePeriod(It.IsAny<long>(), It.IsAny<long>()), Times.AtMostOnce());
            }
        }
    }