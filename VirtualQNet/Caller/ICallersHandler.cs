using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualQNet.Results;

namespace VirtualQNet.Caller
{
    public interface ICallersHandler
    {
        Task<Result> LineUpCaller(LineUpCallerParameters attributes);
        Task<Result> NotifyCallerConnected(CallerParameters attributes);
        Task<Result> NotifyCallerTransferred(NotifyCallerTransferredParameters attributes);
        Task<Result<bool>> VerifyCaller(CallerParameters attributes);
        Task<Result> UpdateCallerInformation(UpdateCallerInformationParameters attributes);
        Task<Result<IEnumerable<CallerResult>>> ListCallersWaiting(ListCallersWaitingParameters attributes);
    }
}
