using System;
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
            var path = $"{LINES_PATH}/{lineId}";

            CallResult<SingleApiMessage<LineMessage>> callResult = await _ApiClient.Get<SingleApiMessage<LineMessage>>(path);

            bool value = callResult.RequestWasSuccessful 
                && callResult.Value.Data.Attributes.VirtualQLineState.Equals(
                    STATUS_LINE_ACTIVE,
                    StringComparison.InvariantCultureIgnoreCase);

            return new Result<bool>(
                callResult.RequestWasSuccessful,
                CreateErrorResult(callResult),
                value);
        }
    }
}
