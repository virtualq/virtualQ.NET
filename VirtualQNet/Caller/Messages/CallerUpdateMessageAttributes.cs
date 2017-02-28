using Newtonsoft.Json;
using System.Collections.Generic;
using System.Dynamic;

namespace VirtualQNet.Caller
{
    internal class CallerUpdateMessageAttributes
    {
        [JsonProperty("line_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? LineId { get; set; }

        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; set; }

        [JsonProperty("skills", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> Skills { get; set; }

        [JsonProperty("properties", NullValueHandling = NullValueHandling.Ignore)]
        public ExpandoObject Properties { get; set; }

        [JsonProperty("service_waiter_ewt", NullValueHandling = NullValueHandling.Ignore)]
        public int? EWT { get; set; }

        [JsonProperty("service_waiter_state", NullValueHandling = NullValueHandling.Ignore)]
        public string ServiceCallerState { get; set; }

        [JsonProperty("wait_time_when_up", NullValueHandling = NullValueHandling.Ignore)]
        public int? WaitTimeWhenUp { get; set; }

        [JsonProperty("agent_id", NullValueHandling = NullValueHandling.Ignore)]
        public string AgentId { get; set; }

        [JsonProperty("talk_time", NullValueHandling = NullValueHandling.Ignore)]
        public int? TalkTime { get; set; }
    }
}
