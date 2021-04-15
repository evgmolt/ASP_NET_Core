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
    public class RamMetricJob : IJob
    {
        private IRamMetricsRepository _repository;
        private PerformanceCounter _ramCounter;
        private readonly ILogger<RamMetricJob> _logger;

        public RamMetricJob(IRamMetricsRepository repository, ILogger<RamMetricJob> logger)
        {
            _repository = repository;
            _logger = logger;
            _ramCounter = new PerformanceCounter("Память CLR .NET", "Байт во всех кучах", "vstest.console");
        }

        public Task Execute(IJobExecutionContext context)
        {
            try
            {
                var ramAvailable = Convert.ToInt32(_ramCounter.NextValue());
                var time = DateTimeOffset.Now.ToUnixTimeSeconds();
                _repository.Create(new RamMetric() { Time = time, Value = ramAvailable });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Task.CompletedTask;
        }
    }
}
