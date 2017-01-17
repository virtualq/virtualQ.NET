using Newtonsoft.Json;
using System.Collections.Generic;
using System.Dynamic;

namespace VirtualQNet.Caller
{
    internal class CallerCreateMessageAttributes
    {
        [JsonProperty("line_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? LineId { get; set; }

        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; set; }

        [JsonProperty("channel", NullValueHandling = NullValueHandling.Ignore)]
        public string Channel { get; set; }

        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get; set; }

        [JsonProperty("lang", NullValueHandling = NullValueHandling.Ignore)]
        public string Language { get; set; }

        [JsonProperty("skills", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> Skills { get; set; }

        [JsonProperty("properties", NullValueHandling = NullValueHandling.Ignore)]
        public ExpandoObject Properties { get; set; }
    }
}
