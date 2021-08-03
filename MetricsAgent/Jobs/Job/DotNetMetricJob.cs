using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.DAL.Models;
using Quartz;

namespace MetricsAgent.Jobs.Job
{
    public class DotNetMetricJob : IJob
    {
        private IDotNetMetricsRepository _repository;
        private PerformanceCounter _cpuCounter;

        public DotNetMetricJob(IDotNetMetricsRepository repository)
        {
            _repository = repository;
            _cpuCounter = new PerformanceCounter(".NET CLR Memory", "Gen 0 heap size", "_Global_");
        }

        public Task Execute(IJobExecutionContext context)
        {
            _repository.Create(new DotNetMetric
            {
                Value = Convert.ToInt32(_cpuCounter.NextValue()),
                Time = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
            });
            return Task.CompletedTask;
        }
    }
}
