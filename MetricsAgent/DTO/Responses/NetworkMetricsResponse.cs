using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DTO.Responses
{
    public class NetworkMetricsResponse
    {
        public List<NetworkMetricDto> Metrics { get; set; }
    }
}
