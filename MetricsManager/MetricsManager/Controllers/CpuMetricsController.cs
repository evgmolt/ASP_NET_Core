using AutoMapper;
using Enums;
using MetricsManager.Client;
using MetricsManager.DAL.Interfaces;
using MetricsManager.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    [Route("api/metrics/cpu")]
    [ApiController]
    public class CpuMetricsController : ControllerBase
    {
        private ICpuMetricsRepository _repository;
        private readonly ILogger<CpuMetricsController> _logger;
        private readonly IMapper _mapper;
        private IConfiguration _configuration;
        private IHttpClientFactory _httpClientFactory;
        private IMetricsAgentClient _metricsAgentClient;

        public CpuMetricsController(
            ILogger<CpuMetricsController> logger,
            ICpuMetricsRepository repository,
            IMapper mapper,
            IConfiguration configuration,
            IHttpClientFactory httpClientFactory,
            IMetricsAgentClient metricsAgentClient)
        {
            this._metricsAgentClient = metricsAgentClient;
            this._httpClientFactory = httpClientFactory;
            this._configuration = configuration;
            this._repository = repository;
            this._logger = logger;
            this._mapper = mapper;
            _logger.LogDebug(1, "NLog встроен в CpuMetricsController");
        }

        [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent(
            [FromRoute] int agentId,
            [FromRoute] DateTimeOffset fromTime,
            [FromRoute] DateTimeOffset toTime)
        {
            //var metrics = _metricsAgentClient.GetCpuMetrics(new GetAllCpuMetricsApiRequest()
            //{
            //    AgentAddress = "http://localhost:5004",
            //    FromTime = fromTime,
            //    ToTime = toTime
            //});

            var metrics = _repository.GetByTimePeriod(agentId, fromTime, toTime);
            var response = new CpuMetricsResponse()
            {
                Metrics = new List<CpuMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<CpuMetricDto>(metric));
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
            var response = new CpuMetricsResponse()
            {
                Metrics = new List<CpuMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<CpuMetricDto>(metric));
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
            [FromRoute] int percentile)
        {
            _logger.LogInformation($"GetMetricsByPercentileFromAllCluster from:{fromTime} to:{toTime} percentiles:{percentile}");
            return Ok();
        }
    }
}
