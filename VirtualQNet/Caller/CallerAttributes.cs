using Newtonsoft.Json;

namespace VirtualQNet.Caller
{
    internal class CallerAttributes
    {
        [JsonProperty("line_id")]
        public long? LineId { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("lang")]
        public string Language { get; set; }

        [JsonProperty("service_waiter_state")]
        public string ServiceCallerState { get; set; }

        [JsonProperty("wait_time_when_up")]
        public int? WaitTimeWhenUp { get; set; }

        [JsonProperty("agent_id")]
        public string AgentId { get; set; }
    }
}