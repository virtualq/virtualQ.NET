using Newtonsoft.Json;

namespace VirtualQNet
{
    internal class SingleResult<T>
    {
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
