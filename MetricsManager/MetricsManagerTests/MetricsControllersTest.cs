using AutoFixture;
using AutoMapper;
using MetricsManager;
using MetricsManager.Client;
using MetricsManager.Controllers;
using MetricsManager.DAL.Interfaces;
using MetricsManager.DAL.Models;
using MetricsManager.Responses;
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
        private readonly CpuMetricsController _controller;
        private readonly Mock<ILogger<CpuMetricsController>> _loggerMock;
        private readonly Mock<ICpuMetricsRepository> _repositoryMock;

        public CpuMetricsControllersTest()
        {
            _loggerMock = new Mock<ILogger<CpuMetricsController>>();
            _repositoryMock = new Mock<ICpuMetricsRepository>();
            var config = new MapperConfiguration(mp => mp.AddProfile(new MapperProfile()));
            IMapper mapper = config.CreateMapper();
            _controller = new CpuMetricsController(_loggerMock.Object, _repositoryMock.Object, mapper);
        }

        [Fact]
        public void GetCpuMetricsFromAgent_ReturnsOk()
        {
            var fixture = new Fixture();
            var returnLins = fixture.Create<List<CpuMetric>>();

            _repositoryMock.Setup(repository => repository.GetByTimePeriodSorted(It.IsAny<int>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()))
                .Returns((IList<CpuMetric>)returnLins);

            var agentId = 1;
            var fromTime = DateTimeOffset.Now - new TimeSpan(0, 0, 100);
            var toTime = DateTimeOffset.Now;
            var percentile = 0;
            var result = (OkObjectResult)_controller.GetMetricsByPercentileFromAgent(agentId, fromTime, toTime, percentile);
            var actionResult = (int)result.Value;
            _repositoryMock.Verify(repository => repository.GetByTimePeriodSorted(It.IsAny<int>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()));
            _ = Assert.IsAssignableFrom<IActionResult>(result);
            Assert.IsAssignableFrom<int>(result.Value);
        }
    }

    public class DotNetMetricsControllersTest
    {
        private readonly DotNetMetricsController _controller;
        private readonly Mock<ILogger<DotNetMetricsController>> _loggerMock;
        private readonly Mock<IDotNetMetricsRepository> _repositoryMock;

        public DotNetMetricsControllersTest()
        {
            _loggerMock = new Mock<ILogger<DotNetMetricsController>>();
            _repositoryMock = new Mock<IDotNetMetricsRepository>();
            var config = new MapperConfiguration(mp => mp.AddProfile(new MapperProfile()));
            IMapper mapper = config.CreateMapper();
            _controller = new DotNetMetricsController(_loggerMock.Object, _repositoryMock.Object, mapper);
        }

        [Fact]
        public void GetDotNetMetricsFromAgent_ReturnsOk()
        {
            var fixture = new Fixture();
            var returnList = fixture.Create<List<DotNetMetric>>();

            _repositoryMock.Setup(repository => repository.GetByTimePeriod(It.IsAny<int>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()))
                .Returns((IList<DotNetMetric>)returnList);

            var agentId = 1;
            var fromTime = DateTimeOffset.Now - new TimeSpan(0, 0, 100);
            var toTime = DateTimeOffset.Now;
            var result = (OkObjectResult)_controller.GetMetricsFromAgent(agentId, fromTime, toTime);
            var actualResult = (List<DotNetMetric>)result.Value;
            _repositoryMock.Verify(repository => repository.GetByTimePeriod(It.IsAny<int>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()));
            _ = Assert.IsAssignableFrom<IActionResult>(result);
            Assert.Equal(returnList[0].Id, actualResult[0].Id);
        }
    }

    public class HddMetricsControllersTest
    {
        private readonly HddMetricsController _controller;
        private readonly Mock<ILogger<HddMetricsController>> _loggerMock;
        private readonly Mock<IHddMetricsRepository> _repositoryMock;

        public HddMetricsControllersTest()
        {
            _loggerMock = new Mock<ILogger<HddMetricsController>>();
            _repositoryMock = new Mock<IHddMetricsRepository>();
            var config = new MapperConfiguration(mp => mp.AddProfile(new MapperProfile()));
            IMapper mapper = config.CreateMapper();
            _controller = new HddMetricsController(_loggerMock.Object, _repositoryMock.Object, mapper);
        }

        [Fact]
        public void GetHddMetricsFromAgent_ReturnsOk()
        {
            var fixture = new Fixture();
            var returnList = fixture.Create<List<HddMetric>>();

            _repositoryMock.Setup(repository => repository.GetByTimePeriod(It.IsAny<int>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()))
                .Returns((IList<HddMetric>)returnList);

            var agentId = 1;
            var fromTime = DateTimeOffset.Now - new TimeSpan(0, 0, 100);
            var toTime = DateTimeOffset.Now;
            var result = (OkObjectResult)_controller.GetMetricsFromAgent(agentId, fromTime, toTime);
            var actualResult = (List<HddMetric>)result.Value;
            _repositoryMock.Verify(repository => repository.GetByTimePeriod(It.IsAny<int>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()));
            _ = Assert.IsAssignableFrom<IActionResult>(result);
            Assert.Equal(returnList[0].Id, actualResult[0].Id);
        }
    }

    public class NetworkMetricsControllersTest
    {
        private readonly NetworkMetricsController _controller;
        private readonly Mock<ILogger<NetworkMetricsController>> _loggerMock;
        private readonly Mock<INetworkMetricsRepository> _repositoryMock;

        public NetworkMetricsControllersTest()
        {
            _loggerMock = new Mock<ILogger<NetworkMetricsController>>();
            _repositoryMock = new Mock<INetworkMetricsRepository>();
            var config = new MapperConfiguration(mp => mp.AddProfile(new MapperProfile()));
            IMapper mapper = config.CreateMapper();
            _controller = new NetworkMetricsController(_loggerMock.Object, _repositoryMock.Object, mapper);
        }

        [Fact]
        public void GetNetworkMetricsFromAgent_ReturnsOk()
        {
            var fixture = new Fixture();
            var returnList = fixture.Create<List<NetworkMetric>>();

            _repositoryMock.Setup(repository => repository.GetByTimePeriod(It.IsAny<int>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()))
                .Returns((IList<NetworkMetric>)returnList);

            var agentId = 1;
            var fromTime = DateTimeOffset.Now - new TimeSpan(0, 0, 100);
            var toTime = DateTimeOffset.Now;
            var result = (OkObjectResult)_controller.GetMetricsFromAgent(agentId, fromTime, toTime);
            var actualResult = (List<NetworkMetric>)result.Value;
            _repositoryMock.Verify(repository => repository.GetByTimePeriod(It.IsAny<int>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()));
            _ = Assert.IsAssignableFrom<IActionResult>(result);
            Assert.Equal(returnList[0].Id, actualResult[0].Id);
        }
    }

    public class RamMetricsControllersTest
    {
        private readonly RamMetricsController _controller;
        private readonly Mock<ILogger<RamMetricsController>> _loggerMock;
        private readonly Mock<IRamMetricsRepository> _repositoryMock;

        public RamMetricsControllersTest()
        {
            _loggerMock = new Mock<ILogger<RamMetricsController>>();
            _repositoryMock = new Mock<IRamMetricsRepository>();
            var config = new MapperConfiguration(mp => mp.AddProfile(new MapperProfile()));
            IMapper mapper = config.CreateMapper();
            _controller = new RamMetricsController(_loggerMock.Object, _repositoryMock.Object, mapper);
        }

        [Fact]
        public void GetRamMetricsFromAgent_ReturnsOk()
        {
            var fixture = new Fixture();
            var returnList = fixture.Create<List<RamMetric>>();

            _repositoryMock.Setup(repository => repository.GetByTimePeriod(It.IsAny<int>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()))
                .Returns((IList<RamMetric>)returnList);

            var agentId = 1;
            var fromTime = DateTimeOffset.Now - new TimeSpan(0, 0, 100);
            var toTime = DateTimeOffset.Now;
            var result = (OkObjectResult)_controller.GetMetricsFromAgent(agentId, fromTime, toTime);
            var actualResult = (List<RamMetric>)result.Value;
            _repositoryMock.Verify(repository => repository.GetByTimePeriod(It.IsAny<int>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()));
            _ = Assert.IsAssignableFrom<IActionResult>(result);
            Assert.Equal(returnList[0].Id, actualResult[0].Id);
        }
    }
}
