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
    public class NetworkMetricJob : IJob
    {
        private readonly INetworkMetricsRepository _repository;
        private readonly IAgentsRepository<AgentInfo> _agentsRepository;
        private readonly IMetricsAgentClient _client;
        private readonly ILogger<NetworkMetricJob> _logger;

        public NetworkMetricJob(
            INetworkMetricsRepository repository, 
            IAgentsRepository<AgentInfo> agentsRepository, 
            IMetricsAgentClient client,
            ILogger<NetworkMetricJob> logger)
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
                        NetworkMetric lastMetric = _repository.GetLast(i);
                        long fromtimesec = lastMetric?.Time ?? 0;
                        DateTimeOffset fromtime = DateTimeOffset.FromUnixTimeSeconds(fromtimesec);
                        var metrics = _client.GetNetworkMetrics(new GetAllNetworkMetrisApiRequest()
                        {
                            AgentAddress = agents[i].AgentAddress,
                            FromTime = fromtime,
                            ToTime = DateTimeOffset.Now
                        });
                        if (metrics != null)
                        {
                            foreach (var metric in metrics.Metrics)
                            {
                                _repository.Create(new NetworkMetric()
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
