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
    public class CpuMetricJob : IJob
    {
        private readonly ICpuMetricsRepository _repository;
        private readonly PerformanceCounter _cpuCounter;
        private readonly ILogger<CpuMetricJob> _logger;

        public CpuMetricJob(ICpuMetricsRepository repository, ILogger<CpuMetricJob> logger)
        {
            _repository = repository;
            _logger = logger;
            _cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        }

        public Task Execute(IJobExecutionContext context)
        {
            try
            {
                var cpuUsageInPercent = Convert.ToInt32(_cpuCounter.NextValue());
                var time = DateTimeOffset.Now.ToUnixTimeSeconds();
                _repository.Create(new CpuMetric() { Time = time, Value = cpuUsageInPercent });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Task.CompletedTask;
        }
    }
}
