using Newtonsoft.Json;

namespace VirtualQNet.Lines
{
    internal class LineAttributes
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("category", NullValueHandling = NullValueHandling.Ignore)]
        public string Category { get; set; }

        [JsonProperty("direct", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Direct { get; set; }

        [JsonProperty("fast-dial-description", NullValueHandling = NullValueHandling.Ignore)]
        public string FastDialDescription { get; set; }

        [JsonProperty("info", NullValueHandling = NullValueHandling.Ignore)]
        public string Info { get; set; }

        [JsonProperty("opening-times-description", NullValueHandling = NullValueHandling.Ignore)]
        public string OpeningTimesDescription { get; set; }

        [JsonProperty("private-line-key", NullValueHandling = NullValueHandling.Ignore)]
        public string PrivateLinesKey { get; set; }

        [JsonProperty("ratings-average", NullValueHandling = NullValueHandling.Ignore)]
        public double? RatingsAverage { get; set; }

        [JsonProperty("service-phone-number", NullValueHandling = NullValueHandling.Ignore)]
        public string ServicePhoneNumber { get; set; }

        [JsonProperty("telephone-charge-description", NullValueHandling = NullValueHandling.Ignore)]
        public string TelephoneChargeDescription { get; set; }

        [JsonProperty("virtualq-line-state", NullValueHandling = NullValueHandling.Ignore)]
        public string VirtualQLineState { get; set; }

        [JsonProperty("virtualq-line-state-mode", NullValueHandling = NullValueHandling.Ignore)]
        public string VirtualQLineStateMode { get; set; }

        [JsonProperty("virtualq-phone-number", NullValueHandling = NullValueHandling.Ignore)]
        public string VirtualQPhoneNumber { get; set; }

        [JsonProperty("line-group", NullValueHandling = NullValueHandling.Ignore)]
        public LineGroup LineGroup { get; set; }
    }

    public class LineGroup
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("allow_callback", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AllowCallback { get; set; }

        [JsonProperty("allow_sms", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AllowSms { get; set; }

        [JsonProperty("service_waiters_count", NullValueHandling = NullValueHandling.Ignore)]
        public int? ServiceCallersCount { get; set; }

        [JsonProperty("virtualq_ewt", NullValueHandling = NullValueHandling.Ignore)]
        public int? VirtualQEwt { get; set; }

        [JsonProperty("virtualq_waiters_count", NullValueHandling = NullValueHandling.Ignore)]
        public int? VirtualQCallersCount { get; set; }
    }
}
