using AutoMapper;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.Requests;
using MetricsAgent.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Controllers
{
    [Route("api/hddmetrics")]
    [ApiController]
    public class HddMetricsController : ControllerBase
    {
        private IHddMetricsRepository _repository;
        private readonly ILogger<HddMetricsController> _logger;
        private readonly IMapper _mapper;
        private IConfiguration _configuration;

        public HddMetricsController(
            ILogger<HddMetricsController> logger, 
            IHddMetricsRepository repository, 
            IMapper mapper, 
            IConfiguration configuration)
        {
            this._configuration = configuration;
            this._repository = repository;
            this._logger = logger;
            this._mapper = mapper;
            _logger.LogInformation(1, "NLog встроен в HddMetricsController");
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] HddMetricCreateRequest request)
        {
            _repository.Create(new HddMetric
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
            var response = new HddMetricsResponse()
            {
                Metrics = new List<HddMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<HddMetricDto>(metric));
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
            var response = new HddMetricsResponse()
            {
                Metrics = new List<HddMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<HddMetricDto>(metric));
            }

            return Ok(response);
        }
    }
}
