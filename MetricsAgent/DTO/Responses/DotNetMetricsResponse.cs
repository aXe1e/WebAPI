using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DTO.Responses
{
    public class DotNetMetricsResponse
    {
        public List<DotNetMetricDto> Metrics { get; set; }
    }
}
