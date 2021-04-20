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
    public class HddMetricJob : IJob
    {
        private readonly IHddMetricsRepository _repository;
        private readonly PerformanceCounter _hddCounter;
        private readonly ILogger<HddMetricJob> _logger;

        public HddMetricJob(IHddMetricsRepository repository, ILogger<HddMetricJob> logger)
        {
            _repository = repository;
            _logger = logger;
            _hddCounter = new PerformanceCounter("Логический диск", "% свободного места", "F:");
        }

        public Task Execute(IJobExecutionContext context)
        {
            try
            {
                var hddFreeSpace = Convert.ToInt32(_hddCounter.NextValue());
                var time = DateTimeOffset.Now.ToUnixTimeSeconds();
                _repository.Create(new HddMetric() { Time = time, Value = hddFreeSpace });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Task.CompletedTask;
        }
    }
}
