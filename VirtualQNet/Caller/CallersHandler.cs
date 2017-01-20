using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualQNet.Common;
using VirtualQNet.Common.CallResults;
using VirtualQNet.Common.Messages;
using VirtualQNet.Results;

namespace VirtualQNet.Caller
{
    internal class CallersHandler : EntityHandler, ICallersHandler
    {
        public CallersHandler(ApiClient apiClient) : base(apiClient) { }

        private const string WAITERS_PATH = "waiters";
        private const string MESSAGE_TYPE = "waiters";

        public async Task<Result> LineUpCaller(LineUpCallerParameters attributes)
        {
            if (string.IsNullOrWhiteSpace(attributes.Phone))
                throw new ArgumentException(nameof(attributes.Phone));
            if(string.IsNullOrWhiteSpace(attributes.Channel))
                throw new ArgumentException(nameof(attributes.Channel));
            if (string.IsNullOrWhiteSpace(attributes.Source))
                throw new ArgumentException(nameof(attributes.Source));

            var messageAttributes = new CallerCreateMessageAttributes
            {
                LineId = attributes.LineId,
                Phone = attributes.Phone,
                Channel = attributes.Channel,
                Source = attributes.Source,
                Language = attributes.Language,
                Skills = attributes.Skills,
                Properties = attributes.Properties
            };
            SingleApiMessage<CallerCreateMessage> message = CreateSingleMessage<CallerCreateMessageAttributes, CallerCreateMessage>(MESSAGE_TYPE, messageAttributes);
            CallResult callResult = await _ApiClient.Post(WAITERS_PATH, message);

            return new Result(callResult.RequestWasSuccessful, CreateErrorResult(callResult));
        }

        public async Task<Result> NotifyCallerConnected(CallerParameters attributes)
        {
            if (string.IsNullOrWhiteSpace(attributes.Phone))
                throw new ArgumentException(nameof(attributes.Phone));

            const string SERVICE_WAITER_SATE_CONNECT = "Connected";
            var messageAttributes = new CallerUpdateMessageAttributes
            {
                LineId = attributes.LineId,
                Phone = attributes.Phone,
                ServiceCallerState = SERVICE_WAITER_SATE_CONNECT
            };
            var path = $"{WAITERS_PATH}/0";

            SingleApiMessage<CallerUpdateMessage> message = CreateSingleMessage<CallerUpdateMessageAttributes, CallerUpdateMessage>(MESSAGE_TYPE, messageAttributes);
            CallResult callResult = await _ApiClient.Put(path, message);

            return new Result(callResult.RequestWasSuccessful, CreateErrorResult(callResult));
        }

        public async Task<Result> NotifyCallerTransferred(NotifyCallerTransferredParameters attributes)
        {
            if (string.IsNullOrWhiteSpace(attributes.Phone))
                throw new ArgumentException(nameof(attributes.Phone));

            const string SERVICE_WAITER_SATE_FINISHED = "Finished";
            var messageAttributes = new CallerUpdateMessageAttributes
            {
                LineId = attributes.LineId,
                Phone = attributes.Phone,
                WaitTimeWhenUp = attributes.WaitTimeWhenUp,
                AgentId = attributes.AgentId,
                ServiceCallerState = SERVICE_WAITER_SATE_FINISHED
            };
            var path = $"{WAITERS_PATH}/0";

            SingleApiMessage<CallerUpdateMessage> message = CreateSingleMessage<CallerUpdateMessageAttributes, CallerUpdateMessage>(MESSAGE_TYPE, messageAttributes);
            CallResult callResult = await _ApiClient.Put(path, message);

            return new Result(callResult.RequestWasSuccessful, CreateErrorResult(callResult));
        }

        public async Task<Result<bool>> VerifyCaller(CallerParameters attributes)
        {
            if (string.IsNullOrWhiteSpace(attributes.Phone))
                throw new ArgumentException(nameof(attributes.Phone));

            const int ERROR_STATUS_NOT_FOUND = 404;
            var query = $"{WAITERS_PATH}?currently_up=true"
                + $"&phone={attributes.Phone}"
                + $"&line_id={attributes.LineId}";

            CallResult<ArrayApiMessage<CallerMessage>> callResult = await _ApiClient.Get<ArrayApiMessage<CallerMessage>>(query);

            var callerNotFound = callResult.Error?.Status == ERROR_STATUS_NOT_FOUND;
            if (callerNotFound)
                return new Result<bool>(true, null, false);
            else
                return new Result<bool>(
                    callResult.RequestWasSuccessful,
                    CreateErrorResult(callResult),
                    callResult.Value == null ? false : callResult.Value.Data.Any());
        }

        public async Task<Result> UpdateCallerInformation(UpdateCallerInformationParameters attributes)
        {
            if (string.IsNullOrWhiteSpace(attributes.Phone))
                throw new ArgumentException(nameof(attributes.Phone));

            var messageAttributes = new CallerUpdateMessageAttributes
            {
                LineId = attributes.LineId,
                Phone = attributes.Phone,
                Skills = attributes.Skills,
                Properties = attributes.Properties,
                EWT = attributes.EWT,
                ServiceCallerState = attributes.ServiceState,
                TalkTime = attributes.TalkTime,
                WaitTimeWhenUp = attributes.WaitTimeWhenUp,
                AgentId = attributes.AgentId
            };
            var path = $"{WAITERS_PATH}/0";

            SingleApiMessage<CallerUpdateMessage> message = CreateSingleMessage<CallerUpdateMessageAttributes, CallerUpdateMessage>(MESSAGE_TYPE, messageAttributes);
            CallResult callResult = await _ApiClient.Put(path, message);

            return new Result(callResult.RequestWasSuccessful, CreateErrorResult(callResult));
        }

        public async Task<Result<IEnumerable<CallerResult>>> ListCallersWaiting(ListCallersWaitingParameters attributes)
        {
            var filter = $"call_center_id={attributes.CallCenterId}";
            if (attributes.LineId.HasValue) filter = $"{filter}&line_id={attributes.LineId}";
            if (attributes.Updated.HasValue) filter = $"{filter}&updated={attributes.Updated}";
            var path = $"{WAITERS_PATH}?{filter}&active=true";

            CallResult<ArrayApiMessage<CallerMessage>> callResult = await _ApiClient.Get<ArrayApiMessage<CallerMessage>>(path);
            var results = callResult.Value?.Data.Select(m => new CallerResult(m));
            
            return new Result<IEnumerable<CallerResult>>(callResult.RequestWasSuccessful, CreateErrorResult(callResult), results);
        }
    }
}
