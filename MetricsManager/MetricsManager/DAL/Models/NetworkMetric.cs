using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.DAL.Models
{
    public class NetworkMetric
    {
        public int Id { get; set; }
        public int AgentID { get; set; }
        public int Value { get; set; }
        public TimeSpan Time { get; set; }
    }
}
