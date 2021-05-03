using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualQNet.CallCenter.Parameters
{
    public class UpdateCallCenterParameters
    {
        public long Id { get; set; }
        public string ConnectorVersion { get; set; }
        public DateTime ConnectorLastRestartTime { get; set; }
        public string ConnectorConnectionStatus { get; set; }
    }
}
