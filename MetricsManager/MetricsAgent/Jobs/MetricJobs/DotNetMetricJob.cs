using MetricsAgent.DAL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs
{
    public class DotNetMetricJob : IJob
    {
        private IDotNetMetricsRepository _repository;
        private PerformanceCounter _dotnetCounter;

        public DotNetMetricJob(IDotNetMetricsRepository repository)
        {
            _repository = repository;
            _dotnetCounter = new PerformanceCounter("Память CLR .NET", "Размер кучи для массивных объектов", "vstest.console");
        }

        public Task Execute(IJobExecutionContext context)
        {
            var dotnetCLRMemory = Convert.ToInt32(_dotnetCounter.NextValue());
            var time = DateTimeOffset.Now.ToUnixTimeSeconds();
            _repository.Create(new DotNetMetric() { Time = time, Value = dotnetCLRMemory });
            return Task.CompletedTask;
        }
    }
}
