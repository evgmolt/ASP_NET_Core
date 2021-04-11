using Core;
using MetricsManager.Client.ApiRequests;
using MetricsManager.Client.ApiResponses;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MetricsManager.Client
{
    public class MetricsAgentClient : IMetricsAgentClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger _logger;

        public MetricsAgentClient(HttpClient httpClient, ILogger logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        private ApiResponse MetricsApiResponse(ApiRequest request, string tableName)
        {
            var fromParameter = request.FromTime.ToUnixTimeSeconds();
            var toParameter = request.ToTime.ToUnixTimeSeconds();
            var httpRequest = new HttpRequestMessage(
                HttpMethod.Get, 
                $"{request.AgentAddress}/api/" + tableName + "/from/{fromParameter}/to/{toParameter}");
            try
            {
                HttpResponseMessage response = _httpClient.SendAsync(httpRequest).Result;

                using var responseStream = response.Content.ReadAsStreamAsync().Result;
                return JsonSerializer.DeserializeAsync<ApiResponse>(responseStream).Result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
            return null;
        }

        public AllCpuMetricsApiResponse GetCpuMetrics(GetAllCpuMetricsApiRequest request)
        {
            return (AllCpuMetricsApiResponse)MetricsApiResponse(request, Strings.TableNames[(int)Enums.MetricsNames.Cpu]);
        }

        public AllDotNetMetricsApiResponse GetDotNetMetrics(GetAllDotNetMetricsApiRequest request)
        {
            return (AllDotNetMetricsApiResponse)MetricsApiResponse(request, Strings.TableNames[(int)Enums.MetricsNames.DotNet]);
        }

        public AllHddMetricsApiResponse GetHddMetrics(GetAllHddMetricsApiRequest request)
        {
            return (AllHddMetricsApiResponse)MetricsApiResponse(request, Strings.TableNames[(int)Enums.MetricsNames.Hdd]);
        }

        public AllNetworkMetricsApiResponse GetNetworkMetrics(NetworkMetrisApiRequest request)
        {
            return (AllNetworkMetricsApiResponse)MetricsApiResponse(request, Strings.TableNames[(int)Enums.MetricsNames.Network]);
        }

        public AllRamMetricsApiResponse GetRamMetrics(GetAllRamMetricsApiRequest request)
        {
            return (AllRamMetricsApiResponse)MetricsApiResponse(request, Strings.TableNames[(int)Enums.MetricsNames.Ram]);
        }
    }
}
