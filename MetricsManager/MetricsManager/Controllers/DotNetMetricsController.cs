using AutoMapper;
using Enums;
using MetricsManager.DAL.Interfaces;
using MetricsManager.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    [Route("api/dotnetmetrics")]
    [ApiController]
    public class DotNetMetricsController : ControllerBase
    {
        private IDotNetMetricsRepository _repository;
        private readonly ILogger<DotNetMetricsController> _logger;
        private readonly IMapper _mapper;

        public DotNetMetricsController(
            ILogger<DotNetMetricsController> logger,
            IDotNetMetricsRepository repository,
            IMapper mapper)
        {
            this._repository = repository;
            this._logger = logger;
            this._mapper = mapper;
            _logger.LogDebug(1, "NLog встроен в DotNetMetricsController");
        }

        [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent(
            [FromRoute] int agentId,
            [FromRoute] DateTimeOffset fromTime,
            [FromRoute] DateTimeOffset toTime)
        {
            var metrics = _repository.GetByTimePeriod(agentId, fromTime, toTime);
            var response = new DotNetMetricsResponse()
            {
                Metrics = new List<DotNetMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<DotNetMetricDto>(metric));
            }

            return Ok(metrics);
        }

        [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}/percentiles/{percentile}")]
        public IActionResult GetMetricsByPercentileFromAgent(
            [FromRoute] int agentId,
            [FromRoute] DateTimeOffset fromTime,
            [FromRoute] DateTimeOffset toTime,
            [FromRoute] int percentile)
        {
            _logger.LogInformation($"GetMetricsByPercentileFromAgent:{agentId} from:{fromTime} to:{toTime} int:{percentile}");

            var metrics = _repository.GetByTimePeriodSorted(agentId, fromTime, toTime);
            var response = new DotNetMetricsResponse()
            {
                Metrics = new List<DotNetMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<DotNetMetricDto>(metric));
            }

            int[] values = new int[response.Metrics.Count()];
            for (int i = 0; i < response.Metrics.Count(); i++)
            {
                values[i] = response.Metrics[i].Value;
            }
            return Ok(PercentileCounter.GetPercentile(values, percentile));
        }

        [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAllCluster(
            [FromRoute] TimeSpan fromTime,
            [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation($"GetMetricsFromAllCluster from:{fromTime} to:{toTime}");
            return Ok();
        }
        [HttpGet("cluster/from/{fromTime}/to/{toTime}/percentiles/{percentile}")]
        public IActionResult GetMetricsByPercentileFromAllCluster(
            [FromRoute] TimeSpan fromTime,
            [FromRoute] TimeSpan toTime,
            [FromRoute] Percentile percentile)
        {
            _logger.LogInformation($"GetMetricsByPercentileFromAllCluster from:{fromTime} to:{toTime} percentiles:{percentile}");
            return Ok();
        }
    }
}
