using AutoMapper;
using Enums;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.Requests;
using MetricsAgent.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/cpu")]
    [ApiController]
    public class CpuMetricsController : ControllerBase
    {
        private ICpuMetricsRepository _repository;
        private readonly ILogger<CpuMetricsController> _logger;
        private readonly IMapper _mapper;
        private IConfiguration _configuration;

        public CpuMetricsController(
            ILogger<CpuMetricsController> logger, 
            ICpuMetricsRepository repository, 
            IMapper mapper,
            IConfiguration configuration)
        {
            this._configuration = configuration;
            this._repository = repository;
            this._logger = logger;
            this._mapper = mapper;
            _logger.LogInformation(1, "NLog встроен в CpuMetricsController");
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CpuMetricCreateRequest request)
        {
            _repository.Create(new CpuMetric
            {
                Time = request.Time,
                Value = request.Value
            });
            return Ok();
        }

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetrics(
            [FromRoute] DateTimeOffset fromTime,
            [FromRoute] DateTimeOffset toTime)
        {
            _logger.LogInformation($"GetMetrics from:{fromTime} to:{toTime}");

            var metrics = _repository.GetByTimePeriod(fromTime, toTime);
            var response = new CpuMetricsResponse()
            {
                Metrics = new List<CpuMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<CpuMetricDto>(metric));
            }

            return Ok(response);
        }

        [HttpGet("getlast")]
        public IActionResult GetLastMetric()
        {
            _logger.LogInformation($"GetLastMetric");

            int metricsInterval = _configuration.GetValue<int>("GetMetricsInterval");
            metricsInterval = metricsInterval + metricsInterval / 2;
            TimeSpan timeShift = new TimeSpan(0, 0, metricsInterval);
            DateTimeOffset timeNow = DateTimeOffset.Now;
            var metrics = _repository.GetByTimePeriod(timeNow - timeShift, timeNow);
            var response = new CpuMetricsResponse()
            {
                Metrics = new List<CpuMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<CpuMetricDto>(metric));
            }

            return Ok(response);
        }


        [HttpGet("from/{fromTime}/to/{toTime}/percentiles/{percentile}")]
        public IActionResult GetMetricsByPercentile(
            [FromRoute] int fromTime,
            [FromRoute] int toTime,
            [FromRoute] Percentile percentile)
        {
            _logger.LogInformation($"GetMetricsByPercentile from:{fromTime} to:{toTime} percentiles:{percentile}");

            return Ok();
        }
    }
}
