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
    [Route("api/hddmetrics")]
    [ApiController]
    public class HddMetricsController : ControllerBase
    {
        private IHddMetricsRepository _repository;
        private readonly ILogger<HddMetricsController> _logger;
        private readonly IMapper _mapper;

        public HddMetricsController(
            ILogger<HddMetricsController> logger,
            IHddMetricsRepository repository,
            IMapper mapper)
        {
            this._repository = repository;
            this._logger = logger;
            this._mapper = mapper;
            _logger.LogDebug(1, "NLog встроен в HddMetricsController");
        }

        /// <summary>
        /// Получает метрики от агента в заданном диапазоне времени
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// GET api/hddmetrics/agent/3/from/2021-04-13T05:00:00+00:00/to/2021-04-13T05:00:20+00:00
        /// </remarks>
        /// <param name="agentId">ID агента</param>
        /// <param name="fromTime">начальный момент времени 2021-04-13T05:00:00+00:00</param>
        /// <param name="toTime">конечный  момент времени 2021-04-13T05:00:20+00:00</param>
        /// <returns>Список метрик, сохраненных агентом  в заданном диапазоне времени</returns>
        [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent(
            [FromRoute] int agentId,
            [FromRoute] DateTimeOffset fromTime,
            [FromRoute] DateTimeOffset toTime)
        {
            var metrics = _repository.GetByTimePeriod(agentId, fromTime, toTime);
            var response = new HddMetricsResponse()
            {
                Metrics = new List<HddMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<HddMetricDto>(metric));
            }

            return Ok(metrics);
        }

        /// <summary>
        /// Получает перцентиль от агента в заданном диапазоне времени
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// GET api/hddmetrics/agent/3/from/2021-04-13T05:00:00+00:00/to/2021-04-13T05:00:20+00:00/0
        /// </remarks>
        /// <param name="agentId">ID агента</param>
        /// <param name="fromTime">начальный момент времени 2021-04-13T05:00:00+00:00</param>
        /// <param name="toTime">конечный  момент времени 2021-04-13T05:00:20+00:00</param>
        /// <param name="percentile">индекс перцентиля из списка (с 0) { 50, 75, 90, 95, 99 } </param>
        /// <returns>Значение перцентиля за заданный диапазон времени</returns>
        [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}/percentiles/{percentile}")]
        public IActionResult GetMetricsByPercentileFromAgent(
            [FromRoute] int agentId,
            [FromRoute] DateTimeOffset fromTime,
            [FromRoute] DateTimeOffset toTime,
            [FromRoute] int percentile)
        {
            _logger.LogInformation($"GetMetricsByPercentileFromAgent:{agentId} from:{fromTime} to:{toTime} int:{percentile}");

            var metrics = _repository.GetByTimePeriodSorted(agentId, fromTime, toTime);
            var response = new HddMetricsResponse()
            {
                Metrics = new List<HddMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<HddMetricDto>(metric));
            }

            int[] values = new int[response.Metrics.Count()];
            for (int i = 0; i < response.Metrics.Count(); i++)
            {
                values[i] = response.Metrics[i].Value;
            }
            return Ok(PercentileCounter.GetPercentile(values, percentile));
        }
    }
}
