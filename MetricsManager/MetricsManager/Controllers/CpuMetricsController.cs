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
            var metrics = _metricsAgentClient.GetCpuMetrics(new GetAllCpuMetricsApiRequest()
            {
                AgentAddress = "http://localhost:5004",
                FromTime = fromTime,
                ToTime = DateTimeOffset.Now
            });
            return Ok(metrics);
        }
        //            [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
        //        public IActionResult GetMetricsFromAgent(
        //            [FromRoute] int agentId, 
        //            [FromRoute] DateTimeOffset fromTime, 
        //            [FromRoute] DateTimeOffset toTime)
        //        {
        //            string stringFromTime = fromTime.ToString("O");
        //            string stringToTime = toTime.ToString("O");
        //            string requestString = String.Format("http://localhost:5004/api/cpumetrics/from/{0}/to/{1}", stringFromTime, stringToTime);
        //            var request = new HttpRequestMessage(HttpMethod.Get, requestString);
        //            //$"http://localhost:5004/api/cpumetrics/from/2021-04-10/to/2021-04-13");
        //            //$"http://localhost:5004/api/cpumetrics/from/{fromTime}/to/{toTime}");

        //            var client = _httpClientFactory.CreateClient();
        //            HttpResponseMessage response = client.SendAsync(request).Result;
        //            var jsonSerializerOptions = new JsonSerializerOptions();
        //            jsonSerializerOptions.PropertyNameCaseInsensitive = true;
        //            if (response.IsSuccessStatusCode)
        //            {
        //                using var responseStream = response.Content.ReadAsStreamAsync().Result;
        //                var l = responseStream.Length;
        //                using var streamReader = new StreamReader(responseStream);
        //                var content = streamReader.ReadToEnd();
        //                var metricsResponse = JsonConvert.DeserializeObject(content);
        ////                var metricsResponse = JsonSerializer.DeserializeAsync<CpuMetricsResponse>(responseStream).Result;
        //            }
        //            else
        //            {
        //                return BadRequest();
        //            }
        //            return Ok();
        //        }

        //[HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
        //public IActionResult GetMetricsFromAgent(
        //    [FromRoute] int agentId, 
        //    [FromRoute] DateTimeOffset fromTime, 
        //    [FromRoute] DateTimeOffset toTime)
        //{
        //    _logger.LogInformation($"GetMetricsFromAgent:{agentId} from:{fromTime} to:{toTime}");

        //    var metrics = _repository.GetByTimePeriod(agentId, fromTime, toTime);
        //    var response = new CpuMetricsResponse()
        //    {
        //        Metrics = new List<CpuMetricDto>()
        //    };

        //    foreach (var metric in metrics)
        //    {
        //        response.Metrics.Add(_mapper.Map<CpuMetricDto>(metric));
        //    }

        //    return Ok(response);
        //}

        [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}/percentiles/{percentile}")]
        public IActionResult GetMetricsByPercentileFromAgent(
            [FromRoute] int agentId,
            [FromRoute] TimeSpan fromTime, 
            [FromRoute] TimeSpan toTime,
            [FromRoute] Percentile percentile)
        {
            _logger.LogInformation($"GetMetricsByPercentileFromAgent:{agentId} from:{fromTime} to:{toTime} percentiles:{percentile}");
            return Ok();
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
