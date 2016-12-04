using System;
using VirtualQNet.Caller;
using VirtualQNet.LineGroups;
using VirtualQNet.Lines;

namespace VirtualQNet
{
    public class VirtualQ: IDisposable, IVirtualQ
    {
        public VirtualQ(string apiKey) : this(apiKey, null) { }
        public VirtualQ(string apiKey, VirtualQClientConfiguration configuration)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentNullException(nameof(apiKey));

            _ApiClient = new ApiClient(apiKey, configuration);

            Lines = new LinesHandler(_ApiClient);
            LineGroups = new LineGroupsHandler(_ApiClient);
        }

        private ApiClient _ApiClient { get; }

        public ILinesHandler Lines { get; }
        public ILineGroupsHandler LineGroups { get; }
        public ICallerHandler Callers { get; }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _ApiClient.Dispose();
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
