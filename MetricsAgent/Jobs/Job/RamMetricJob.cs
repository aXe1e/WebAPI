using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.DAL.Models;
using Quartz;

namespace MetricsAgent.Jobs.Job
{
    public class RamMetricJob : IJob
    {
        private IRamMetricsRepository _repository;
        private PerformanceCounter _cpuCounter;

        public RamMetricJob(IRamMetricsRepository repository)
        {
            _repository = repository;
            _cpuCounter = new PerformanceCounter("Memory", "Available MBytes");
        }

        public Task Execute(IJobExecutionContext context)
        {
            _repository.Create(new RamMetric
            {
                Value = Convert.ToInt32(_cpuCounter.NextValue()),
                Time = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
            });
            return Task.CompletedTask;
        }
    }
}
