using Newtonsoft.Json;

namespace VirtualQNet.Messages
{
    internal abstract class ApiMessage<T>
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("attributes")]
        public T Attributes { get; set; }
    }
}
