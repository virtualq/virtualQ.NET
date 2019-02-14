using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualQNet.CallCenter.Messages;
using VirtualQNet.CallCenter.Parameters;
using VirtualQNet.CallCenter.Results;
using VirtualQNet.Common;
using VirtualQNet.Common.CallResults;
using VirtualQNet.Common.Messages;
using VirtualQNet.Results;

namespace VirtualQNet.CallCenter
{
    internal class CallCenterHandler : EntityHandler, ICallCenterHandler
    {
        private const string CALL_CENTER_PATH = "call_centers";
        private const string MESSAGE_TYPE = "call_centers";

        public CallCenterHandler(ApiClient apiClient) : base(apiClient) { }
        
        public async Task<Result> UpdateCallCenter(UpdateVersionNumberCallCenterParameters updateVersionNumberCallCenterParameters)
        {
            if (string.IsNullOrWhiteSpace(updateVersionNumberCallCenterParameters.ConnectorVersion) || string.IsNullOrEmpty(updateVersionNumberCallCenterParameters.ConnectorVersion))
                throw new ArgumentException(nameof(updateVersionNumberCallCenterParameters.ConnectorVersion));
            var messageAttributes = new CallCenterCreateMessageAttributes
            {
                Id = updateVersionNumberCallCenterParameters.Id,
                ConnectorVersion = updateVersionNumberCallCenterParameters.ConnectorVersion
            };

            SingleApiMessage<CallCenterMessage> message = CreateSingleMessage<CallCenterCreateMessageAttributes, CallCenterMessage>(MESSAGE_TYPE, messageAttributes);
            var path = $"{CALL_CENTER_PATH}/{messageAttributes.Id}";
            CallResult callResult = await _ApiClient.Put(path, message);

            return new Result(callResult.RequestWasSuccessful, CreateErrorResult(callResult));
        }

        public async Task<Result<IEnumerable<CallCenterResult>>> ListCallCenters(ListCallCenterParameters attributes)
        {
            var path = $"{CALL_CENTER_PATH}";

            CallResult<ArrayApiMessage<CallCenterMessage>> callResult = await _ApiClient.Get<ArrayApiMessage<CallCenterMessage>>(path);
            var results = callResult.Value?.Data.Select(m => new CallCenterResult(m));

            return new Result<IEnumerable<CallCenterResult>>(callResult.RequestWasSuccessful, CreateErrorResult(callResult), results);
        }
    }
}
