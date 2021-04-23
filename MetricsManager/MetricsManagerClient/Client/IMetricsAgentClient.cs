using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManagerClient.Client
{
    public interface IMetricsAgentClient
    {
        List<int> GetCpuMetrics(GetAllCpuMetricsApiRequest request);

        List<int> GetDotNetMetrics(GetAllDotNetMetricsApiRequest request);

        List<int> GetHddMetrics(GetAllHddMetricsApiRequest request);

        List<int> GetNetworkMetrics(GetAllNetworkMetrisApiRequest request);

        List<int> GetRamMetrics(GetAllRamMetricsApiRequest request);
    }
}
