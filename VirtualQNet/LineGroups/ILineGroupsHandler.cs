using System.Threading.Tasks;
using VirtualQNet.Results;

namespace VirtualQNet.LineGroups
{
    public interface ILineGroupsHandler
    {
        Task<Result> UpdateLineGroup(long lineGroupId, UpdateLineGroupAttributes attributes);
    }
}
