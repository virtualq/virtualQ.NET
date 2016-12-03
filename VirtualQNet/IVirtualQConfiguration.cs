using System;
using System.Net;

namespace VirtualQNet
{
    public interface IVirtualQClientConfiguration
    {
        TimeSpan Timeout { get; set; }
        IWebProxy ProxyConfiguration { get; set; }
        Uri ApiUri { get; set; }
    }
}
