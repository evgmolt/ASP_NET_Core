using MetricsAgent.DAL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs
{
    [DisallowConcurrentExecution]
    public class NetworkMetricJob : IJob
    {
        private readonly INetworkMetricsRepository _repository;
        private readonly PerformanceCounter _networkCounter;
        private readonly ILogger<NetworkMetricJob> _logger;

        public NetworkMetricJob(INetworkMetricsRepository repository, ILogger<NetworkMetricJob> logger)
        {
            _repository = repository;
            _logger = logger;
            _networkCounter = new PerformanceCounter("Сетевой интерфейс", "Всего байт/с", "Сетевая карта Realtek RTL8723AE Wireless LAN 802.11n PCI-E");
        }

        public Task Execute(IJobExecutionContext context)
        {
            try
            {
                var cpuUsageInPercent = Convert.ToInt32(_networkCounter.NextValue());
                var time = DateTimeOffset.Now.ToUnixTimeSeconds();
                _repository.Create(new NetworkMetric() { Time = time, Value = cpuUsageInPercent });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Task.CompletedTask;
        }
    }
}
