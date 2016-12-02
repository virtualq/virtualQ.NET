using System;
using System.Threading.Tasks;
using VirtualQNet.Results;

namespace VirtualQNet.LineGroups
{
    internal class LineGroupsHandler : EntityHandler, ILineGroupsHandler
    {
        public LineGroupsHandler(ApiClient apiClient): base(apiClient) { }

        private const string LINE_GROUPS_PATH = "line_groups";

        public async Task<Result> UpdateLineGroup(long lineGroupId, LineGroupAttributes attributes)
        {
            CallResult callResult = await _ApiClient.Put($"{LINE_GROUPS_PATH}/{lineGroupId}", attributes);
            return new Result(callResult.RequestWasSuccessful, callResult.Error);
        }
    }
}
