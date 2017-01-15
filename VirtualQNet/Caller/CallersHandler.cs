using System;
using System.Linq;
using System.Threading.Tasks;
using VirtualQNet.Messages;
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

            CallerMessageAttributes messageAttributes = new CallerMessageAttributes
            {
                LineId = attributes.LineId,
                Phone = attributes.Phone,
                Channel = attributes.Channel,
                Source = attributes.Source,
                Language = attributes.Language,
                Skills = attributes.Skills,
                Properties = attributes.Properties
            };
            SingleApiMessage<CallerMessage> message = CreateMessage<CallerMessage, CallerMessageAttributes>(MESSAGE_TYPE, messageAttributes);
            CallResult callResult = await _ApiClient.Post(WAITERS_PATH, message);

            return new Result(callResult.RequestWasSuccessful, CreateErrorResult(callResult));
        }

        public async Task<Result> NotifyCallerConnected(CallerParameters attributes)
        {
            if (string.IsNullOrWhiteSpace(attributes.Phone))
                throw new ArgumentException(nameof(attributes.Phone));

            const string SERVICE_WAITER_SATE_CONNECT = "Connected";
            CallerMessageAttributes messageAttributes = new CallerMessageAttributes
            {
                LineId = attributes.LineId,
                Phone = attributes.Phone,
                ServiceCallerState = SERVICE_WAITER_SATE_CONNECT
            };
            string path = $"{WAITERS_PATH}/0";

            SingleApiMessage<CallerMessage> message = CreateMessage<CallerMessage, CallerMessageAttributes>(MESSAGE_TYPE, messageAttributes);
            CallResult callResult = await _ApiClient.Put(path, message);

            return new Result(callResult.RequestWasSuccessful, CreateErrorResult(callResult));
        }

        public async Task<Result> NotifyCallerTransferred(NotifyCallerTransferredParameters attributes)
        {
            if (string.IsNullOrWhiteSpace(attributes.Phone))
                throw new ArgumentException(nameof(attributes.Phone));

            const string SERVICE_WAITER_SATE_FINISHED = "Finished";
            CallerMessageAttributes messageAttributes = new CallerMessageAttributes
            {
                LineId = attributes.LineId,
                Phone = attributes.Phone,
                WaitTimeWhenUp = attributes.WaitTimeWhenUp,
                AgentId = attributes.AgentId,
                ServiceCallerState = SERVICE_WAITER_SATE_FINISHED
            };
            string path = $"{WAITERS_PATH}/0";

            SingleApiMessage<CallerMessage> message = CreateMessage<CallerMessage, CallerMessageAttributes>(MESSAGE_TYPE, messageAttributes);
            CallResult callResult = await _ApiClient.Put(path, message);

            return new Result(callResult.RequestWasSuccessful, CreateErrorResult(callResult));
        }

        public async Task<Result<bool>> VerifyCaller(CallerParameters attributes)
        {
            if (string.IsNullOrWhiteSpace(attributes.Phone))
                throw new ArgumentException(nameof(attributes.Phone));

            const int ERROR_STATUS_NOT_FOUND = 404;
            string query = $"{WAITERS_PATH}?currently_up=true"
                + $"&phone={attributes.Phone}"
                + $"&line_id={attributes.LineId}";

            CallResult<MultipleApiMessages<CallerMessage>> callResult = await _ApiClient.Get<MultipleApiMessages<CallerMessage>>(query);

            bool callerNotFound = callResult.Error?.Status == ERROR_STATUS_NOT_FOUND;
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

            CallerMessageAttributes messageAttributes = new CallerMessageAttributes
            {
                LineId = attributes.LineId,
                Phone = attributes.Phone,
                TalkTime = attributes.TalkTime,
                WaitTimeWhenUp = attributes.WaitTimeWhenUp,
                
                AgentId = attributes.AgentId
            };
            string path = $"{WAITERS_PATH}/0";

            SingleApiMessage<CallerMessage> message = CreateMessage<CallerMessage, CallerMessageAttributes>(MESSAGE_TYPE, messageAttributes);
            CallResult callResult = await _ApiClient.Put(path, message);

            return new Result(callResult.RequestWasSuccessful, CreateErrorResult(callResult));
        }
    }
}
