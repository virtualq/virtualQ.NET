using System.Collections.Generic;

namespace VirtualQNet.LineGroups
{
    public class UpdateLineGroupCollectionParameters
    {
        public long CallCenterId { get; set; }
        public IEnumerable<UpdateLineGroupParameters> LineGroups { get; set; }
    }
}
