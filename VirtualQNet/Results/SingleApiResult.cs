using Newtonsoft.Json;

namespace VirtualQNet.Results
{
    internal class SingleApiResult<T>
    {
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
