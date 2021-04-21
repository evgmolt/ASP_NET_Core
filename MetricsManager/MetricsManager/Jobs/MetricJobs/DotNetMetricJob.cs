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
    [DisallowConcurrentExecution]
    public class DotNetMetricJob : IJob
    {
        private IDotNetMetricsRepository _repository;
        private IAgentsRepository<AgentInfo> _agentsRepository;
        private IMetricsAgentClient _client;
        private readonly ILogger<DotNetMetricJob> _logger;

        public DotNetMetricJob(
            IDotNetMetricsRepository repository, 
            IAgentsRepository<AgentInfo> agentsRepository, 
            IMetricsAgentClient client,
            ILogger<DotNetMetricJob> logger)
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
                        long lastTime = _repository.GetLastTime(i);
                        DateTimeOffset fromTime = DateTimeOffset.FromUnixTimeSeconds(lastTime);
                        var metrics = _client.GetDotNetMetrics(new GetAllDotNetMetricsApiRequest()
                        {
                            AgentAddress = agents[i].AgentAddress,
                            FromTime = fromTime,
                            ToTime = DateTimeOffset.Now
                        });
                        if (metrics != null)
                        {
                            foreach (var metric in metrics.Metrics)
                            {
                                _repository.Create(new DotNetMetric()
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
