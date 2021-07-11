using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using Moq;
using System;
using Xunit;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace MetricsAgentTests
{
    public class HddMetricsControllerUnitTests
    {
        private HddMetricsController controller;
        private Mock<IHddMetricsRepository> mockRepository;
        private readonly Mock<ILogger<HddMetricsController>> mockLogger;

        public HddMetricsControllerUnitTests()
        {
            mockRepository = new Mock<IHddMetricsRepository>();
            mockLogger = new Mock<ILogger<HddMetricsController>>();
            controller = new HddMetricsController(mockLogger.Object, mockRepository.Object);
        }

        [Fact]
        public void GetByTimePeriod_ShouldCall_GetByTimePeriod_From_Repository()
        {
            mockRepository.Setup(repository => repository.GetByTimePeriod(It.IsAny<long>(), It.IsAny<long>())).Returns(new List<HddMetric>());
            var result = controller.GetMetrics(DateTimeOffset.UtcNow, DateTimeOffset.UtcNow);
            mockRepository.Verify(repository => repository.GetByTimePeriod(It.IsAny<long>(), It.IsAny<long>()), Times.AtMostOnce());
        }
    }
}