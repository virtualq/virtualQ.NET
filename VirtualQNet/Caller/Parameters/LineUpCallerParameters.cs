using System.Collections.Generic;
using System.Dynamic;

namespace VirtualQNet.Caller
{
    public class LineUpCallerParameters : CallerParameters
    {
        public string Channel { get; set; }
        public string Source { get; set; }
        public string Language { get; set; }
        public IEnumerable<string> Skills { get; set; }
        public string Properties { get; set; }
    }
}
