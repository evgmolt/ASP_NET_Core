using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsManagerTests
{
    public class MetricsControllerTest
    {
        private CpuMetricsController controller;
        public MetricsControllerTest()
        {
            controller = new CpuMetricsController();
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
        public DotNetMetricsControllerTest()
        {
            controller = new DotNetMetricsController();
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
        public HddMetricsControllerTest()
        {
            controller = new HddMetricsController();
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
        public NetworkMetricsControllerTest()
        {
            controller = new NetworkMetricsController();
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
        public RamMetricsControllerTest()
        {
            controller = new RamMetricsController();
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
