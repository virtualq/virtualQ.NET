using Newtonsoft.Json;
using System.Collections.Generic;

namespace VirtualQNet.Messages
{
    internal class ArrayApiMessage<T>
    {
        [JsonProperty("data")]
        public IEnumerable<T> Data { get; set; }
    }
}
