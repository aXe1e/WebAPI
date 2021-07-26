using System;

namespace MetricsAgent.DTO
{
    public class HddMetricDto
    {
        public int Value { get; set; }
        public DateTimeOffset Time { get; set; }
    }
}
