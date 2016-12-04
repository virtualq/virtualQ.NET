using Newtonsoft.Json;

namespace VirtualQNet.Messages
{
    public class ApiErrorMessage
    {
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }
    }
}
