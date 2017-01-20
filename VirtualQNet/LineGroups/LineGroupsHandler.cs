using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualQNet.Common;
using VirtualQNet.Common.CallResults;
using VirtualQNet.Common.Messages;
using VirtualQNet.LineGroups.Messages;
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
            var messageAttributes = new LineGroupUpdateMessageAttributes
            {
                ServiceAgentsCount = attributes.ServiceAgentsCount,
                ServiceAverageTalkTime = attributes.ServiceAverageTalkTime,
                ServiceEwt = attributes.ServiceEwt,
                ServiceOpen = attributes.ServiceOpen,
                ServiceCallersCount = attributes.ServiceCallersCount,
                ServiceAgentList = attributes.ServiceAgentList
            };

            SingleApiMessage<LineGroupUpdateMessage> message = CreateSingleMessage<LineGroupUpdateMessageAttributes, LineGroupUpdateMessage>(MESSAGE_TYPE, messageAttributes);
            CallResult callResult = await _ApiClient.Put(path, message);

            return new Result(callResult.RequestWasSuccessful, CreateErrorResult(callResult));
        }

        public async Task<Result> UpdateLineGroupCollection(UpdateLineGroupCollectionParameters attributes)
        {
            var path = $"{LINE_GROUPS_PATH}/updated";
            var lineGroupMessages = attributes.LineGroups.Select(lg => new LineGroupUpdateMessage
            {
                Id = lg.Id,
                Type = MESSAGE_TYPE,
                Attributes = new LineGroupUpdateMessageAttributes
                {
                    ServiceAgentList = lg.ServiceAgentList,
                    ServiceAgentsCount = lg.ServiceAgentsCount,
                    ServiceAverageTalkTime = lg.ServiceAverageTalkTime,
                    ServiceCallersCount = lg.ServiceCallersCount,
                    ServiceEwt = lg.ServiceEwt,
                    ServiceOpen = lg.ServiceOpen
                }
            });
            ArrayApiMessage<LineGroupUpdateMessage> message = CreateArrayMessage<LineGroupUpdateMessageAttributes, LineGroupUpdateMessage>(lineGroupMessages);
            CallResult callResult = await _ApiClient.Put(path, message);

            return new Result(callResult.RequestWasSuccessful, CreateErrorResult(callResult));
        }

        public async Task<Result<IEnumerable<LineGroupResult>>> ListLineGroups(ListLineGroupsParameters attributes)
        {
            var filter = $"call_center_id={attributes.CallCenterId}";
            var path = $"{LINE_GROUPS_PATH}?{filter}";

            CallResult<ArrayApiMessage<LineGroupMessage>> callResult = await _ApiClient.Get<ArrayApiMessage<LineGroupMessage>>(path);
            var results = callResult.Value?.Data.Select(m => new LineGroupResult(m));

            return new Result<IEnumerable<LineGroupResult>>(callResult.RequestWasSuccessful, CreateErrorResult(callResult), results);
        }
    }
}
