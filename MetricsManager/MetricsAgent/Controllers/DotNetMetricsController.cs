﻿using AutoMapper;
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
    [Route("api/metrics/dotnet")]
    [ApiController]
    public class DotNetMetricsController : ControllerBase
    {
        private IDotNetMetricsRepository _repository;
        private readonly ILogger<DotNetMetricsController> _logger;
        private readonly IMapper _mapper;
        private IConfiguration _configuration;

        public DotNetMetricsController(
            ILogger<DotNetMetricsController> logger, 
            IDotNetMetricsRepository repository, 
            IMapper mapper,
            IConfiguration configuration)
        {
            this._configuration = configuration;
            this._repository = repository;
            this._logger = logger;
            this._mapper = mapper;
            _logger.LogInformation("NLog встроен в DotNetMetricsController");
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] DotNetMetricCreateRequest request)
        {
            _repository.Create(new DotNetMetric
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
            var response = new DotNetMetricsResponse()
            {
                Metrics = new List<DotNetMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<DotNetMetricDto>(metric));
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
            var response = new DotNetMetricsResponse()
            {
                Metrics = new List<DotNetMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<DotNetMetricDto>(metric));
            }

            return Ok(response);
        }

    }
}
