using System.Threading.Tasks;
using VirtualQNet.Results;

namespace VirtualQNet.Caller
{
    public interface ICallerHandler
    {
        Task<Result> LineUpCaller(LineUpCallerParameters attributes);
        Task<Result> NotifyCallerConnected(CallerParameters attributes);
        Task<Result> NotifyCallerTransferred(NotifyCallerTransferredParameters attributes);
        Task<Result<bool>> VerifyCaller(CallerParameters attributes);
    }
}
