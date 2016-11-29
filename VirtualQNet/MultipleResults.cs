using Newtonsoft.Json;
using System.Collections.Generic;

namespace VirtualQNet
{
    internal class MultipleResults<T>
    {
        [JsonProperty("data")]
        public IEnumerable<T> Data { get; set; }
    }
}
