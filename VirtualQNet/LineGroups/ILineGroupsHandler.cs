using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualQNet.Results;

namespace VirtualQNet.LineGroups
{
    public interface ILineGroupsHandler
    {
        Task<Result> UpdateLineGroup(long lineGroupId, UpdateLineGroupParameters attributes);
        Task<Result> UpdateLineGroupCollection(UpdateLineGroupCollectionParameters attributes);
        Task<Result<IEnumerable<LineGroupResult>>> ListLineGroups(ListLineGroupsParameters attributes);
    }
}
