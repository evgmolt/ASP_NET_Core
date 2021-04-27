using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Client
{
    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.10.9.0 (NJsonSchema v10.4.1.0 (Newtonsoft.Json v11.0.0.0))")]
    public partial class NswagMetricsAgentClient : INswagMetricsAgentClient
    {
        private string _baseUrl = "";
        private System.Net.Http.HttpClient _httpClient;
        private System.Lazy<Newtonsoft.Json.JsonSerializerSettings> _settings;

        public NswagMetricsAgentClient(string baseUrl, System.Net.Http.HttpClient httpClient)
        {
            BaseUrl = baseUrl;
            _httpClient = httpClient;
            _settings = new System.Lazy<Newtonsoft.Json.JsonSerializerSettings>(CreateSerializerSettings);
        }

        private Newtonsoft.Json.JsonSerializerSettings CreateSerializerSettings()
        {
            var settings = new Newtonsoft.Json.JsonSerializerSettings();
            UpdateJsonSerializerSettings(settings);
            return settings;
        }

        public string BaseUrl
        {
            get { return _baseUrl; }
            set { _baseUrl = value; }
        }

        protected Newtonsoft.Json.JsonSerializerSettings JsonSerializerSettings { get { return _settings.Value; } }

        partial void UpdateJsonSerializerSettings(Newtonsoft.Json.JsonSerializerSettings settings);


        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url);
        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, System.Text.StringBuilder urlBuilder);
        partial void ProcessResponse(System.Net.Http.HttpClient client, System.Net.Http.HttpResponseMessage response);
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task ApiAgentsRegisterAddressAsync(string agentAddress)
        {
            return ApiAgentsRegisterAddressAsync(agentAddress, System.Threading.CancellationToken.None);
        }

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public void ApiAgentsRegisterAddress(string agentAddress)
        {
            System.Threading.Tasks.Task.Run(async () => await ApiAgentsRegisterAddressAsync(agentAddress, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task ApiAgentsRegisterAddressAsync(string agentAddress, System.Threading.CancellationToken cancellationToken)
        {
            if (agentAddress == null)
                throw new System.ArgumentNullException("agentAddress");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/agents/register/address/{agentAddress}");
            urlBuilder_.Replace("{agentAddress}", System.Uri.EscapeDataString(ConvertToString(agentAddress, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Content = new System.Net.Http.StringContent(string.Empty, System.Text.Encoding.UTF8, "application/json");
                    request_.Method = new System.Net.Http.HttpMethod("POST");

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            return;
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task ApiAgentsDeleteAsync(int agentId)
        {
            return ApiAgentsDeleteAsync(agentId, System.Threading.CancellationToken.None);
        }

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public void ApiAgentsDelete(int agentId)
        {
            System.Threading.Tasks.Task.Run(async () => await ApiAgentsDeleteAsync(agentId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task ApiAgentsDeleteAsync(int agentId, System.Threading.CancellationToken cancellationToken)
        {
            if (agentId == null)
                throw new System.ArgumentNullException("agentId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/agents/delete/{agentId}");
            urlBuilder_.Replace("{agentId}", System.Uri.EscapeDataString(ConvertToString(agentId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("DELETE");

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            return;
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task ApiAgentsEnableAsync(int agentId)
        {
            return ApiAgentsEnableAsync(agentId, System.Threading.CancellationToken.None);
        }

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public void ApiAgentsEnable(int agentId)
        {
            System.Threading.Tasks.Task.Run(async () => await ApiAgentsEnableAsync(agentId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task ApiAgentsEnableAsync(int agentId, System.Threading.CancellationToken cancellationToken)
        {
            if (agentId == null)
                throw new System.ArgumentNullException("agentId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/agents/enable/{agentId}");
            urlBuilder_.Replace("{agentId}", System.Uri.EscapeDataString(ConvertToString(agentId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Content = new System.Net.Http.StringContent(string.Empty, System.Text.Encoding.UTF8, "application/json");
                    request_.Method = new System.Net.Http.HttpMethod("PUT");

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            return;
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task ApiAgentsDisableAsync(int agentId)
        {
            return ApiAgentsDisableAsync(agentId, System.Threading.CancellationToken.None);
        }

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public void ApiAgentsDisable(int agentId)
        {
            System.Threading.Tasks.Task.Run(async () => await ApiAgentsDisableAsync(agentId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task ApiAgentsDisableAsync(int agentId, System.Threading.CancellationToken cancellationToken)
        {
            if (agentId == null)
                throw new System.ArgumentNullException("agentId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/agents/disable/{agentId}");
            urlBuilder_.Replace("{agentId}", System.Uri.EscapeDataString(ConvertToString(agentId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Content = new System.Net.Http.StringContent(string.Empty, System.Text.Encoding.UTF8, "application/json");
                    request_.Method = new System.Net.Http.HttpMethod("PUT");

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            return;
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task ApiAgentsGetagentbyidAsync(int agentId)
        {
            return ApiAgentsGetagentbyidAsync(agentId, System.Threading.CancellationToken.None);
        }

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public void ApiAgentsGetagentbyid(int agentId)
        {
            System.Threading.Tasks.Task.Run(async () => await ApiAgentsGetagentbyidAsync(agentId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task ApiAgentsGetagentbyidAsync(int agentId, System.Threading.CancellationToken cancellationToken)
        {
            if (agentId == null)
                throw new System.ArgumentNullException("agentId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/agents/getagentbyid/{agentId}");
            urlBuilder_.Replace("{agentId}", System.Uri.EscapeDataString(ConvertToString(agentId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            return;
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task ApiAgentsGetagentsAsync()
        {
            return ApiAgentsGetagentsAsync(System.Threading.CancellationToken.None);
        }

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public void ApiAgentsGetagents()
        {
            System.Threading.Tasks.Task.Run(async () => await ApiAgentsGetagentsAsync(System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task ApiAgentsGetagentsAsync(System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/agents/getagents");

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            return;
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Получает CPU метрики от агента в заданном диапазоне времени</summary>
        /// <param name="agentId">ID агента</param>
        /// <param name="fromTime">начальнвй момент времени 2021-04-13T05:00:00+00:00</param>
        /// <param name="toTime">конечный  момент времени 2021-04-13T05:00:20+00:00</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task ApiCpumetricsAgentFromToAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime)
        {
            return ApiCpumetricsAgentFromToAsync(agentId, fromTime, toTime, System.Threading.CancellationToken.None);
        }

        /// <summary>Получает CPU метрики от агента в заданном диапазоне времени</summary>
        /// <param name="agentId">ID агента</param>
        /// <param name="fromTime">начальнвй момент времени 2021-04-13T05:00:00+00:00</param>
        /// <param name="toTime">конечный  момент времени 2021-04-13T05:00:20+00:00</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public void ApiCpumetricsAgentFromTo(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime)
        {
            System.Threading.Tasks.Task.Run(async () => await ApiCpumetricsAgentFromToAsync(agentId, fromTime, toTime, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Получает CPU метрики от агента в заданном диапазоне времени</summary>
        /// <param name="agentId">ID агента</param>
        /// <param name="fromTime">начальнвй момент времени 2021-04-13T05:00:00+00:00</param>
        /// <param name="toTime">конечный  момент времени 2021-04-13T05:00:20+00:00</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task ApiCpumetricsAgentFromToAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, System.Threading.CancellationToken cancellationToken)
        {
            if (agentId == null)
                throw new System.ArgumentNullException("agentId");

            if (fromTime == null)
                throw new System.ArgumentNullException("fromTime");

            if (toTime == null)
                throw new System.ArgumentNullException("toTime");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/cpumetrics/agent/{agentId}/from/{fromTime}/to/{toTime}");
            urlBuilder_.Replace("{agentId}", System.Uri.EscapeDataString(ConvertToString(agentId, System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{fromTime}", System.Uri.EscapeDataString(fromTime.ToString("s", System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{toTime}", System.Uri.EscapeDataString(toTime.ToString("s", System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            return;
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task ApiCpumetricsAgentFromToPercentilesAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, int percentile)
        {
            return ApiCpumetricsAgentFromToPercentilesAsync(agentId, fromTime, toTime, percentile, System.Threading.CancellationToken.None);
        }

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public void ApiCpumetricsAgentFromToPercentiles(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, int percentile)
        {
            System.Threading.Tasks.Task.Run(async () => await ApiCpumetricsAgentFromToPercentilesAsync(agentId, fromTime, toTime, percentile, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task ApiCpumetricsAgentFromToPercentilesAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, int percentile, System.Threading.CancellationToken cancellationToken)
        {
            if (agentId == null)
                throw new System.ArgumentNullException("agentId");

            if (fromTime == null)
                throw new System.ArgumentNullException("fromTime");

            if (toTime == null)
                throw new System.ArgumentNullException("toTime");

            if (percentile == null)
                throw new System.ArgumentNullException("percentile");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/cpumetrics/agent/{agentId}/from/{fromTime}/to/{toTime}/percentiles/{percentile}");
            urlBuilder_.Replace("{agentId}", System.Uri.EscapeDataString(ConvertToString(agentId, System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{fromTime}", System.Uri.EscapeDataString(fromTime.ToString("s", System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{toTime}", System.Uri.EscapeDataString(toTime.ToString("s", System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{percentile}", System.Uri.EscapeDataString(ConvertToString(percentile, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            return;
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task ApiDotnetmetricsAgentFromToAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime)
        {
            return ApiDotnetmetricsAgentFromToAsync(agentId, fromTime, toTime, System.Threading.CancellationToken.None);
        }

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public void ApiDotnetmetricsAgentFromTo(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime)
        {
            System.Threading.Tasks.Task.Run(async () => await ApiDotnetmetricsAgentFromToAsync(agentId, fromTime, toTime, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task ApiDotnetmetricsAgentFromToAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, System.Threading.CancellationToken cancellationToken)
        {
            if (agentId == null)
                throw new System.ArgumentNullException("agentId");

            if (fromTime == null)
                throw new System.ArgumentNullException("fromTime");

            if (toTime == null)
                throw new System.ArgumentNullException("toTime");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/dotnetmetrics/agent/{agentId}/from/{fromTime}/to/{toTime}");
            urlBuilder_.Replace("{agentId}", System.Uri.EscapeDataString(ConvertToString(agentId, System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{fromTime}", System.Uri.EscapeDataString(fromTime.ToString("s", System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{toTime}", System.Uri.EscapeDataString(toTime.ToString("s", System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            return;
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task ApiDotnetmetricsAgentFromToPercentilesAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, int percentile)
        {
            return ApiDotnetmetricsAgentFromToPercentilesAsync(agentId, fromTime, toTime, percentile, System.Threading.CancellationToken.None);
        }

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public void ApiDotnetmetricsAgentFromToPercentiles(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, int percentile)
        {
            System.Threading.Tasks.Task.Run(async () => await ApiDotnetmetricsAgentFromToPercentilesAsync(agentId, fromTime, toTime, percentile, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task ApiDotnetmetricsAgentFromToPercentilesAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, int percentile, System.Threading.CancellationToken cancellationToken)
        {
            if (agentId == null)
                throw new System.ArgumentNullException("agentId");

            if (fromTime == null)
                throw new System.ArgumentNullException("fromTime");

            if (toTime == null)
                throw new System.ArgumentNullException("toTime");

            if (percentile == null)
                throw new System.ArgumentNullException("percentile");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/dotnetmetrics/agent/{agentId}/from/{fromTime}/to/{toTime}/percentiles/{percentile}");
            urlBuilder_.Replace("{agentId}", System.Uri.EscapeDataString(ConvertToString(agentId, System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{fromTime}", System.Uri.EscapeDataString(fromTime.ToString("s", System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{toTime}", System.Uri.EscapeDataString(toTime.ToString("s", System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{percentile}", System.Uri.EscapeDataString(ConvertToString(percentile, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            return;
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task ApiHddmetricsAgentFromToAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime)
        {
            return ApiHddmetricsAgentFromToAsync(agentId, fromTime, toTime, System.Threading.CancellationToken.None);
        }

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public void ApiHddmetricsAgentFromTo(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime)
        {
            System.Threading.Tasks.Task.Run(async () => await ApiHddmetricsAgentFromToAsync(agentId, fromTime, toTime, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task ApiHddmetricsAgentFromToAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, System.Threading.CancellationToken cancellationToken)
        {
            if (agentId == null)
                throw new System.ArgumentNullException("agentId");

            if (fromTime == null)
                throw new System.ArgumentNullException("fromTime");

            if (toTime == null)
                throw new System.ArgumentNullException("toTime");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/hddmetrics/agent/{agentId}/from/{fromTime}/to/{toTime}");
            urlBuilder_.Replace("{agentId}", System.Uri.EscapeDataString(ConvertToString(agentId, System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{fromTime}", System.Uri.EscapeDataString(fromTime.ToString("s", System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{toTime}", System.Uri.EscapeDataString(toTime.ToString("s", System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            return;
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task ApiHddmetricsAgentFromToPercentilesAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, int percentile)
        {
            return ApiHddmetricsAgentFromToPercentilesAsync(agentId, fromTime, toTime, percentile, System.Threading.CancellationToken.None);
        }

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public void ApiHddmetricsAgentFromToPercentiles(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, int percentile)
        {
            System.Threading.Tasks.Task.Run(async () => await ApiHddmetricsAgentFromToPercentilesAsync(agentId, fromTime, toTime, percentile, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task ApiHddmetricsAgentFromToPercentilesAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, int percentile, System.Threading.CancellationToken cancellationToken)
        {
            if (agentId == null)
                throw new System.ArgumentNullException("agentId");

            if (fromTime == null)
                throw new System.ArgumentNullException("fromTime");

            if (toTime == null)
                throw new System.ArgumentNullException("toTime");

            if (percentile == null)
                throw new System.ArgumentNullException("percentile");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/hddmetrics/agent/{agentId}/from/{fromTime}/to/{toTime}/percentiles/{percentile}");
            urlBuilder_.Replace("{agentId}", System.Uri.EscapeDataString(ConvertToString(agentId, System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{fromTime}", System.Uri.EscapeDataString(fromTime.ToString("s", System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{toTime}", System.Uri.EscapeDataString(toTime.ToString("s", System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{percentile}", System.Uri.EscapeDataString(ConvertToString(percentile, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            return;
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task ApiNetworkmetricsAgentFromToAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime)
        {
            return ApiNetworkmetricsAgentFromToAsync(agentId, fromTime, toTime, System.Threading.CancellationToken.None);
        }

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public void ApiNetworkmetricsAgentFromTo(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime)
        {
            System.Threading.Tasks.Task.Run(async () => await ApiNetworkmetricsAgentFromToAsync(agentId, fromTime, toTime, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task ApiNetworkmetricsAgentFromToAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, System.Threading.CancellationToken cancellationToken)
        {
            if (agentId == null)
                throw new System.ArgumentNullException("agentId");

            if (fromTime == null)
                throw new System.ArgumentNullException("fromTime");

            if (toTime == null)
                throw new System.ArgumentNullException("toTime");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/networkmetrics/agent/{agentId}/from/{fromTime}/to/{toTime}");
            urlBuilder_.Replace("{agentId}", System.Uri.EscapeDataString(ConvertToString(agentId, System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{fromTime}", System.Uri.EscapeDataString(fromTime.ToString("s", System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{toTime}", System.Uri.EscapeDataString(toTime.ToString("s", System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            return;
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task ApiNetworkmetricsAgentFromToPercentilesAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, int percentile)
        {
            return ApiNetworkmetricsAgentFromToPercentilesAsync(agentId, fromTime, toTime, percentile, System.Threading.CancellationToken.None);
        }

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public void ApiNetworkmetricsAgentFromToPercentiles(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, int percentile)
        {
            System.Threading.Tasks.Task.Run(async () => await ApiNetworkmetricsAgentFromToPercentilesAsync(agentId, fromTime, toTime, percentile, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task ApiNetworkmetricsAgentFromToPercentilesAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, int percentile, System.Threading.CancellationToken cancellationToken)
        {
            if (agentId == null)
                throw new System.ArgumentNullException("agentId");

            if (fromTime == null)
                throw new System.ArgumentNullException("fromTime");

            if (toTime == null)
                throw new System.ArgumentNullException("toTime");

            if (percentile == null)
                throw new System.ArgumentNullException("percentile");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/networkmetrics/agent/{agentId}/from/{fromTime}/to/{toTime}/percentiles/{percentile}");
            urlBuilder_.Replace("{agentId}", System.Uri.EscapeDataString(ConvertToString(agentId, System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{fromTime}", System.Uri.EscapeDataString(fromTime.ToString("s", System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{toTime}", System.Uri.EscapeDataString(toTime.ToString("s", System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{percentile}", System.Uri.EscapeDataString(ConvertToString(percentile, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            return;
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task ApiRammetricsAgentFromToAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime)
        {
            return ApiRammetricsAgentFromToAsync(agentId, fromTime, toTime, System.Threading.CancellationToken.None);
        }

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public void ApiRammetricsAgentFromTo(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime)
        {
            System.Threading.Tasks.Task.Run(async () => await ApiRammetricsAgentFromToAsync(agentId, fromTime, toTime, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task ApiRammetricsAgentFromToAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, System.Threading.CancellationToken cancellationToken)
        {
            if (agentId == null)
                throw new System.ArgumentNullException("agentId");

            if (fromTime == null)
                throw new System.ArgumentNullException("fromTime");

            if (toTime == null)
                throw new System.ArgumentNullException("toTime");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/rammetrics/agent/{agentId}/from/{fromTime}/to/{toTime}");
            urlBuilder_.Replace("{agentId}", System.Uri.EscapeDataString(ConvertToString(agentId, System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{fromTime}", System.Uri.EscapeDataString(fromTime.ToString("s", System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{toTime}", System.Uri.EscapeDataString(toTime.ToString("s", System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            return;
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task ApiRammetricsAgentFromToPercentilesAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, int percentile)
        {
            return ApiRammetricsAgentFromToPercentilesAsync(agentId, fromTime, toTime, percentile, System.Threading.CancellationToken.None);
        }

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public void ApiRammetricsAgentFromToPercentiles(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, int percentile)
        {
            System.Threading.Tasks.Task.Run(async () => await ApiRammetricsAgentFromToPercentilesAsync(agentId, fromTime, toTime, percentile, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task ApiRammetricsAgentFromToPercentilesAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, int percentile, System.Threading.CancellationToken cancellationToken)
        {
            if (agentId == null)
                throw new System.ArgumentNullException("agentId");

            if (fromTime == null)
                throw new System.ArgumentNullException("fromTime");

            if (toTime == null)
                throw new System.ArgumentNullException("toTime");

            if (percentile == null)
                throw new System.ArgumentNullException("percentile");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/rammetrics/agent/{agentId}/from/{fromTime}/to/{toTime}/percentiles/{percentile}");
            urlBuilder_.Replace("{agentId}", System.Uri.EscapeDataString(ConvertToString(agentId, System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{fromTime}", System.Uri.EscapeDataString(fromTime.ToString("s", System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{toTime}", System.Uri.EscapeDataString(toTime.ToString("s", System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{percentile}", System.Uri.EscapeDataString(ConvertToString(percentile, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            return;
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        protected struct ObjectResponseResult<T>
        {
            public ObjectResponseResult(T responseObject, string responseText)
            {
                this.Object = responseObject;
                this.Text = responseText;
            }

            public T Object { get; }

            public string Text { get; }
        }

        public bool ReadResponseAsString { get; set; }

        protected virtual async System.Threading.Tasks.Task<ObjectResponseResult<T>> ReadObjectResponseAsync<T>(System.Net.Http.HttpResponseMessage response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Threading.CancellationToken cancellationToken)
        {
            if (response == null || response.Content == null)
            {
                return new ObjectResponseResult<T>(default(T), string.Empty);
            }

            if (ReadResponseAsString)
            {
                var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    var typedBody = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseText, JsonSerializerSettings);
                    return new ObjectResponseResult<T>(typedBody, responseText);
                }
                catch (Newtonsoft.Json.JsonException exception)
                {
                    var message = "Could not deserialize the response body string as " + typeof(T).FullName + ".";
                    throw new ApiException(message, (int)response.StatusCode, responseText, headers, exception);
                }
            }
            else
            {
                try
                {
                    using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                    using (var streamReader = new System.IO.StreamReader(responseStream))
                    using (var jsonTextReader = new Newtonsoft.Json.JsonTextReader(streamReader))
                    {
                        var serializer = Newtonsoft.Json.JsonSerializer.Create(JsonSerializerSettings);
                        var typedBody = serializer.Deserialize<T>(jsonTextReader);
                        return new ObjectResponseResult<T>(typedBody, string.Empty);
                    }
                }
                catch (Newtonsoft.Json.JsonException exception)
                {
                    var message = "Could not deserialize the response body stream as " + typeof(T).FullName + ".";
                    throw new ApiException(message, (int)response.StatusCode, string.Empty, headers, exception);
                }
            }
        }

        private string ConvertToString(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return "";
            }

            if (value is System.Enum)
            {
                var name = System.Enum.GetName(value.GetType(), value);
                if (name != null)
                {
                    var field = System.Reflection.IntrospectionExtensions.GetTypeInfo(value.GetType()).GetDeclaredField(name);
                    if (field != null)
                    {
                        var attribute = System.Reflection.CustomAttributeExtensions.GetCustomAttribute(field, typeof(System.Runtime.Serialization.EnumMemberAttribute))
                            as System.Runtime.Serialization.EnumMemberAttribute;
                        if (attribute != null)
                        {
                            return attribute.Value != null ? attribute.Value : name;
                        }
                    }

                    var converted = System.Convert.ToString(System.Convert.ChangeType(value, System.Enum.GetUnderlyingType(value.GetType()), cultureInfo));
                    return converted == null ? string.Empty : converted;
                }
            }
            else if (value is bool)
            {
                return System.Convert.ToString((bool)value, cultureInfo).ToLowerInvariant();
            }
            else if (value is byte[])
            {
                return System.Convert.ToBase64String((byte[])value);
            }
            else if (value.GetType().IsArray)
            {
                var array = System.Linq.Enumerable.OfType<object>((System.Array)value);
                return string.Join(",", System.Linq.Enumerable.Select(array, o => ConvertToString(o, cultureInfo)));
            }

            var result = System.Convert.ToString(value, cultureInfo);
            return result == null ? "" : result;
        }
    }



    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.10.9.0 (NJsonSchema v10.4.1.0 (Newtonsoft.Json v11.0.0.0))")]
    public partial class ApiException : System.Exception
    {
        public int StatusCode { get; private set; }

        public string Response { get; private set; }

        public System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> Headers { get; private set; }

        public ApiException(string message, int statusCode, string response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Exception innerException)
            : base(message + "\n\nStatus: " + statusCode + "\nResponse: \n" + ((response == null) ? "(null)" : response.Substring(0, response.Length >= 512 ? 512 : response.Length)), innerException)
        {
            StatusCode = statusCode;
            Response = response;
            Headers = headers;
        }

        public override string ToString()
        {
            return string.Format("HTTP Response: \n\n{0}\n\n{1}", Response, base.ToString());
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.10.9.0 (NJsonSchema v10.4.1.0 (Newtonsoft.Json v11.0.0.0))")]
    public partial class ApiException<TResult> : ApiException
    {
        public TResult Result { get; private set; }

        public ApiException(string message, int statusCode, string response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, TResult result, System.Exception innerException)
            : base(message, statusCode, response, headers, innerException)
        {
            Result = result;
        }
    }
}
