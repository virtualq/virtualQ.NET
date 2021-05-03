using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualQNet.CallCenter.Messages
{
    internal class CallCenterUpdateAttributes
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("connector_version", NullValueHandling = NullValueHandling.Ignore)]
        public string ConnectorVersion { get; set; }

        [JsonProperty("connector_configuration", NullValueHandling = NullValueHandling.Ignore)]
        public string ConnectorConfiguration { get; set; }

        [JsonProperty("connector_last_restart_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ConnectorLastRestartTime { get; set; }

        [JsonProperty("connector_connection_status", NullValueHandling = NullValueHandling.Ignore)]
        public string ConnectorConnectionStatus { get; set; }
    }
}
