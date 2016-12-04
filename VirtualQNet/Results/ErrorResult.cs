namespace VirtualQNet.Results
{
    public class ErrorResult
    {
        public ErrorResult(int status, string code, string title, string description)
        {
            Status = status;
            Code = code;
            Title = title;
            Description = description;
        }

        public int Status { get; }
        public string Code { get; }
        public string Title { get; }
        public string Description { get; }
    }
}
