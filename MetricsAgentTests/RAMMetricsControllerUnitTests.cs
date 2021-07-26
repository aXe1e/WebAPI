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
        public class RamMetricsControllerUnitTests
        {
            private RamMetricsController controller;
            private Mock<IRamMetricsRepository> mockRepository;
            private readonly Mock<ILogger<RamMetricsController>> mockLogger;

            public RamMetricsControllerUnitTests()
            {
                mockRepository = new Mock<IRamMetricsRepository>();
                mockLogger = new Mock<ILogger<RamMetricsController>>();
                var mapperConfiguration = new MapperConfiguration(mapper => mapper.AddProfile(new MapperProfile()));
                var mapper = mapperConfiguration.CreateMapper();
                controller = new RamMetricsController(mockLogger.Object, mockRepository.Object, mapper);
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