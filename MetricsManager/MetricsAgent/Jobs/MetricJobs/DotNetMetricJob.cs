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
    public class DotNetMetricJob : IJob
    {
        private readonly IDotNetMetricsRepository _repository;
        private readonly PerformanceCounter _dotnetCounter;
        private readonly ILogger<DotNetMetricJob> _logger;

        public DotNetMetricJob(IDotNetMetricsRepository repository, ILogger<DotNetMetricJob> logger)
        {
            _repository = repository;
            _logger = logger;
            _dotnetCounter = new PerformanceCounter("Память CLR .NET", "Размер кучи для массивных объектов", "vstest.console");
        }

        public Task Execute(IJobExecutionContext context)
        {
            try
            {
                var dotnetCLRMemory = Convert.ToInt32(_dotnetCounter.NextValue());
                var time = DateTimeOffset.Now.ToUnixTimeSeconds();
                _repository.Create(new DotNetMetric() { Time = time, Value = dotnetCLRMemory });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Task.CompletedTask;
        }
    }
}
