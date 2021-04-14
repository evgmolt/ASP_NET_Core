using MetricsManager.Client;
using MetricsManager.DAL.Interfaces;
using MetricsManager.DAL.Models;
using MetricsManager.DAL.Repositories;
using MetricsManager.Responses;
using MetricsManager.Responses.DTO;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Jobs.MetricJobs
{
    public class HddMetricJob : IJob
    {
        private readonly IHddMetricsRepository _repository;
        private readonly IAgentsRepository _agentsRepository;
        private readonly IMetricsAgentClient _client;
        private readonly ILogger<HddMetricJob> _logger;

        public HddMetricJob(
            IHddMetricsRepository repository, 
            IAgentsRepository agentsRepository, 
            IMetricsAgentClient client,
            ILogger<HddMetricJob> logger)
        {
            _agentsRepository = agentsRepository;
            _repository = repository;
            _client = client;
            _logger = logger;
        }

        public Task Execute(IJobExecutionContext context)
        {
            try
            {
                var agents = _agentsRepository.GetAgentsList();
                for (int i = 0; i < agents.Count(); i++)
                {
                    if (agents[i].Enabled)
                    {
                        HddMetric lastmetric = _repository.GetLast(i);
                        long fromtimesec = lastmetric?.Time ?? 0;
                        DateTimeOffset fromtime = DateTimeOffset.FromUnixTimeSeconds(fromtimesec);
                        var metrics = _client.GetHddMetrics(new GetAllHddMetricsApiRequest()
                        {
                            AgentAddress = agents[i].AgentAddress,
                            FromTime = fromtime,
                            ToTime = DateTimeOffset.Now
                        });
                        if (metrics != null)
                        {
                            foreach (var metric in metrics.Metrics)
                            {
                                _repository.Create(new HddMetric()
                                {
                                    AgentId = metric.AgentId,
                                    Time = metric.Time.ToUnixTimeSeconds(),
                                    Value = metric.Value
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Task.CompletedTask;
        }
    }
}
