namespace VirtualQNet.Results
{
    public class Result
    {
        public Result(bool requestWasSuccessful, ErrorResult error)
        {
            RequestWasSuccessful = requestWasSuccessful;
            Error = error;
        }

        public bool RequestWasSuccessful { get; }
        public ErrorResult Error { get; }
    }

    public class Result<T> : Result
    {
        public Result(bool requestWasSuccessful, ErrorResult error, T value):
            base(requestWasSuccessful, error)
        {
            Value = value;
        }

        public T Value { get; }
    }
}
