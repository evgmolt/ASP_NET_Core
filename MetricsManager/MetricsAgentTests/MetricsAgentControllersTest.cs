using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Xunit;

namespace MetricsAgentTests
{
    public class CpuMetricsAgentControllersTest
    {
        private CpuMetricsController controller;
        private readonly ILogger<CpuMetricsController> _logger;

        public CpuMetricsAgentControllersTest(ILogger<CpuMetricsController> logger)
        {
            _logger = logger;
            controller = new CpuMetricsController(_logger);
        }
        [Fact]
        public void GetMetrics_ReturnsOk()
        {
            //Arrange
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);
            //Act
            var result = controller.GetMetrics(fromTime, toTime);
            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }

    public class DotNetMetricsAgentControllersTest
    {
        private DotNetMetricsController controller;
        private readonly ILogger<DotNetMetricsController> _logger;

        public DotNetMetricsAgentControllersTest(ILogger<DotNetMetricsController> logger)
        {
            _logger = logger;
            controller = new DotNetMetricsController(_logger);
        }
        [Fact]
        public void GetMetrics_ReturnsOk()
        {
            //Arrange
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);
            //Act
            var result = controller.GetMetrics(fromTime, toTime);
            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }

    public class HddMetricsAgentControllersTest
    {
        private HddMetricsController controller;
        private readonly ILogger<HddMetricsController> _logger;

        public HddMetricsAgentControllersTest(ILogger<HddMetricsController> logger)
        {
            _logger = logger;
            controller = new HddMetricsController(_logger);
        }
        [Fact]
        public void GetMetrics_ReturnsOk()
        {
            //Arrange
            //Act
            var result = controller.GetMetrics();
            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }

    public class NetworkMetricsAgentControllersTest
    {
        private NetworkMetricsController controller;
        private readonly ILogger<NetworkMetricsController> _logger;

        public NetworkMetricsAgentControllersTest(ILogger<NetworkMetricsController> logger)
        {
            _logger = logger;
            controller = new NetworkMetricsController(_logger);
        }
        [Fact]
        public void GetMetrics_ReturnsOk()
        {
            //Arrange
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);
            //Act
            var result = controller.GetMetrics(fromTime, toTime);
            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }

    public class RamMetricsAgentControllersTest
    {
        private RamMetricsController controller;
        private readonly ILogger<RamMetricsController> _logger;

        public RamMetricsAgentControllersTest(ILogger<RamMetricsController> logger)
        {
            _logger = logger;
            controller = new RamMetricsController(_logger);
        }
        [Fact]
        public void GetMetricsa_ReturnsOk()
        {
            //Arrange
            //Act
            var result = controller.GetMetrics();
            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
