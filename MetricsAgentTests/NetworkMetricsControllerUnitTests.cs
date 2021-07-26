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
        public class NetworkMetricsControllerUnitTests
    {
            private NetworkMetricsController controller;
            private Mock<INetworkMetricsRepository> mockRepository;
            private readonly Mock<ILogger<NetworkMetricsController>> mockLogger;

            public NetworkMetricsControllerUnitTests()
            {
                mockRepository = new Mock<INetworkMetricsRepository>();
                mockLogger = new Mock<ILogger<NetworkMetricsController>>();
                var mapperConfiguration = new MapperConfiguration(mapper => mapper.AddProfile(new MapperProfile()));
                var mapper = mapperConfiguration.CreateMapper();
                controller = new NetworkMetricsController(mockLogger.Object, mockRepository.Object, mapper);
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