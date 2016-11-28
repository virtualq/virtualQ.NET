using System.Threading.Tasks;

namespace VirtualQNet.LineGroups
{
    public interface ILineGroupsHandler
    {
        Task<LineGroup> UpdateLineGroup(long lineGroupId, LineGroupAttributes attributes);
    }
}
