using System.Collections.Generic;

namespace VirtualQNet.LineGroups
{
    public class UpdateLineGroupParameters
    {
        public long? Id { get; set; }
        public int? ServiceAgentsCount { get; set; }
        public int? ServiceAverageTalkTime { get; set; }
        public int? ServiceEwt { get; set; }
        public bool? ServiceOpen { get; set; }
        public int? ServiceCallersCount { get; set; }
        public int? ServiceCallsPerHour { get; set; }
        public IEnumerable<string> ServiceAgentList { get; set; }
    }
}
