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
        public ApiClient(string apiKey) : this(apiKey, null, null) { }
        public ApiClient(string apiKey, IWebProxy proxy) : this(apiKey, proxy, null) { }
        public ApiClient(string apiKey, IWebProxy proxy, Uri apiUri)
        {
            _ApiKey = apiKey;
            _Client = SetUpClient(proxy, apiUri);
        }

        private string _ApiKey { get; }
        private HttpClient _Client { get; }

        private HttpClient SetUpClient(IWebProxy proxy, Uri apiUri) {
            const string BASE_ADDRESS = "https://api.virtualq.io/api/v2";
            const bool DISPOSE_HANDLER = true;

            HttpClient client = proxy == null
                ? new HttpClient()
                : new HttpClient(SetUpClientHandler(proxy), DISPOSE_HANDLER);
            client.BaseAddress = apiUri ?? new Uri(BASE_ADDRESS);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("X-Api-Key", _ApiKey);

            return client;
        }

        private HttpClientHandler SetUpClientHandler(IWebProxy proxy) =>
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
            string errorMessage = errorResults.Errors.FirstOrDefault()?.Detail ?? string.Empty;

            return new CallResult { RequestWasSuccessful = false, Error = errorMessage };
        }

        private async Task<CallResult<T>> HandleResponse<T>(HttpResponseMessage response)
        {
            CallResult callResult = await HandleResponse(response);
            CallResult<T> result = new CallResult<T>
            {
                RequestWasSuccessful = callResult.RequestWasSuccessful,
                Error = callResult.Error
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
                Error = exception.Message
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
