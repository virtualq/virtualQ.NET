namespace VirtualQNet.Results
{
    public class Result
    {
        public Result(bool requestWasSuccessful, string error)
        {
            RequestWasSuccessful = requestWasSuccessful;
            Error = error;
        }

        public bool RequestWasSuccessful { get; }
        public string Error { get; }
    }

    public class Result<T> : Result
    {
        public Result(bool requestWasSuccessful, string error, T value):
            base(requestWasSuccessful, error)
        {
            Value = value;
        }

        public T Value { get; }
    }
}
