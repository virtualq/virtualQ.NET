﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace VirtualQNet.LineGroups
{
    public class LineGroupAttributes
    {
        [JsonProperty("service_agents_count")]
        public int ServiceAgentsCount { get; set; }

        [JsonProperty("service_average_talk_time")]
        public int ServiceAverageTalkTime { get; set; }

        [JsonProperty("service_ewt")]
        public int ServiceEwt { get; set; }

        [JsonProperty("service_open")]
        public bool ServiceOpen { get; set; }

        [JsonProperty("service_waiters_count")]
        public int ServiceWaitersCount { get; set; }

        [JsonProperty("service_agent_list")]
        IEnumerable<long> ServiceAgentList { get; set; }
    }
}
