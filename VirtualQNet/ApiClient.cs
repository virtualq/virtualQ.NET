using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using VirtualQNet.Common.Messages;
using VirtualQNet.Common.CallResults;

namespace VirtualQNet
{
    internal class ApiClient: IDisposable
    {
        public ApiClient(string apiKey) : this(apiKey, null) { }
        public ApiClient(string apiKey, VirtualQClientConfiguration configuration)
        {
            _Client = SetUpClient(apiKey, configuration);
        }

        private const string MEDIA_TYPE = "application/vnd.api+json";

        private HttpClient _Client { get; }

        private HttpClient SetUpClient(string apiKey, VirtualQClientConfiguration configuration) {
            const string DEFAULT_BASE_ADDRESS = "https://api.virtualq.io";
            const bool DISPOSE_HANDLER = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            var client = configuration?.ProxyConfiguration == null
                ? new HttpClient()
                : new HttpClient(SetUpClientHandlerForProxy(configuration.ProxyConfiguration), DISPOSE_HANDLER);

            if (configuration?.Timeout != null) client.Timeout = configuration.Timeout.Value;

            string baseAddress = string.IsNullOrWhiteSpace(configuration?.ApiBaseAddress)
                ? DEFAULT_BASE_ADDRESS
                : configuration.ApiBaseAddress;
            client.BaseAddress = new Uri(baseAddress);

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("X-Api-Key", apiKey);
            return client;
        }

        private HttpClientHandler SetUpClientHandlerForProxy(IWebProxy proxy) =>
            new HttpClientHandler
            {
                Proxy = proxy,
                UseProxy = true
            };

        private JsonMediaTypeFormatter CreateCustomMediatypeFormatter()
        {
            var typeFormatter = new JsonMediaTypeFormatter();
            typeFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue(MEDIA_TYPE));

            return typeFormatter;
        }

        private CallResult CreateErrorCallResult(ApiErrorMessage errorMessage)
        {
            int errorStatus = errorMessage?.Status ?? 0;
            var errorDescription = errorMessage?.Detail ?? string.Empty;
            var errorCode = errorMessage?.Code ?? string.Empty;
            var errorTitle = errorMessage?.Title ?? string.Empty;
            var pointer = errorMessage?.Source?.Pointer ?? string.Empty;

            return new CallResult
            {
                RequestWasSuccessful = false,
                Error = new CallErrorResult
                {
                    Code = errorCode,
                    Status = errorStatus,
                    Title = errorTitle,
                    Description = errorDescription,
                    Source = new CallSourceResult
                    {
                        Pointer = pointer
                    }
                }
            };
        }

        private async Task<CallResult> HandleResponse(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
                return new CallResult { RequestWasSuccessful = true };

            bool isNotJsonContent = !response.Content.Headers.ContentType.MediaType.ToLower().Contains("json");
            if (isNotJsonContent)
                response.EnsureSuccessStatusCode();

            var errorResults = await response.Content
                .ReadAsAsync<ArrayApiErrorMessage>(new[] { CreateCustomMediatypeFormatter() });
            var errorMessage = errorResults.Errors.FirstOrDefault();

            return CreateErrorCallResult(errorMessage);
        }

        private async Task<CallResult<T>> HandleResponse<T>(HttpResponseMessage response)
        {
            CallResult callResult = await HandleResponse(response);
            //var jsonContent = await response.Content.ReadAsStringAsync();
            var result = new CallResult<T>
            {
                RequestWasSuccessful = callResult.RequestWasSuccessful,
                Error = callResult.Error
            };

            if (callResult.RequestWasSuccessful)
            {
                T value = await response.Content.ReadAsAsync<T>(new[] { CreateCustomMediatypeFormatter() });
                result.Value = value;
            }

            return result;
        }

        private CallResult HandleException(Exception exception) =>
            new CallResult
            {
                RequestWasSuccessful = false,
                Error = new CallErrorResult
                {
                    Description = exception.Message
                }
            };

        private CallResult<T> HandleException<T>(Exception exception) =>
            new CallResult<T>
            {
                RequestWasSuccessful = false,
                Error = new CallErrorResult
                {
                    Description = exception.Message
                }
            };

        private StringContent CreateContent<T>(T model) =>
            new StringContent(
                    JsonConvert.SerializeObject(model),
                    Encoding.UTF8,
                    MEDIA_TYPE);

        private const string API_ROUTE = "api/v2";
        private string BuildApiPath(string path) => $"{API_ROUTE}/{path}";

        public async Task<CallResult> Get<T>(string path, string id)
        {
            try
            {
                return await HandleResponse(await _Client.GetAsync(BuildApiPath(path)));
            }
            catch (Exception exception)
            {
                return HandleException<T>(exception);
            }
        }

        public async Task<CallResult<T>> Get<T>(string path)
        {
            try
            {
                return await HandleResponse<T>(await _Client.GetAsync(BuildApiPath(path)));
            }
            catch (Exception exception)
            {
                return HandleException<T>(exception);
            }
        }

        public async Task<CallResult> Post<T>(string path, T model)
        {
            try
            {
                var requestContent = CreateContent(model);
                //var jsonContent = await requestContent.ReadAsStringAsync();
                return await HandleResponse(await _Client.PostAsync(BuildApiPath(path), requestContent));
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
                return await HandleResponse<U>(await _Client.PostAsync(BuildApiPath(path), CreateContent(model)));
            }
            catch (Exception exception)
            {
                return HandleException<U>(exception);
            }
        }

        public async Task<CallResult> Put<T>(string path, T model)
        {
            try
            {
                var content = CreateContent(model);
                //var jsonContent = await content.ReadAsStringAsync();
                return await HandleResponse(await _Client.PutAsync(BuildApiPath(path), content));
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
                return await HandleResponse<U>(await _Client.PutAsJsonAsync(BuildApiPath(path), CreateContent(model)));
            }
            catch (Exception exception)
            {
                return HandleException<U>(exception);
            }
        }

        public async Task<CallResult> Delete(string path, long id)
        {
            try
            {
                return await HandleResponse(await _Client.DeleteAsync(BuildApiPath(path)));
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
