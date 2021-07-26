using System;

namespace MetricsAgent.DTO
{
    public class CpuMetricDto
    {
        public int Value { get; set; }
        public DateTimeOffset Time { get; set; }
    }
}
