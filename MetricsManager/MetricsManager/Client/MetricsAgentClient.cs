using Core;
using MetricsManager.Client.ApiRequests;
using MetricsManager.Client.ApiResponses;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MetricsManager.Client
{
    public class MetricsAgentClient : IMetricsAgentClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<MetricsAgentClient> _logger;

        public MetricsAgentClient(HttpClient httpClient, ILogger<MetricsAgentClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        private string GetMetricsApiResponseString(ApiRequest request, string tableName)
        {
            var fromParameter = request.FromTime.ToString("O");
            var toParameter = request.ToTime.ToString("O");
            var httpRequest = new HttpRequestMessage(
                HttpMethod.Get,
                String.Format(
                    "{0}/api/{1}/from/{2}/to/{3}",
                    request.AgentAddress,
                    tableName,
                    fromParameter,
                    toParameter));
            try
            {
                HttpResponseMessage response = _httpClient.SendAsync(httpRequest).Result;

                using var responseStream = response.Content.ReadAsStreamAsync().Result;
                using var streamReader = new StreamReader(responseStream);
                string content = streamReader.ReadToEnd();
                return content;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
            
        }

        public AllCpuMetricsApiResponse GetCpuMetrics(GetAllCpuMetricsApiRequest request)
        {            
            string content = GetMetricsApiResponseString(request, Strings.TableNames[(int)Enums.MetricsNames.Cpu]);
            if (content != null)
            {
                return JsonConvert.DeserializeObject<AllCpuMetricsApiResponse>(content);
            }
            else 
            {
                _logger.LogError("null content");
                return null;
            }
        }

        public AllDotNetMetricsApiResponse GetDotNetMetrics(GetAllDotNetMetricsApiRequest request)
        {
            string content = GetMetricsApiResponseString(request, Strings.TableNames[(int)Enums.MetricsNames.DotNet]);
            if (content != null)
            {
                return JsonConvert.DeserializeObject<AllDotNetMetricsApiResponse>(content);
            }
            else
            {
                _logger.LogError("null content");
                return null;
            }
        }

        public AllHddMetricsApiResponse GetHddMetrics(GetAllHddMetricsApiRequest request)
        {
            string content = GetMetricsApiResponseString(request, Strings.TableNames[(int)Enums.MetricsNames.Hdd]);
            if (content != null)
            {
                return JsonConvert.DeserializeObject<AllHddMetricsApiResponse>(content);
            }
            else
            {
                _logger.LogError("null content");
                return null;
            }
        }

        public AllNetworkMetricsApiResponse GetNetworkMetrics(GetAllNetworkMetrisApiRequest request)
        {
            string content = GetMetricsApiResponseString(request, Strings.TableNames[(int)Enums.MetricsNames.Network]);
            if (content != null)
            {
                return JsonConvert.DeserializeObject<AllNetworkMetricsApiResponse>(content);
            }
            else
            {
                _logger.LogError("null content");
                return null;
            }
        }

        public AllRamMetricsApiResponse GetRamMetrics(GetAllRamMetricsApiRequest request)
        {
            string content = GetMetricsApiResponseString(request, Strings.TableNames[(int)Enums.MetricsNames.Ram]);
            if (content != null)
            {
                return JsonConvert.DeserializeObject<AllRamMetricsApiResponse>(content);
            }
            else
            {
                _logger.LogError("null content");
                return null;
            }
        }
    }
}
