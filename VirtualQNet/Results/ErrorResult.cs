namespace VirtualQNet.Results
{
    public class ErrorResult
    {
        public ErrorResult(int status, string code, string title, string description, ErrorSource source)
        {
            Status = status;
            Code = code;
            Title = title;
            Description = description;
            Source = source;
        }

        public int Status { get; }
        public string Code { get; }
        public string Title { get; }
        public string Description { get; }
        public ErrorSource Source { get; set; }
    }

    public class ErrorSource
    {
        public ErrorSource(string pointer)
        {
            Pointer = pointer;
        }
        public string Pointer { get; }
    }
}
