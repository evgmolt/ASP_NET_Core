using MetricsAgent.DAL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs
{
    public class HddMetricJob : IJob
    {
        private IHddMetricsRepository _repository;
        private PerformanceCounter _hddCounter;

        public HddMetricJob(IHddMetricsRepository repository)
        {
            _repository = repository;
            _hddCounter = new PerformanceCounter("Логический диск", "% свободного места", "F:");
        }

        public Task Execute(IJobExecutionContext context)
        {
            var hddFreeSpace = Convert.ToInt32(_hddCounter.NextValue());
            var time = DateTimeOffset.Now.ToUnixTimeSeconds();
            _repository.Create(new HddMetric() { Time = time, Value = hddFreeSpace });
            return Task.CompletedTask;
        }
    }
}
