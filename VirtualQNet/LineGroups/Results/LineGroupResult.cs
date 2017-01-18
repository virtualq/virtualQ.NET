using VirtualQNet.LineGroups.Messages;

namespace VirtualQNet.LineGroups
{
    public class LineGroupResult
    {
        internal LineGroupResult(LineGroupMessage message)
        {
            Id = message?.Id;
            Name = message?.Attributes.Name;
            AllowCallback = message?.Attributes?.AllowCallback;
            AllowSms = message?.Attributes?.AllowSms;
            CcType = message?.Attributes?.CcType;
            ForesightClosingInMinutes = message?.Attributes?.ForesightClosingInMinutes;
            VirtualQMinAgentCount = message?.Attributes?.VirtualQMinAgentCount;
            VirtualQMinWaitingTime = message?.Attributes?.VirtualQMinWaitingTime;
            VirtualQNoticeTime = message?.Attributes?.VirtualQNoticeTime;
            VirtualQTimeoutTime = message?.Attributes?.VirtualQTimeoutTime;
            VirtualQWaitersCount = message?.Attributes?.VirtualQWaitersCount;
            ServiceWaitersCount = message?.Attributes?.ServiceWaitersCount;
            CallCenterId = message?.Attributes?.CallCenter?.Id;
            CallCenterName = message?.Attributes?.CallCenter?.Name;
            CallCenterOpen = message?.Attributes?.CallCenter?.CallCenterOpen;
            VirtualQActive = message?.Attributes?.CallCenter?.VirtualQActive;
        }

        public long? Id { get; }
        public string Name { get; }
        public bool? AllowCallback { get; set; }
        public bool? AllowSms { get; set; }
        public string CcType { get; set; }
        public int? ForesightClosingInMinutes { get; set; }
        public int? VirtualQMinAgentCount { get; set; }
        public int? VirtualQMinWaitingTime { get; set; }
        public int? VirtualQNoticeTime { get; set; }
        public int? VirtualQTimeoutTime { get; set; }
        public int? VirtualQWaitersCount { get; set; }
        public int? ServiceWaitersCount { get; set; }
        public long? CallCenterId { get; set; }
        public string CallCenterName { get; set; }
        public bool? CallCenterOpen { get; set; }
        public bool? VirtualQActive { get; set; }
    }
}
