using Newtonsoft.Json;

namespace VirtualQNet.LineGroups.Messages
{
    internal class LineGroupMessageAttributes
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("allow-callback", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AllowCallback { get; set; }

        [JsonProperty("allow-sms", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AllowSms { get; set; }

        [JsonProperty("cc-type", NullValueHandling = NullValueHandling.Ignore)]
        public string CcType { get; set; }

        [JsonProperty("foresight-closing-in-minutes", NullValueHandling = NullValueHandling.Ignore)]
        public int? ForesightClosingInMinutes { get; set; }

        [JsonProperty("virtualq-min-agent-count", NullValueHandling = NullValueHandling.Ignore)]
        public int? VirtualQMinAgentCount { get; set; }

        [JsonProperty("virtualq-min-waiting-time", NullValueHandling = NullValueHandling.Ignore)]
        public int? VirtualQMinWaitingTime { get; set; }

        [JsonProperty("virtualq-notice-time", NullValueHandling = NullValueHandling.Ignore)]
        public int? VirtualQNoticeTime { get; set; }

        [JsonProperty("virtualq-timeout-time", NullValueHandling = NullValueHandling.Ignore)]
        public int? VirtualQTimeoutTime { get; set; }

        [JsonProperty("virtualq-waiters-count", NullValueHandling = NullValueHandling.Ignore)]
        public int? VirtualQWaitersCount { get; set; }

        [JsonProperty("service-waiters-count", NullValueHandling = NullValueHandling.Ignore)]
        public int? ServiceWaitersCount { get; set; }

        [JsonProperty("service-calls-per-hourt", NullValueHandling = NullValueHandling.Ignore)]
        public int? ServiceCallsPerHour { get; set; }
        

        [JsonProperty("call-center", NullValueHandling = NullValueHandling.Ignore)]
        public CallCenter CallCenter { get; set; }
    }

    internal class CallCenter
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("call_center_open", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CallCenterOpen { get; set; }

        [JsonProperty("virtualq_active", NullValueHandling = NullValueHandling.Ignore)]
        public bool? VirtualQActive { get; set; }
    }
}
