using System;

namespace MetricsAgent.DTO
{
    public class DotNetMetricDto
    {
        public int Value { get; set; }
        public DateTimeOffset Time { get; set; }
    }
}
