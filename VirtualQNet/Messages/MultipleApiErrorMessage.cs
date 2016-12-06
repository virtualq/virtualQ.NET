using Newtonsoft.Json;
using System.Collections.Generic;

namespace VirtualQNet.Messages
{
    internal class MultipleApiErrorMessage
    {
        [JsonProperty("errors")]
        public IEnumerable<ApiErrorMessage> Errors { get; set; }
    }
}
