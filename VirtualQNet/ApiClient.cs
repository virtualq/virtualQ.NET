using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace VirtualQNet
{
    internal class ApiClient: IDisposable
    {
        public ApiClient(string apiKey) : this(apiKey, null) { }

        public ApiClient(string apiKey, IWebProxy proxy)
        {
            _ApiKey = apiKey;
            _Client = SetUpClient(proxy);
        }

        private string _ApiKey { get; }
        private HttpClient _Client { get; }

        private HttpClient SetUpClient(IWebProxy proxy) {
            // TODO: Get address from config file, otherwise fallback to hard-coded production address.
            const string BASE_ADDRESS = "http://staging-api.virtualq.io/api/v2";
            //const string BASE_ADDRESS = "https://api.virtualq.io/api/v2";

            const bool DISPOSE_HANDLER = true;

            HttpClient client = proxy == null
                ? new HttpClient()
                : new HttpClient(SetUpClientHandler(proxy), DISPOSE_HANDLER);
            client.BaseAddress = new Uri(BASE_ADDRESS);
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

        public async Task<T> Get<T>(string path)
        {
            HttpResponseMessage response = await _Client.GetAsync(path);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<T>();
        }

        public async Task<U> Post<T, U>(string path, T model)
        {
            HttpResponseMessage response = await _Client.PostAsJsonAsync<T>(path, model);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<U>();
        }

        public async Task<U> Put<T, U>(string path, T model)
        {
            HttpResponseMessage response = await _Client.PutAsJsonAsync<T>(path, model);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<U>();
        }

        public async Task Delete(string path, long id)
        {
            HttpResponseMessage response = await _Client.DeleteAsync(path);
            response.EnsureSuccessStatusCode();
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
