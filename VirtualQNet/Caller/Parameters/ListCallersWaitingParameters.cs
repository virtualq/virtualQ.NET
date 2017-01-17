namespace VirtualQNet.Caller
{
    public class ListCallersWaitingParameters
    {
        public long CallCenterId { get; set; }
        public long? LineId { get; set; }
        public bool? Updated { get; set; }
    }
}
