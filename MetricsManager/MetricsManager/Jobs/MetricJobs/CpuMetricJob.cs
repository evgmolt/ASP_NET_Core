using MetricsManager.Client;
using MetricsManager.DAL.Interfaces;
using MetricsManager.DAL.Models;
using MetricsManager.DAL.Repositories;
using MetricsManager.Responses;
using MetricsManager.Responses.DTO;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Jobs.MetricJobs
{
 //   [DisallowConcurrentExecution]
    public class CpuMetricJob : IJob
    {
        private ICpuMetricsRepository _repository;
        private IAgentsRepository _agentsRepository;
        private IMetricsAgentClient _client;

        public CpuMetricJob(ICpuMetricsRepository repository, IAgentsRepository agentsRepository, IMetricsAgentClient client)
        {
            _agentsRepository = agentsRepository;
            _repository = repository;
            _client = client;
        }

        public Task Execute(IJobExecutionContext context)
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
            return Task.CompletedTask;
        }
    }
}
