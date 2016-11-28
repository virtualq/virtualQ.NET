using Newtonsoft.Json;

namespace VirtualQNet
{
    internal class SingleEntityResult<T>
    {
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
