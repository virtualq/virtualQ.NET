using Newtonsoft.Json;
using System.Collections.Generic;

namespace VirtualQNet.Common.Messages
{
    internal class ArrayApiErrorMessage
    {
        [JsonProperty("errors")]
        public IEnumerable<ApiErrorMessage> Errors { get; set; }
    }
}
