using Newtonsoft.Json;
using System.Collections.Generic;

namespace VirtualQNet.Results
{
    internal class MultipleApiResults<T>
    {
        [JsonProperty("data")]
        public IEnumerable<T> Data { get; set; }
    }
}
