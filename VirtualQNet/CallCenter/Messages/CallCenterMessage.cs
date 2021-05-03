using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualQNet.Common.Messages;

namespace VirtualQNet.CallCenter.Messages
{
    internal class CallCenterMessage : ApiMessage<CallCenterCreateMessageAttributes> { }

    internal class CallCenterMessage1 : ApiMessage<CallCenterUpdateAttributes> { }
}
