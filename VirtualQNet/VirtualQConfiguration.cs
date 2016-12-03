using System;
using System.Net;

namespace VirtualQNet
{
    public class VirtualQClientConfiguration
    {
        public TimeSpan Timeout { get; set; }
        public IWebProxy ProxyConfiguration { get; set; }
        public Uri ApiUri { get; set; }
    }
}
