using Newtonsoft.Json;
using System.Collections.Generic;

namespace VirtualQNet.Common.Messages
{
    internal class ArrayApiMessage<T>
    {
        [JsonProperty("data")]
        public IEnumerable<T> Data { get; set; }
    }
}
