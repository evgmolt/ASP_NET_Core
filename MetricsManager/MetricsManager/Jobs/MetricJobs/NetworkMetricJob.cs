using MetricsManager.Client;
using MetricsManager.DAL.Interfaces;
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
    public class NetworkMetricJob : IJob
    {
        private INetworkMetricsRepository _repository;
        private IAgentsRepository _agentsRepository;
        private IMetricsAgentClient _client;

        public NetworkMetricJob(INetworkMetricsRepository repository, IAgentsRepository agentsRepository, IMetricsAgentClient client)
        {
            _agentsRepository = agentsRepository;
            _repository = repository;
            _client = client;
        }

        public Task Execute(IJobExecutionContext context)
        {
            var metrics = _agentsRepository.GetAgentsList();
            var response = new AgentResponse()
            {
                Metrics = new List<AgentInfoDto>()
            };
            return Task.CompletedTask;
        }
    }
}
