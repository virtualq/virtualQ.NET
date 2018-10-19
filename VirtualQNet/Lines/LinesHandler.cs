using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualQNet.Common;
using VirtualQNet.Common.CallResults;
using VirtualQNet.Common.Messages;
using VirtualQNet.Results;

namespace VirtualQNet.Lines
{
    internal class LinesHandler: EntityHandler, ILinesHandler
    {
        public LinesHandler(ApiClient apiClient) : base(apiClient) { }

        private const string LINES_PATH = "lines";

        public async Task<Result<bool>> IsVirtualQActive(long lineId)
        {
            const string STATUS_LINE_ACTIVE = "active";
            var path = $"{LINES_PATH}/{lineId}?check_active=true";

            CallResult<SingleApiMessage<LineMessage>> callResult = await _ApiClient.Get<SingleApiMessage<LineMessage>>(path);

            var value = callResult.RequestWasSuccessful 
                && callResult.Value.Data.Attributes.VirtualQLineState.Equals(
                    STATUS_LINE_ACTIVE,
                    StringComparison.InvariantCultureIgnoreCase);

            return new Result<bool>(
                callResult.RequestWasSuccessful,
                CreateErrorResult(callResult),
                value);
        }

        public async Task<Result<bool>> NewCallOffered(long lineId)
        {

            //var path = $"{LINES_PATH}/{lineId}/log_call_offered";

            //CallResult<SingleApiMessage<LineMessage>> callResult = await _ApiClient.Get<SingleApiMessage<LineMessage>>(path);

            //var value = callResult.RequestWasSuccessful;


            //return new Result<bool>(
            //    callResult.RequestWasSuccessful,
            //    CreateErrorResult(callResult),
            //    value);


            var value = false;
            CallResult<SingleApiMessage<LineMessage>> callResult = new CallResult<SingleApiMessage<LineMessage>>();

            try
            {
                var path = $"{LINES_PATH}/{lineId}/log_call_offered";

                callResult = await _ApiClient.Get<SingleApiMessage<LineMessage>>(path);
                value = true;

            }
            catch (Exception)
            {

            }

            return new Result<bool>(
                value,
                CreateErrorResult(callResult),
                value);
        }

        public async Task<Result<IEnumerable<LineResult>>> ListLines(ListLinesParameters attributes)
        {
            var filter = $"call_center_id={attributes.CallCenterId}";
            if (attributes.LineGroupId.HasValue) filter = $"{filter}&line_group_id={attributes.LineGroupId}";
            if (!string.IsNullOrWhiteSpace(attributes.Query)) filter = $"{filter}&q={attributes.Query}";
            var path = $"{LINES_PATH}?{filter}";

            CallResult<ArrayApiMessage<LineMessage>> callResult = await _ApiClient.Get<ArrayApiMessage<LineMessage>>(path);
            var results = callResult.Value?.Data.Select(m => new LineResult(m));

            return new Result<IEnumerable<LineResult>>(callResult.RequestWasSuccessful, CreateErrorResult(callResult), results);
        }
    }
}
