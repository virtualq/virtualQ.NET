namespace VirtualQNet.Caller
{
    public class UpdateCallerInformationParameters: CallerParameters
    {
        public int? WaitTimeWhenUp { get; set; }
        public int? TalkTime { get; set; }
        public string AgentId { get; set; }
    }
}