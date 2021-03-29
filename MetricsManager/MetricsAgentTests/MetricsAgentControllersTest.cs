using MetricsAgent.Controllers;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace MetricsAgentTests
{
    public class CpuMetricsAgentControllersTest
    {
        private CpuMetricsController controller;
        private Mock<ILogger<CpuMetricsController>> mock1;
        private Mock<ICpuMetricsRepository> mock2;
        public CpuMetricsAgentControllersTest()
        {
            mock1 = new Mock<ILogger<CpuMetricsController>>();
            mock2 = new Mock<ICpuMetricsRepository>();
            controller = new CpuMetricsController(mock1.Object, mock2.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            mock2.Setup(repository =>
            repository.Create(It.IsAny<CpuMetric>())).Verifiable();
            var result = controller.Create(new MetricsAgent.Requests.CpuMetricCreateRequest
            {
                Time = 1,
                Value = 50
            });
            mock2.Verify(repository => repository.Create(It.IsAny<CpuMetric>()), Times.AtMostOnce());
        }
    }

    public class DotNetMetricsAgentControllersTest
    {
        private DotNetMetricsController controller;
        private Mock<ILogger<DotNetMetricsController>> mock1;
        private Mock<IDotNetMetricsRepository> mock2;
        public DotNetMetricsAgentControllersTest()
        {
            mock1 = new Mock<ILogger<DotNetMetricsController>>();
            mock2 = new Mock<IDotNetMetricsRepository>();
            controller = new DotNetMetricsController(mock1.Object, mock2.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            mock2.Setup(repository =>
            repository.Create(It.IsAny<DotNetMetric>())).Verifiable();
            var result = controller.Create(new MetricsAgent.Requests.DotNetMetricCreateRequest
            {
                Time = 1,
                Value = 50
            });
            mock2.Verify(repository => repository.Create(It.IsAny<DotNetMetric>()), Times.AtMostOnce());
        }
    }

    public class HddMetricsAgentControllersTest
    {
        private HddMetricsController controller;
        private Mock<ILogger<HddMetricsController>> mock1;
        private Mock<IHddMetricsRepository> mock2;
        public HddMetricsAgentControllersTest()
        {
            mock1 = new Mock<ILogger<HddMetricsController>>();
            mock2 = new Mock<IHddMetricsRepository>();
            controller = new HddMetricsController(mock1.Object, mock2.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            mock2.Setup(repository =>
            repository.Create(It.IsAny<HddMetric>())).Verifiable();
            var result = controller.Create(new MetricsAgent.Requests.HddMetricCreateRequest
            {
                Time = 1,
                Value = 50
            });
            mock2.Verify(repository => repository.Create(It.IsAny<HddMetric>()), Times.AtMostOnce());
        }
    }

    public class NetworkMetricsAgentControllersTest
    {
        private NetworkMetricsController controller;
        private Mock<ILogger<NetworkMetricsController>> mock1;
        private Mock<INetworkMetricsRepository> mock2;
        public NetworkMetricsAgentControllersTest()
        {
            mock1 = new Mock<ILogger<NetworkMetricsController>>();
            mock2 = new Mock<INetworkMetricsRepository>();
            controller = new NetworkMetricsController(mock1.Object, mock2.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            mock2.Setup(repository =>
            repository.Create(It.IsAny<NetworkMetric>())).Verifiable();
            var result = controller.Create(new MetricsAgent.Requests.NetworkMetricCreateRequest
            {
                Time = 1,
                Value = 50
            });
            mock2.Verify(repository => repository.Create(It.IsAny<NetworkMetric>()), Times.AtMostOnce());
        }
    }

    public class RamMetricsAgentControllersTest
    {
        private RamMetricsController controller;
        private Mock<ILogger<RamMetricsController>> mock1;
        private Mock<IRamMetricsRepository> mock2;
        public RamMetricsAgentControllersTest()
        {
            mock1 = new Mock<ILogger<RamMetricsController>>();
            mock2 = new Mock<IRamMetricsRepository>();
            controller = new RamMetricsController(mock1.Object, mock2.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            mock2.Setup(repository =>
            repository.Create(It.IsAny<RamMetric>())).Verifiable();
            var result = controller.Create(new MetricsAgent.Requests.RamMetricCreateRequest
            {
                Time = 1,
                Value = 50
            });
            mock2.Verify(repository => repository.Create(It.IsAny<RamMetric>()), Times.AtMostOnce());
        }
    }
}
