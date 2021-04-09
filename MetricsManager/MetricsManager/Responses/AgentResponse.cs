using MetricsManager.Responses.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Responses
{
    public class AgentResponse
    {
        public List<AgentDto> Metrics { get; set; }
    }
}
