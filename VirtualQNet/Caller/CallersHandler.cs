using System;
using System.Threading.Tasks;
using VirtualQNet.Results;

namespace VirtualQNet.Caller
{
    internal class CallersHandler : EntityHandler, ICallerHandler
    {
        public CallersHandler(ApiClient apiClient) : base(apiClient) { }

        private const string WAITERS_PATH = "waiters";
        public async Task<Result> LineUpCaller(LineUpCallerParameters attributes)
        {
            if (string.IsNullOrWhiteSpace(attributes.Phone))
                throw new ArgumentException(nameof(attributes.Phone));
            if(string.IsNullOrWhiteSpace(attributes.Channel))
                throw new ArgumentException(nameof(attributes.Channel));
            if (string.IsNullOrWhiteSpace(attributes.Source))
                throw new ArgumentException(nameof(attributes.Source));

            CallerAttributes callerAttributes = new CallerAttributes
            {
                LineId = attributes.LineId,
                Phone = attributes.Phone,
                Channel = attributes.Channel,
                Source = attributes.Source,
                Language = attributes.Language
            };

            CallResult callResult = await _ApiClient.Post(WAITERS_PATH, callerAttributes);

            return new Result(callResult.RequestWasSuccessful, callResult.ErrorDescription);
        }

        public async Task<Result> NotifyCallerConnected(CallerParameters attributes)
        {
            if (string.IsNullOrWhiteSpace(attributes.Phone))
                throw new ArgumentException(nameof(attributes.Phone));

            const string SERVICE_WAITER_SATE_CONNECT = "Connect";
            CallerAttributes calleAttributes = new CallerAttributes
            {
                LineId = attributes.LineId,
                Phone = attributes.Phone,
                ServiceCallerState = SERVICE_WAITER_SATE_CONNECT
            };
            string path = $"{WAITERS_PATH}/0";

            CallResult callResult = await _ApiClient.Put(path, calleAttributes);

            return new Result(callResult.RequestWasSuccessful, callResult.ErrorDescription);
        }

        public async Task<Result> NotifyCallerTransferred(NotifyCallerTransferredParameters attributes)
        {
            if (string.IsNullOrWhiteSpace(attributes.Phone))
                throw new ArgumentException(nameof(attributes.Phone));

            string path = $"{WAITERS_PATH}/0";
            CallerAttributes callerAttributes = new CallerAttributes
            {
                LineId = attributes.LineId,
                Phone = attributes.Phone,
                WaitTimeWhenUp = attributes.WaitTimeWhenUp,
                AgentId = attributes.AgentId
            };

            CallResult callResult = await _ApiClient.Put(path, callerAttributes);

            return new Result(callResult.RequestWasSuccessful, callResult.ErrorDescription);
        }

        public async Task<Result<bool>> VerifyCaller(CallerParameters attributes)
        {
            if (string.IsNullOrWhiteSpace(attributes.Phone))
                throw new ArgumentException(nameof(attributes.Phone));

            const int ERROR_STATUS_NOT_FOUND = 404;
            string query = $"{WAITERS_PATH}?currently_up=true"
                + $"&prone={attributes.Phone}"
                + $"&line_id={attributes.LineId}";

            CallResult<CallerResult> callResult = await _ApiClient.Get<CallerResult>(query);

            bool callerNotFound = callResult.ErrorStatus == ERROR_STATUS_NOT_FOUND;
            if (callerNotFound)
                return new Result<bool>(true, string.Empty, false);
            else
                return new Result<bool>(
                    callResult.RequestWasSuccessful,
                    callResult.ErrorDescription,
                    callResult.Value == null ? false : callResult.Value.Id > 0);
        }
    }
}
