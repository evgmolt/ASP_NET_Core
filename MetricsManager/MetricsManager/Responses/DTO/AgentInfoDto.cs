using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Responses.DTO
{
    public class AgentInfoDto
    {
        public int Id { get; set; }
        public string AgentAddress { get; set; }
        public bool Enabled { get; set; }
    }
}
