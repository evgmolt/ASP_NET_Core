﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Responses
{
    public class CpuMetricsResponse
    {
        public List<CpuMetricDto> Metrics { get; set; }
    }

    public class CpuMetricDto
    {
        public int Id { get; set; }
        public int AgentId { get; set; }
        public int Value { get; set; }
        public int Time { get; set; }
    }
}
