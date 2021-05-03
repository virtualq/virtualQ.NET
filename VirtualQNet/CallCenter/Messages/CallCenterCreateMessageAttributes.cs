using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualQNet.CallCenter.Messages
{
    internal class CallCenterCreateMessageAttributes
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("call_center_open", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CallCenterOpen { get; set; }

        [JsonProperty("trigger_call_active", NullValueHandling = NullValueHandling.Ignore)]
        public string TriggerCallActive { get; set; }

        [JsonProperty("triger_call_frequency_in_minutes", NullValueHandling = NullValueHandling.Ignore)]
        public int? TrigerCallFrequencyInMinutes { get; set; }

        [JsonProperty("trigger_call_phone_number", NullValueHandling = NullValueHandling.Ignore)]
        public string TriggerCallPhoneNumber { get; set; }

        [JsonProperty("virtualq_active", NullValueHandling = NullValueHandling.Ignore)]
        public bool? VirtualqActive { get; set; }

        [JsonProperty("allow_manual", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AllowManual { get; set; }

        [JsonProperty("timezone", NullValueHandling = NullValueHandling.Ignore)]
        public string TimeZone { get; set; }

        [JsonProperty("acd_type_version", NullValueHandling = NullValueHandling.Ignore)]
        public string AcdTypeVersion { get; set; }

        [JsonProperty("connector-version", NullValueHandling = NullValueHandling.Ignore)]
        public string ConnectorVersion { get; set; }

        [JsonProperty("notes", NullValueHandling = NullValueHandling.Ignore)]
        public string Notes { get; set; }

        [JsonProperty("connector-configuration", NullValueHandling = NullValueHandling.Ignore)]
        public string ConnectorConfiguration { get; set; }

        [JsonProperty("connector-last-restart-at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ConnectorLastRestartTime { get; set; }

        [JsonProperty("connector-connection-status", NullValueHandling = NullValueHandling.Ignore)]
        public string ConnectorConnectionStatus { get; set; }

    }
}
