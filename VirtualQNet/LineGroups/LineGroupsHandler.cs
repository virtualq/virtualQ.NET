using System.Linq;
using System.Threading.Tasks;
using VirtualQNet.Common;
using VirtualQNet.Common.CallResults;
using VirtualQNet.Common.Messages;
using VirtualQNet.Results;

namespace VirtualQNet.LineGroups
{
    internal class LineGroupsHandler : EntityHandler, ILineGroupsHandler
    {
        public LineGroupsHandler(ApiClient apiClient): base(apiClient) { }

        private const string LINE_GROUPS_PATH = "line_groups";
        private const string MESSAGE_TYPE = "line_groups";

        public async Task<Result> UpdateLineGroup(long lineGroupId, UpdateLineGroupParameters attributes)
        {
            var path = $"{LINE_GROUPS_PATH}/{lineGroupId}";
            var messageAttributes = new LineGroupMessageAttributes
            {
                ServiceAgentsCount = attributes.ServiceAgentsCount,
                ServiceAverageTalkTime = attributes.ServiceAverageTalkTime,
                ServiceEwt = attributes.ServiceEwt,
                ServiceOpen = attributes.ServiceOpen,
                ServiceCallersCount = attributes.ServiceCallersCount,
                ServiceAgentList = attributes.ServiceAgentList
            };

            SingleApiMessage<LineGroupMessage> message = CreateSingleMessage<LineGroupMessageAttributes, LineGroupMessage>(MESSAGE_TYPE, messageAttributes);
            CallResult callResult = await _ApiClient.Put(path, message);

            return new Result(callResult.RequestWasSuccessful, CreateErrorResult(callResult));
        }

        public async Task<Result> UpdateLineGroupCollection(UpdateLineGroupCollectionParameters attributes)
        {
            var path = $"{LINE_GROUPS_PATH}/updated";
            var lineGroupMessages = attributes.LineGroups.Select(lg => new LineGroupMessage
            {
                Id = lg.Id,
                Type = MESSAGE_TYPE,
                Attributes = new LineGroupMessageAttributes
                {
                    ServiceAgentList = lg.ServiceAgentList,
                    ServiceAgentsCount = lg.ServiceAgentsCount,
                    ServiceAverageTalkTime = lg.ServiceAverageTalkTime,
                    ServiceCallersCount = lg.ServiceCallersCount,
                    ServiceEwt = lg.ServiceEwt,
                    ServiceOpen = lg.ServiceOpen
                }
            });
            ArrayApiMessage<LineGroupMessage> message = CreateArrayMessage<LineGroupMessageAttributes, LineGroupMessage>(lineGroupMessages);
            CallResult callResult = await _ApiClient.Put(path, message);

            return new Result(callResult.RequestWasSuccessful, CreateErrorResult(callResult));
        }
    }
}
