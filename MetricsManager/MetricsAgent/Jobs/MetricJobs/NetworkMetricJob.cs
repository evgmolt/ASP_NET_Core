using MetricsAgent.DAL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs
{
    public class NetworkMetricJob : IJob
    {
        private INetworkMetricsRepository _repository;
        private PerformanceCounter _networkCounter;

        public NetworkMetricJob(INetworkMetricsRepository repository)
        {
            _repository = repository;
            _networkCounter = new PerformanceCounter("Сетевой интерфейс", "Всего байт/с", "Сетевая карта Realtek RTL8723AE Wireless LAN 802.11n PCI-E");
        }

        public Task Execute(IJobExecutionContext context)
        {
            var cpuUsageInPercent = Convert.ToInt32(_networkCounter.NextValue());
            var time = DateTimeOffset.Now.ToUnixTimeSeconds();
            _repository.Create(new NetworkMetric() { Time = time, Value = cpuUsageInPercent });
            return Task.CompletedTask;
        }
    }
}
