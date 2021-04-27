using MetricsManagerClient.Client.ApiRequests;
using MetricsManagerClient.Client.ApiResponses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

        private static List<int> GetValues(string inputString)
        {
            var outList = new List<int>();
            string value = "value";
            int pos = inputString.IndexOf(value);
            while (!(pos < 0))
            {
                string substr = inputString.Substring(pos + 7);
                inputString = substr;
                pos = substr.IndexOf(',');
                substr = substr.Substring(0, pos);
                int result;
                if (Int32.TryParse(substr, out result))
                {
                    outList.Add(result);
                }
                pos = inputString.IndexOf(value);
            }
            return outList;
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

        public List<int> GetCpuMetrics(GetAllCpuMetricsApiRequest request)
        {            
            string content = GetMetricsApiResponseString(request, "cpumetrics");
            if (content != null)
            {
                return GetValues(content);
            }
            else 
            {
                return null;
            }
        }

        public List<int> GetDotNetMetrics(GetAllDotNetMetricsApiRequest request)
        {
            string content = GetMetricsApiResponseString(request, "dotnetmetrics");
            if (content != null)
            {
                return GetValues(content);
            }
            else
            {
                return null;
            }
        }

        public List<int> GetHddMetrics(GetAllHddMetricsApiRequest request)
        {
            string content = GetMetricsApiResponseString(request, "hddmetrics");
            if (content != null)
            {
                return GetValues(content);
            }
            else
            {
                return null;
            }
        }

        public List<int> GetNetworkMetrics(GetAllNetworkMetrisApiRequest request)
        {
            string content = GetMetricsApiResponseString(request, "networkmetrics");
            if (content != null)
            {
                return GetValues(content);
            }
            else
            {
                return null;
            }
        }

        public List<int> GetRamMetrics(GetAllRamMetricsApiRequest request)
        {
            string content = GetMetricsApiResponseString(request, "rammetrics");
            if (content != null)
            {
                return GetValues(content);
            }
            else
            {
                return null;
            }
        }
    }
}
