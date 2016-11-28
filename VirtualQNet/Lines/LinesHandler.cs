using System;
using System.Threading.Tasks;

namespace VirtualQNet.Lines
{
    internal class LinesHandler: EntityHandler, ILinesHandler
    {
        public LinesHandler(ApiClient apiClient) : base(apiClient) { }

        private const string LINES_PATH = "lines";

        public async Task<bool> IsVirtualQActive(long lineId)
        {
            const string STATUS_LINE_ACTIVE = "active";

            try
            {
                var line = await _ApiClient.Get<Line>($"{LINES_PATH}/{lineId}");
                return line.Attributes.VirtualQLineState.Equals(STATUS_LINE_ACTIVE, StringComparison.InvariantCultureIgnoreCase);
            }
            catch (Exception exception)
            {
                throw new VirtualQException(exception.Message);
            }
        }
    }
}
