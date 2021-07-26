using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.DAL.Models;
using Quartz;

namespace MetricsAgent.Jobs.Job
{
    public class HddMetricJob : IJob
    {
        private IHddMetricsRepository _repository;
        private PerformanceCounter _cpuCounter;
        public HddMetricJob(IHddMetricsRepository repository)
        {
            _repository = repository;
            _cpuCounter = new PerformanceCounter("PhysicalDisk", "Disk Bytes/sec", "_Total");
        }

        public Task Execute(IJobExecutionContext context)
        {
            _repository.Create(new HddMetric
            {
                Value = Convert.ToInt32(_cpuCounter.NextValue()),
                Time = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
            });
            return Task.CompletedTask;
        }
    }
}
