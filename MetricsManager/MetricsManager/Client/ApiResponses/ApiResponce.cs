﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Client.ApiResponses
{
    public class ApiResponse
    {
        public int AgentId { get; set; }
        public int Value { get; set; }
        public long Time { get; set; }
    }
}
