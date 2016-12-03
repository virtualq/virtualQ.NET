using System.Threading.Tasks;
using VirtualQNet.Results;

namespace VirtualQNet.LineGroups
{
    internal class LineGroupsHandler : EntityHandler, ILineGroupsHandler
    {
        public LineGroupsHandler(ApiClient apiClient): base(apiClient) { }

        private const string LINE_GROUPS_PATH = "line_groups";

        public async Task<Result> UpdateLineGroup(long lineGroupId, UpdateLineGroupAttributes attributes)
        {
            string path = $"{LINE_GROUPS_PATH}/{lineGroupId}";
            LineGroupAttributes lineGroupAttributes = new LineGroupAttributes
            {
                ServiceAgentsCount = attributes.ServiceAgentsCount,
                ServiceAverageTalkTime = attributes.ServiceAverageTalkTime,
                ServiceEwt = attributes.ServiceEwt,
                ServiceOpen = attributes.ServiceOpen,
                ServiceWaitersCount = attributes.ServiceWaitersCount,
                ServiceAgentList = attributes.ServiceAgentList
            };

            CallResult callResult = await _ApiClient.Put(path, lineGroupAttributes);

            return new Result(callResult.RequestWasSuccessful, callResult.ErrorDescription);
        }
    }
}
