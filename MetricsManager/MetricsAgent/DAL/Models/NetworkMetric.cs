﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DAL.Models
{
    public class NetworkMetric
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int Time { get; set; }
    }
}
