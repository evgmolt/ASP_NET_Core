using Core;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DAL.Interfaces
{
    public interface ICpuMetricsRepository : IRepository<CpuMetric>
    {
    }
}