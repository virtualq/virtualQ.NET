namespace VirtualQNet.Lines
{
    public class ListLinesParameters
    {
        public long CallCenterId { get; set; }
        public long? LineGroupId { get; set; }
        public string PrivateKey { get; set; }
        public string Query { get; set; }
    }
}
