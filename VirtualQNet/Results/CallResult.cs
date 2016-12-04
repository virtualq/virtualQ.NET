namespace VirtualQNet.Results
{
    internal class CallResult
    {
        public bool RequestWasSuccessful { get; set; }
        public int ErrorStatus { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorTitle { get; set; }
        public string ErrorDescription { get; set; }
    }

    internal class CallResult<T> : CallResult
    {
        public T Value { get; set; }
    }
}
