using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualQNet.Messages;
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
            string path = $"{LINE_GROUPS_PATH}/{lineGroupId}";
            LineGroupMessageAttributes messageAttributes = new LineGroupMessageAttributes
            {
                ServiceAgentsCount = attributes.ServiceAgentsCount,
                ServiceAverageTalkTime = attributes.ServiceAverageTalkTime,
                ServiceEwt = attributes.ServiceEwt,
                ServiceOpen = attributes.ServiceOpen,
                ServiceCallersCount = attributes.ServiceCallersCount,
                ServiceAgentList = attributes.ServiceAgentList
            };

            SingleApiMessage<LineGroupMessage> message = CreateMessage<LineGroupMessage, LineGroupMessageAttributes>(MESSAGE_TYPE, messageAttributes);
            CallResult callResult = await _ApiClient.Put(path, message);

            return new Result(callResult.RequestWasSuccessful, CreateErrorResult(callResult));
        }

        public async Task<Result> UpdateLineGroupCollection(UpdateLineGroupCollectionParameters attributes)
        {
            string path = $"{LINE_GROUPS_PATH}/updated";
            IEnumerable<LineGroupMessage> lineGroupMessages = attributes.LineGroups.Select(lg => new LineGroupMessage
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

            ArrayApiMessage<LineGroupMessage> messages = new ArrayApiMessage<LineGroupMessage>
            {
                Data = lineGroupMessages
            };
            CallResult callResult = await _ApiClient.Put(path, messages);

            return new Result(callResult.RequestWasSuccessful, CreateErrorResult(callResult));
        }
    }
}
