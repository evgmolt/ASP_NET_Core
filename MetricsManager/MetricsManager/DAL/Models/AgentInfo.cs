using System;

namespace MetricsManager.DAL.Models
{
    public class AgentInfo
    {
        public Uri AgentAddress { get; set; }

        public bool Enabled { get; set; }
    }
}