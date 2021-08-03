using System;

namespace MetricsAgent.DTO
{
    public class NetworkMetricDto
    {
        public int Value { get; set; }
        public DateTimeOffset Time { get; set; }
    }
}
