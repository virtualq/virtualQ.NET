namespace VirtualQNet.Results
{
    internal class CallResult
    {
        public bool RequestWasSuccessful { get; set; }
        public CallErrorResult Error { get; set; }
    }

    internal class CallResult<T> : CallResult
    {
        public T Value { get; set; }
    }
}
