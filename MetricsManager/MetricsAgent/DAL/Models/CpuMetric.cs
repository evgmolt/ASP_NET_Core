using System;

namespace MetricsAgent.DAL.Interfaces
{
    public class CpuMetric
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public long Time { get; set; }
    }
}