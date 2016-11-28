using System;
using System.Threading.Tasks;

namespace VirtualQNet.LineGroups
{
    internal class LineGroupsHandler : EntityHandler, ILineGroupsHandler
    {
        public LineGroupsHandler(ApiClient apiClient): base(apiClient) { }

        private const string LINE_GROUPS_PATH = "line_groups";

        public async Task<LineGroup> UpdateLineGroup(long lineGroupId, LineGroupAttributes attributes)
        {
            try
            {
                SingleEntityResult<LineGroup> result = await _ApiClient.Put<LineGroupAttributes, SingleEntityResult<LineGroup>>($"{LINE_GROUPS_PATH}/{lineGroupId}", attributes);

                return result.Data;
            }
            catch (Exception exception)
            {
                throw new VirtualQException(exception.Message);
            }
        }
    }
}
