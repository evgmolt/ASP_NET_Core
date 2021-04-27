using AutoMapper;
using MetricsManager.Client;
using MetricsManager.Controllers;
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
    public class CpuMetricJob : IJob
    {
        private readonly ICpuMetricsRepository _repository;
        private readonly IAgentsRepository<AgentInfo> _agentsRepository;
        private readonly IMetricsAgentClient _client;
        private readonly ILogger<CpuMetricJob> _logger;

        public CpuMetricJob(
            ICpuMetricsRepository repository, 
            IAgentsRepository<AgentInfo> agentsRepository, 
            IMetricsAgentClient client, 
            ILogger<CpuMetricJob> logger)
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
                        int agentId = i + 1;
                        var lastTime = _repository.GetLastTime(agentId);
                        DateTimeOffset fromTime = DateTimeOffset.FromUnixTimeSeconds(lastTime);
                        var metrics = _client.GetCpuMetrics(new GetAllCpuMetricsApiRequest()
                        {
                            AgentAddress = agents[i].AgentAddress,
                            FromTime = fromTime,
                            ToTime = DateTimeOffset.Now
                        });
                        if (metrics != null)
                        {
                            _logger.LogInformation(@"metrics: {0}", metrics.Metrics.Count());
                            foreach (var metric in metrics.Metrics)
                            {
                                _repository.Create(new CpuMetric()
                                {
                                    AgentId = agentId,
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
