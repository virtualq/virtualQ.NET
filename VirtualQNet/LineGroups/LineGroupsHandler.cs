using System;
using System.Threading.Tasks;

namespace VirtualQNet.LineGroups
{
    internal class LineGroupsHandler : EntityHandler, ILineGroupsHandler
    {
        public LineGroupsHandler(ApiClient apiClient): base(apiClient) { }

        private const string LINE_GROUPS_PATH = "line_groups";

        public async Task UpdateLineGroup(long lineGroupId, LineGroupAttributes attributes)
        {
            try
            {
                await _ApiClient.Put<LineGroupAttributes>($"{LINE_GROUPS_PATH}/{lineGroupId}", attributes);
            }
            catch (Exception exception)
            {
                // TODO: Properly handle server errors
                throw new VirtualQException(exception.Message);
            }
        }
    }
}
