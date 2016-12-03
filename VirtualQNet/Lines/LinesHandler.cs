using System;
using System.Threading.Tasks;
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
            string path = $"{LINES_PATH}/{lineId}";

            CallResult<LineResult> callResult = await _ApiClient.Get<LineResult>(path);

            return new Result<bool>(
                callResult.RequestWasSuccessful,
                callResult.ErrorDescription,
                callResult.Value.Attributes.VirtualQLineState.Equals(STATUS_LINE_ACTIVE, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
