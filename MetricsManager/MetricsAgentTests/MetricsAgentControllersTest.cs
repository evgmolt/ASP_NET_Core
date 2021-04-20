using AutoMapper;
using MetricsAgent.Controllers;
using MetricsAgent.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace MetricsAgentTests
{
    public class CpuMetricsAgentControllersTest
    {
        private CpuMetricsController controller;
        private Mock<ILogger<CpuMetricsController>> loggerMock;
        private Mock<ICpuMetricsRepository> repositoryMock;
        private Mock<IMapper> mapperMock;
        private Mock<IConfiguration> configurationMock;

        public CpuMetricsAgentControllersTest()
        {
            loggerMock = new Mock<ILogger<CpuMetricsController>>();
            repositoryMock = new Mock<ICpuMetricsRepository>();
            mapperMock = new Mock<IMapper>();
            configurationMock = new Mock<IConfiguration>();
            controller = new CpuMetricsController(loggerMock.Object, repositoryMock.Object, mapperMock.Object, configurationMock.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            repositoryMock.Setup(repository =>
            repository.Create(It.IsAny<CpuMetric>())).Verifiable();
//            repository.Create(It.Is(metric => metric.Value == 50 && metric.Time = 1);
            var result = controller.Create(new MetricsAgent.Requests.CpuMetricCreateRequest
            {
                Time = 1,
                Value = 50
            });
            repositoryMock.Verify(repository => repository.Create(It.IsAny<CpuMetric>()), Times.AtMostOnce());
        }
    }

    public class DotNetMetricsAgentControllersTest
    {
        private DotNetMetricsController controller;
        private Mock<ILogger<DotNetMetricsController>> loggerMock;
        private Mock<IDotNetMetricsRepository> repositoryMock;
        private Mock<IMapper> mapperMock;
        private Mock<IConfiguration> configurationMock;

        public DotNetMetricsAgentControllersTest()
        {
            loggerMock = new Mock<ILogger<DotNetMetricsController>>();
            repositoryMock = new Mock<IDotNetMetricsRepository>();
            mapperMock = new Mock<IMapper>();
            configurationMock = new Mock<IConfiguration>();
            controller = new DotNetMetricsController(loggerMock.Object, repositoryMock.Object, mapperMock.Object, configurationMock.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            repositoryMock.Setup(repository =>
            repository.Create(It.IsAny<DotNetMetric>())).Verifiable();
            var result = controller.Create(new MetricsAgent.Requests.DotNetMetricCreateRequest
            {
                Time = 1,
                Value = 50
            });
            repositoryMock.Verify(repository => repository.Create(It.IsAny<DotNetMetric>()), Times.AtMostOnce());
        }
    }

    public class HddMetricsAgentControllersTest
    {
        private HddMetricsController controller;
        private Mock<ILogger<HddMetricsController>> loggerMock;
        private Mock<IHddMetricsRepository> repositoryMock;
        private Mock<IMapper> mapperMock;
        private Mock<IConfiguration> configurationMock;

        public HddMetricsAgentControllersTest()
        {
            loggerMock = new Mock<ILogger<HddMetricsController>>();
            repositoryMock = new Mock<IHddMetricsRepository>();
            mapperMock = new Mock<IMapper>();
            configurationMock = new Mock<IConfiguration>();
            controller = new HddMetricsController(loggerMock.Object, repositoryMock.Object, mapperMock.Object, configurationMock.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            repositoryMock.Setup(repository =>
            repository.Create(It.IsAny<HddMetric>())).Verifiable();
            var result = controller.Create(new MetricsAgent.Requests.HddMetricCreateRequest
            {
                Time = 1,
                Value = 50
            });
            repositoryMock.Verify(repository => repository.Create(It.IsAny<HddMetric>()), Times.AtMostOnce());
        }
    }

    public class NetworkMetricsAgentControllersTest
    {
        private NetworkMetricsController controller;
        private Mock<ILogger<NetworkMetricsController>> loggerMock;
        private Mock<INetworkMetricsRepository> repositoryMock;
        private Mock<IMapper> mapperMock;
        private Mock<IConfiguration> configurationMock;

        public NetworkMetricsAgentControllersTest()
        {
            loggerMock = new Mock<ILogger<NetworkMetricsController>>();
            repositoryMock = new Mock<INetworkMetricsRepository>();
            mapperMock = new Mock<IMapper>();
            configurationMock = new Mock<IConfiguration>();
            controller = new NetworkMetricsController(loggerMock.Object, repositoryMock.Object, mapperMock.Object, configurationMock.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            repositoryMock.Setup(repository =>
            repository.Create(It.IsAny<NetworkMetric>())).Verifiable();
            var result = controller.Create(new MetricsAgent.Requests.NetworkMetricCreateRequest
            {
                Time = 1,
                Value = 50
            });
            repositoryMock.Verify(repository => repository.Create(It.IsAny<NetworkMetric>()), Times.AtMostOnce());
        }
    }

    public class RamMetricsAgentControllersTest
    {
        private RamMetricsController controller;
        private Mock<ILogger<RamMetricsController>> loggerMock;
        private Mock<IRamMetricsRepository> repositoryMock;
        private Mock<IMapper> mapperMock;
        private Mock<IConfiguration> configurationMock;
        
        public RamMetricsAgentControllersTest()
        {
            loggerMock = new Mock<ILogger<RamMetricsController>>();
            repositoryMock = new Mock<IRamMetricsRepository>();
            mapperMock = new Mock<IMapper>();
            configurationMock = new Mock<IConfiguration>();
            controller = new RamMetricsController(loggerMock.Object, repositoryMock.Object, mapperMock.Object, configurationMock.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            repositoryMock.Setup(repository =>
            repository.Create(It.IsAny<RamMetric>())).Verifiable();
            var result = controller.Create(new MetricsAgent.Requests.RamMetricCreateRequest
            {
                Time = 1,
                Value = 50
            });
            repositoryMock.Verify(repository => repository.Create(It.IsAny<RamMetric>()), Times.AtMostOnce());
        }
    }
}
