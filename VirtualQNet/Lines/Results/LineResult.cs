namespace VirtualQNet.Lines
{
    public class LineResult
    {
        internal LineResult(LineMessage message)
        {
            Id = message?.Id;
            Name = message?.Attributes?.Name;
            Category = message?.Attributes?.Category;
            Direct = message?.Attributes?.Direct;
            FastDialDescription = message?.Attributes?.FastDialDescription;
            Info = message?.Attributes?.Info;
            OpeningTimesDescription = message?.Attributes?.OpeningTimesDescription;
            PrivateLinesKey = message?.Attributes?.PrivateLinesKey;
            RatingsAverage = message?.Attributes?.RatingsAverage;
            ServicePhoneNumber = message?.Attributes?.ServicePhoneNumber;
            TelephoneChargeDescription = message?.Attributes?.TelephoneChargeDescription;
            VirtualQLineState = message?.Attributes?.VirtualQLineState;
            VirtualQLineStateMode = message?.Attributes?.VirtualQLineStateMode;
            VirtualQPhoneNumber = message?.Attributes?.VirtualQPhoneNumber;
            LineGroupId = message?.Attributes?.LineGroup?.Id;
            LineGroupName = message?.Attributes?.LineGroup?.Name;
            AllowCallback = message?.Attributes?.LineGroup?.AllowCallback;
            AllowSms = message?.Attributes?.LineGroup?.AllowSms;
            ServiceCallersCount = message?.Attributes?.LineGroup?.ServiceCallersCount;
            VirtualQEwt = message?.Attributes?.LineGroup?.VirtualQEwt;
            VirtualQCallersCount = message?.Attributes?.LineGroup?.VirtualQCallersCount;
        }

        public long? Id { get; }
        public string Name { get; }
        public string Category { get; }
        public bool? Direct { get; set; }
        public string FastDialDescription { get; }
        public string Info { get; }
        public string OpeningTimesDescription { get; }
        public string PrivateLinesKey { get; }
        public double? RatingsAverage { get; }
        public string ServicePhoneNumber { get; }
        public string TelephoneChargeDescription { get; }
        public string VirtualQLineState { get; }
        public string VirtualQLineStateMode { get; }
        public string VirtualQPhoneNumber { get; }
        public long? LineGroupId { get; set; }
        public string LineGroupName { get; set; }
        public bool? AllowCallback { get; set; }
        public bool? AllowSms { get; set; }
        public int? ServiceCallersCount { get; set; }
        public int? VirtualQEwt { get; set; }
        public int? VirtualQCallersCount { get; set; }
    }
}
