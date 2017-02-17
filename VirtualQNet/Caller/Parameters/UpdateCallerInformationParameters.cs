using System.Collections.Generic;
using System.Dynamic;

namespace VirtualQNet.Caller
{
    public class UpdateCallerInformationParameters: CallerParameters
    {
        public IEnumerable<string> Skills { get; set; }
        public ExpandoObject Properties { get; set; }
        public int? EWT { get; set; }
        public string ServiceState { get; set; }
        public int? WaitTimeWhenUp { get; set; }
        public int? TalkTime { get; set; }
        public string AgentId { get; set; }
    }
}