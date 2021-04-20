using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Client
{
    public interface IMetricsAgentClient
    {
        AllCpuMetricsApiResponse GetCpuMetrics(GetAllCpuMetricsApiRequest request);

        AllDotNetMetricsApiResponse GetDotNetMetrics(GetAllDotNetMetricsApiRequest request);
 
        AllHddMetricsApiResponse GetHddMetrics(GetAllHddMetricsApiRequest request);

        AllNetworkMetricsApiResponse GetNetworkMetrics(GetAllNetworkMetrisApiRequest request);

        AllRamMetricsApiResponse GetRamMetrics(GetAllRamMetricsApiRequest request);
    }
}
