using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Client
{
    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.10.9.0 (NJsonSchema v10.4.1.0 (Newtonsoft.Json v11.0.0.0))")]
    public partial interface INswagMetricsAgentClient
    {
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiAgentsRegisterAddressAsync(string agentAddress);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        void ApiAgentsRegisterAddress(string agentAddress);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiAgentsRegisterAddressAsync(string agentAddress, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiAgentsDeleteAsync(int agentId);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        void ApiAgentsDelete(int agentId);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiAgentsDeleteAsync(int agentId, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiAgentsEnableAsync(int agentId);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        void ApiAgentsEnable(int agentId);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiAgentsEnableAsync(int agentId, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiAgentsDisableAsync(int agentId);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        void ApiAgentsDisable(int agentId);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiAgentsDisableAsync(int agentId, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiAgentsGetagentbyidAsync(int agentId);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        void ApiAgentsGetagentbyid(int agentId);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiAgentsGetagentbyidAsync(int agentId, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiAgentsGetagentsAsync();

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        void ApiAgentsGetagents();

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiAgentsGetagentsAsync(System.Threading.CancellationToken cancellationToken);

        /// <summary>Получает CPU метрики от агента в заданном диапазоне времени</summary>
        /// <param name="agentId">ID агента</param>
        /// <param name="fromTime">начальнвй момент времени 2021-04-13T05:00:00+00:00</param>
        /// <param name="toTime">конечный  момент времени 2021-04-13T05:00:20+00:00</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiCpumetricsAgentFromToAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime);

        /// <summary>Получает CPU метрики от агента в заданном диапазоне времени</summary>
        /// <param name="agentId">ID агента</param>
        /// <param name="fromTime">начальнвй момент времени 2021-04-13T05:00:00+00:00</param>
        /// <param name="toTime">конечный  момент времени 2021-04-13T05:00:20+00:00</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        void ApiCpumetricsAgentFromTo(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Получает CPU метрики от агента в заданном диапазоне времени</summary>
        /// <param name="agentId">ID агента</param>
        /// <param name="fromTime">начальнвй момент времени 2021-04-13T05:00:00+00:00</param>
        /// <param name="toTime">конечный  момент времени 2021-04-13T05:00:20+00:00</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiCpumetricsAgentFromToAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiCpumetricsAgentFromToPercentilesAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, int percentile);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        void ApiCpumetricsAgentFromToPercentiles(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, int percentile);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiCpumetricsAgentFromToPercentilesAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, int percentile, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiDotnetmetricsAgentFromToAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        void ApiDotnetmetricsAgentFromTo(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiDotnetmetricsAgentFromToAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiDotnetmetricsAgentFromToPercentilesAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, int percentile);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        void ApiDotnetmetricsAgentFromToPercentiles(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, int percentile);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiDotnetmetricsAgentFromToPercentilesAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, int percentile, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiHddmetricsAgentFromToAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        void ApiHddmetricsAgentFromTo(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiHddmetricsAgentFromToAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiHddmetricsAgentFromToPercentilesAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, int percentile);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        void ApiHddmetricsAgentFromToPercentiles(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, int percentile);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiHddmetricsAgentFromToPercentilesAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, int percentile, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiNetworkmetricsAgentFromToAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        void ApiNetworkmetricsAgentFromTo(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiNetworkmetricsAgentFromToAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiNetworkmetricsAgentFromToPercentilesAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, int percentile);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        void ApiNetworkmetricsAgentFromToPercentiles(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, int percentile);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiNetworkmetricsAgentFromToPercentilesAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, int percentile, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiRammetricsAgentFromToAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        void ApiRammetricsAgentFromTo(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiRammetricsAgentFromToAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiRammetricsAgentFromToPercentilesAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, int percentile);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        void ApiRammetricsAgentFromToPercentiles(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, int percentile);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiRammetricsAgentFromToPercentilesAsync(int agentId, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, int percentile, System.Threading.CancellationToken cancellationToken);

    }


}
