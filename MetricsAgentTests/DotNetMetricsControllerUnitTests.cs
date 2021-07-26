using MetricsAgent.Controllers;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.DAL.Models;
using MetricsAgent.Core;
using Moq;
using System;
using Xunit;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using AutoMapper;

namespace MetricsAgentTests
{
    public class DotNetMetricsControllerUnitTests
    {
        private DotNetMetricsController controller;
        private Mock<IDotNetMetricsRepository> mockRepository;
        private readonly Mock<ILogger<DotNetMetricsController>> mockLogger;

        public DotNetMetricsControllerUnitTests()
        {
            mockRepository = new Mock<IDotNetMetricsRepository>();
            mockLogger = new Mock<ILogger<DotNetMetricsController>>();
            var mapperConfiguration = new MapperConfiguration(mapper => mapper.AddProfile(new MapperProfile()));
            var mapper = mapperConfiguration.CreateMapper();
            controller = new DotNetMetricsController(mockLogger.Object, mockRepository.Object, mapper);
        }

        [Fact]
        public void GetByTimePeriod_ShouldCall_GetByTimePeriod_From_Repository()
        {
            mockRepository.Setup(repository => repository.GetByTimePeriod(It.IsAny<long>(), It.IsAny<long>())).Returns(new List<DotNetMetric>());
            var result = controller.GetMetrics(DateTimeOffset.UtcNow, DateTimeOffset.UtcNow);
            mockRepository.Verify(repository => repository.GetByTimePeriod(It.IsAny<long>(), It.IsAny<long>()), Times.AtMostOnce());
        }
    }
}
