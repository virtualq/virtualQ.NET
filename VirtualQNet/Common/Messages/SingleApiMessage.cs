using Newtonsoft.Json;

namespace VirtualQNet.Common.Messages
{
    internal class SingleApiMessage<T>
    {
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
