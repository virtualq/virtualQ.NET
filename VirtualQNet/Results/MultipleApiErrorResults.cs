using Newtonsoft.Json;
using System.Collections.Generic;

namespace VirtualQNet.Results
{
    internal class MultipleApiErrorResults
    {
        [JsonProperty("errors")]
        public IEnumerable<ApiErrorResult> Errors { get; set; }
    }
}
