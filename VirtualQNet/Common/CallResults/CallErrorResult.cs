namespace VirtualQNet.Common.CallResults
{
    internal class CallErrorResult
    {
        public int Status { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public CallSourceResult Source { get; set; }
    }

    internal class CallSourceResult
    {
        public string Pointer { get; set; }
    }
}
