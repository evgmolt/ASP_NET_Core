using MetricsManagerClient.Client.ApiRequests;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;

namespace MetricsManagerClient.Client
{
    public class MetricsAgentClient : IMetricsAgentClient
    {
        private readonly HttpClient _Client;
        private readonly string _agentNum = "agent/1";

        public MetricsAgentClient(HttpClient Client)
        {
            _Client = Client;
        }

        private string GetMetricsApiResponseString(ApiRequest request, string tableName)
        {
            var fromParameter = request.FromTime.ToString("O");
            var toParameter = request.ToTime.ToString("O");
            var httpRequest = new HttpRequestMessage(
                HttpMethod.Get,
                String.Format(
                    "{0}/api/{1}/{2}/from/{3}/to/{4}",
                    request.AgentAddress,
                    tableName,
                    _agentNum,
                    fromParameter,
                    toParameter));
            try
            {
                HttpResponseMessage response = _Client.SendAsync(httpRequest).Result;

                var responseStream = response.Content.ReadAsStreamAsync().Result;
                var streamReader = new StreamReader(responseStream);
                string content = streamReader.ReadToEnd();
                responseStream.Dispose();
                streamReader.Dispose();
                return content;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        public AllCpuMetricsApiResponse GetCpuMetrics(GetAllCpuMetricsApiRequest request)
        {            
            string content = GetMetricsApiResponseString(request, "cpumetrics");
            if (content != null)
            {
                return JsonConvert.DeserializeObject<AllCpuMetricsApiResponse>(content);
            }
            else 
            {
                return null;
            }
        }

        public AllDotNetMetricsApiResponse GetDotNetMetrics(GetAllDotNetMetricsApiRequest request)
        {
            string content = GetMetricsApiResponseString(request, "dotnetmetrics");
            if (content != null)
            {
                return JsonConvert.DeserializeObject<AllDotNetMetricsApiResponse>(content);
            }
            else
            {
                return null;
            }
        }

        public AllHddMetricsApiResponse GetHddMetrics(GetAllHddMetricsApiRequest request)
        {
            string content = GetMetricsApiResponseString(request, "hddmetrics");
            if (content != null)
            {
                return JsonConvert.DeserializeObject<AllHddMetricsApiResponse>(content);
            }
            else
            {
                return null;
            }
        }

        public AllNetworkMetricsApiResponse GetNetworkMetrics(GetAllNetworkMetrisApiRequest request)
        {
            string content = GetMetricsApiResponseString(request, "networkmetrics");
            if (content != null)
            {
                return JsonConvert.DeserializeObject<AllNetworkMetricsApiResponse>(content);
            }
            else
            {
                return null;
            }
        }

        public AllRamMetricsApiResponse GetRamMetrics(GetAllRamMetricsApiRequest request)
        {
            string content = GetMetricsApiResponseString(request, "rammetrics");
            if (content != null)
            {
                return JsonConvert.DeserializeObject<AllRamMetricsApiResponse>(content);
            }
            else
            {
                return null;
            }
        }
    }
}
