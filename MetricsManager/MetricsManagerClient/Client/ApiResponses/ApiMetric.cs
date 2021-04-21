using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManagerClient.Client.ApiResponses
{
    public class ApiMetric
    {
        public int id { get; set; }
        public int agentId { get; set; }
        public int value { get; set; }
        public long time { get; set; }
    }
}
