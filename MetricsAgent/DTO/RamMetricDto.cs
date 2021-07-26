using System;

namespace MetricsAgent.DTO
{
    public class RamMetricDto
    {
        public int Value { get; set; }
        public DateTimeOffset Time { get; set; }
    }
}
