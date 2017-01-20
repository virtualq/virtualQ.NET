using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualQNet.Results;

namespace VirtualQNet.Lines
{
    public interface ILinesHandler
    {
        Task<Result<bool>> IsVirtualQActive(long lineId);
        Task<Result<IEnumerable<LineResult>>> ListLines(ListLinesParameters attributes);
    }
}
