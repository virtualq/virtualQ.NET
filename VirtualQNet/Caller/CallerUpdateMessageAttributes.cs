using Newtonsoft.Json;

namespace VirtualQNet.Caller
{
    internal class CallerUpdateMessageAttributes
    {
        [JsonProperty("line_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? LineId { get; set; }

        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; set; }

        [JsonProperty("service_waiter_state", NullValueHandling = NullValueHandling.Ignore)]
        public string ServiceCallerState { get; set; }

        [JsonProperty("wait_time_when_up", NullValueHandling = NullValueHandling.Ignore)]
        public int? WaitTimeWhenUp { get; set; }

        [JsonProperty("agent_id", NullValueHandling = NullValueHandling.Ignore)]
        public string AgentId { get; set; }
    }
}