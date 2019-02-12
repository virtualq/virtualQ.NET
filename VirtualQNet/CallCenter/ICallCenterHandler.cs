using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualQNet.CallCenter.Parameters;
using VirtualQNet.CallCenter.Results;
using VirtualQNet.Results;

namespace VirtualQNet.CallCenter
{
    public interface ICallCenterHandler
    {
        Task<Result> UpdateCallCenter(UpdateVersionNumberCallCenterParameters updateVersionNumberCallCenterParameters);
        Task<Result<IEnumerable<CallCenterResult>>> ListCallCenters(ListCallCenterParameters attributes);
    }
}
