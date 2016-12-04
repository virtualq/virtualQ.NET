using System;
using System.Net;

namespace VirtualQNet
{
    public class VirtualQClientConfiguration
    {
        public TimeSpan? Timeout { get; set; }
        public WebProxy ProxyConfiguration { get; set; }
        public string ApiBaseAddress { get; set; }
    }
}
