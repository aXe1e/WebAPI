using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.DAL.Models;
using Quartz;

namespace MetricsAgent.Jobs.Job
{
    public class NetworkMetricJob : IJob
    {
        private INetworkMetricsRepository _repository;
        private PerformanceCounter _cpuCounter;
        public NetworkMetricJob(INetworkMetricsRepository repository)
        {
            _repository = repository;
            _cpuCounter = new PerformanceCounter("Network Adapter", "Bytes Total/sec", "Qualcomm Atheros AR8151 PCI-E Gigabit Ethernet Controller [NDIS 6.30]");
        }

        public Task Execute(IJobExecutionContext context)
        {
            _repository.Create(new NetworkMetric
            {
                Value = Convert.ToInt32(_cpuCounter.NextValue()),
                Time = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
            });
            return Task.CompletedTask;
        }
    }
}
