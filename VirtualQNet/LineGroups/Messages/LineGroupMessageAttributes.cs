using Newtonsoft.Json;
using System.Collections.Generic;

namespace VirtualQNet.LineGroups
{
    internal class LineGroupMessageAttributes
    {
        [JsonProperty("service_agents_count", NullValueHandling = NullValueHandling.Ignore)]
        public int? ServiceAgentsCount { get; set; }

        [JsonProperty("service_average_talk_time", NullValueHandling = NullValueHandling.Ignore)]
        public int? ServiceAverageTalkTime { get; set; }

        [JsonProperty("service_ewt", NullValueHandling = NullValueHandling.Ignore)]
        public int? ServiceEwt { get; set; }

        [JsonProperty("service_open", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ServiceOpen { get; set; }

        [JsonProperty("service_waiters_count", NullValueHandling = NullValueHandling.Ignore)]
        public int? ServiceCallersCount { get; set; }

        [JsonProperty("service_agent_list", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> ServiceAgentList { get; set; }
    }
}
