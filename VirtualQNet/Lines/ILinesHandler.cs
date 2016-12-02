using System.Threading.Tasks;
using VirtualQNet.Results;

namespace VirtualQNet.Lines
{
    public interface ILinesHandler
    {
        Task<Result<bool>> IsVirtualQActive(long lineId);
    }
}
