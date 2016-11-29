using Newtonsoft.Json;

namespace VirtualQNet
{
    public abstract class Result<T>
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("attributes")]
        public T Attributes { get; set; }
    }
}
