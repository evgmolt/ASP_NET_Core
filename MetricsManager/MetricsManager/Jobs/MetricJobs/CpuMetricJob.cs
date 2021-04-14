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
    public class CpuMetricJob : IJob
    {
        private readonly ICpuMetricsRepository _repository;
        private readonly IAgentsRepository _agentsRepository;
        private readonly IMetricsAgentClient _client;
        private readonly ILogger<CpuMetricJob> _logger;

        public CpuMetricJob(
            ICpuMetricsRepository repository, 
            IAgentsRepository agentsRepository, 
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
                        CpuMetric lastmetric = _repository.GetLast(i);
                        long fromtimesec = lastmetric?.Time ?? 0;
                        DateTimeOffset fromtime = DateTimeOffset.FromUnixTimeSeconds(fromtimesec);
                        var metrics = _client.GetCpuMetrics(new GetAllCpuMetricsApiRequest()
                        {
                            AgentAddress = agents[i].AgentAddress,
                            FromTime = fromtime,
                            ToTime = DateTimeOffset.Now
                        });
                        if (metrics != null)
                        {
                            foreach (var metric in metrics.Metrics)
                            {
                                _repository.Create(new CpuMetric()
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
