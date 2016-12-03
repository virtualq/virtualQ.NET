using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using VirtualQNet.Results;

namespace VirtualQNet
{
    internal class ApiClient: IDisposable
    {
        public ApiClient(string apiKey) : this(apiKey, null) { }
        public ApiClient(string apiKey, VirtualQClientConfiguration configuration)
        {
            _Client = SetUpClient(apiKey, configuration);
        }

        private HttpClient _Client { get; }

        private HttpClient SetUpClient(string apiKey, VirtualQClientConfiguration configuration) {
            const string DEFAULT_BASE_ADDRESS = "https://api.virtualq.io";
            const string API_ROUTE = "api/v2";
            const bool DISPOSE_HANDLER = true;

            HttpClient client = configuration?.ProxyConfiguration == null
                ? new HttpClient()
                : new HttpClient(SetUpClientHandlerForProxy(configuration.ProxyConfiguration), DISPOSE_HANDLER);

            if (configuration?.Timeout != null) client.Timeout = configuration.Timeout;

            string baseAddress = string.IsNullOrWhiteSpace(configuration?.ApiBaseAddress)
                ? DEFAULT_BASE_ADDRESS
                : configuration.ApiBaseAddress;
            string apiAddress = $"{baseAddress}/{API_ROUTE}";
            client.BaseAddress = new Uri(apiAddress);

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("X-Api-Key", apiKey);

            return client;
        }

        private HttpClientHandler SetUpClientHandlerForProxy(IWebProxy proxy) =>
            new HttpClientHandler
            {
                Proxy = proxy,
                UseProxy = true
            };

        private async Task<CallResult> HandleResponse(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
                return new CallResult { RequestWasSuccessful = true };

            MultipleApiErrorResults errorResults = await response.Content
                .ReadAsAsync<MultipleApiErrorResults>();
            var error = errorResults.Errors.FirstOrDefault();
            string errorMessage = error?.Detail ?? string.Empty;
            int errorStatus = error?.Status ?? 0;

            return new CallResult
            {
                RequestWasSuccessful = false,
                ErrorStatus = errorStatus,
                ErrorDescription = errorMessage
            };
        }

        private async Task<CallResult<T>> HandleResponse<T>(HttpResponseMessage response)
        {
            CallResult callResult = await HandleResponse(response);
            CallResult<T> result = new CallResult<T>
            {
                RequestWasSuccessful = callResult.RequestWasSuccessful,
                ErrorDescription = callResult.ErrorDescription
            };

            if (callResult.RequestWasSuccessful)
            {
                T value = await response.Content.ReadAsAsync<T>();
                result.Value = value;
            }

            return result;
        }

        private CallResult HandleException(Exception exception) =>
            new CallResult
            {
                RequestWasSuccessful = false,
                ErrorDescription = exception.Message
            };

        public async Task<CallResult<T>> Get<T>(string path)
        {
            try
            {
                return await HandleResponse<T>(await _Client.GetAsync(path));
            }
            catch (Exception exception)
            {
                return HandleException(exception) as CallResult<T>;
            }
        }

        public async Task<CallResult> Post<T>(string path, T model)
        {
            try
            {
                return await HandleResponse(await _Client.PostAsJsonAsync(path, model));
            }
            catch (Exception exception)
            {
                return HandleException(exception);
            }
        }

        public async Task<CallResult<U>> Post<T, U>(string path, T model)
        {
            try
            {
                return await HandleResponse<U>(await _Client.PostAsJsonAsync(path, model));
            }
            catch (Exception exception)
            {
                return HandleException(exception) as CallResult<U>;
            }
        }

        public async Task<CallResult> Put<T>(string path, T model)
        {
            try
            {
                return await HandleResponse(await _Client.PutAsJsonAsync(path, model));
            }
            catch (Exception exception)
            {
                return HandleException(exception);
            }
        }

        public async Task<CallResult<U>> Put<T, U>(string path, T model)
        {
            try
            {
                return await HandleResponse<U>(await _Client.PutAsJsonAsync(path, model));
            }
            catch (Exception exception)
            {
                return HandleException(exception) as CallResult<U>;
            }
        }

        public async Task<CallResult> Delete(string path, long id)
        {
            try
            {
                return await HandleResponse(await _Client.DeleteAsync(path));
            }
            catch (Exception exception)
            {
                return HandleException(exception);
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _Client.Dispose();
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
        }
#endregion
    }
}
