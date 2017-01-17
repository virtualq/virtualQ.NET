using Newtonsoft.Json;

namespace VirtualQNet.Common.Messages
{
    internal class ApiErrorMessage
    {
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public int? Status { get; set; }

        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("detail", NullValueHandling = NullValueHandling.Ignore)]
        public string Detail { get; set; }

        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        public ApiErrorSource Source { get; set; }
    }

    internal class ApiErrorSource
    {
        [JsonProperty("pointer", NullValueHandling = NullValueHandling.Ignore)]
        public string Pointer { get; set; }
    }
}
