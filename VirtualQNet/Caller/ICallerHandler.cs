using System.Threading.Tasks;
using VirtualQNet.Results;

namespace VirtualQNet.Caller
{
    public interface ICallerHandler
    {
        Task<Result> LineUpCaller(LineUpCallerParameters attributes);
        Task<Result<CallerResult>> NotifyCallerConnected(CallerParameters attributes);
        Task<Result<CallerResult>> NotifyCallerTransferred(NotifyCallerTransferredParameters attributes);
        Task<Result<bool>> VerifyCaller(CallerParameters attributes);
    }
}
