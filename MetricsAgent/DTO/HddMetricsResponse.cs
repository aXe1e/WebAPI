using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DTO
{
    public class HddMetricsResponse
    {
        public List<HddMetricDto> Metrics { get; set; }
    }
}
