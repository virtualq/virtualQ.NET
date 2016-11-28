using System.Threading.Tasks;

namespace VirtualQNet.Lines
{
    public interface ILinesHandler
    {
        Task<bool> IsVirtualQActive(long lineId);
    }
}