using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace MetricsManagerTests
{
    public class CpuMetricsControllersTest
    {
        private CpuMetricsController controller;
        private Mock<ILogger<CpuMetricsController>> loggerMock;

        public CpuMetricsControllersTest()
        {
            loggerMock = new Mock<ILogger<CpuMetricsController>>();
            controller = new CpuMetricsController(loggerMock.Object);
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
