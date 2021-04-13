using AutoMapper;
using MetricsManager.Client;
using MetricsManager.Controllers;
using MetricsManager.DAL.Interfaces;
using MetricsManager.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xunit;

namespace MetricsManagerTests
{
    public class CpuMetricsControllersTest
    {
        private CpuMetricsController controller;
        private Mock<ILogger<CpuMetricsController>> loggerMock;
        private Mock<ICpuMetricsRepository> repositoryMock;
        private Mock<IMapper> mapperMock;
        private Mock<IConfiguration> configurationMock;
        private Mock<IHttpClientFactory> httpClientFactoryMock;
        private Mock<IMetricsAgentClient> metricsAgentClientMock;

        public CpuMetricsControllersTest()
        {
            loggerMock = new Mock<ILogger<CpuMetricsController>>();
            repositoryMock = new Mock<ICpuMetricsRepository>();
            mapperMock = new Mock<IMapper>();
            configurationMock = new Mock<IConfiguration>();
            httpClientFactoryMock = new Mock<IHttpClientFactory>();
            controller = new CpuMetricsController(
                loggerMock.Object, 
                repositoryMock.Object, 
                mapperMock.Object, 
                configurationMock.Object,
                httpClientFactoryMock.Object,
                metricsAgentClientMock.Object);
        }

        [Fact]
        public void GetCpuMetricsFromAgent_ReturnsOk()
        {
            repositoryMock.Setup(repository => repository.GetByTimePeriodSorted(It.IsAny<int>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()))
                .Returns(new List<CpuMetric>());
            //Arrange
            var agentId = 1;
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);
            //Act
            var result = controller.GetMetricsFromAgent(agentId, fromTime, toTime);
            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }

    public class DotNetMetricsControllerTest
    {
        private DotNetMetricsController controller;
        private Mock<ILogger<DotNetMetricsController>> loggerMock;

        public DotNetMetricsControllerTest()
        {
            loggerMock = new Mock<ILogger<DotNetMetricsController>>();
            controller = new DotNetMetricsController(loggerMock.Object);
        }

        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            //Arrange
            var agentId = 1;
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);
            //Act
            var result = controller.GetMetricsFromAgent(agentId, fromTime, toTime);
            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }

    public class HddMetricsControllerTest
    {
        private HddMetricsController controller;
        private Mock<ILogger<HddMetricsController>> loggerMock;

        public HddMetricsControllerTest()
        {
            loggerMock = new Mock<ILogger<HddMetricsController>>();
            controller = new HddMetricsController(loggerMock.Object);
        }

        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            //Arrange
            var agentId = 1;
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);
            //Act
            var result = controller.GetMetricsFromAgent(agentId, fromTime, toTime);
            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }

    public class NetworkMetricsControllerTest
    {
        private NetworkMetricsController controller;
        private Mock<ILogger<NetworkMetricsController>> loggerMock;

        public NetworkMetricsControllerTest()
        {
            loggerMock = new Mock<ILogger<NetworkMetricsController>>();
            controller = new NetworkMetricsController(loggerMock.Object);
        }

        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            //Arrange
            var agentId = 1;
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);
            //Act
            var result = controller.GetMetricsFromAgent(agentId, fromTime, toTime);
            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }

    public class RamMetricsControllerTest
    {
        private RamMetricsController controller;
        private Mock<ILogger<RamMetricsController>> loggerMock;

        public RamMetricsControllerTest()
        {
            loggerMock = new Mock<ILogger<RamMetricsController>>();
            controller = new RamMetricsController(loggerMock.Object);
        }

        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            //Arrange
            var agentId = 1;
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);
            //Act
            var result = controller.GetMetricsFromAgent(agentId, fromTime, toTime);
            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
