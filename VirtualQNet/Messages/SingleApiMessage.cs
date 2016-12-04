using Newtonsoft.Json;

namespace VirtualQNet.Messages
{
    internal class SingleApiMessage<T>
    {
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
