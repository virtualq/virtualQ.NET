using Newtonsoft.Json;
using System;

namespace VirtualQNet.Caller
{
    internal class CallerMessageAttributes
    {
        [JsonProperty("action-vcc", NullValueHandling = NullValueHandling.Ignore)]
        public string ActionVcc { get; set; }

        [JsonProperty("channel", NullValueHandling = NullValueHandling.Ignore)]
        public string Channel { get; set; }

        [JsonProperty("connected-at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ConnectedAt { get; set; }

        [JsonProperty("created-at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("estimated-up-time-at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? EstimatedUpTimeAt { get; set; }

        [JsonProperty("ewt", NullValueHandling = NullValueHandling.Ignore)]
        public int? Ewt { get; set; }

        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        [JsonProperty("notified-at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? NotifiedAt { get; set; }

        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; set; }

        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get; set; }

        [JsonProperty("token", NullValueHandling = NullValueHandling.Ignore)]
        public string Token { get; set; }

        [JsonProperty("updated-at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("virtualq-waiter-state", NullValueHandling = NullValueHandling.Ignore)]
        public string VirtualQCallerState { get; set; }

        [JsonProperty("wait-time", NullValueHandling = NullValueHandling.Ignore)]
        public int? WaitTime { get; set; }

        [JsonProperty("waiting-time-in-seconds", NullValueHandling = NullValueHandling.Ignore)]
        public int? WaitingTimeInSeconds { get; set; }

        [JsonProperty("line", NullValueHandling = NullValueHandling.Ignore)]
        public Line Line { get; set; }
    }

    internal class Line
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }
}
