using System.Threading.Tasks;

namespace VirtualQNet.LineGroups
{
    public interface ILineGroupsHandler
    {
        Task UpdateLineGroup(long lineGroupId, LineGroupAttributes attributes);
    }
}
