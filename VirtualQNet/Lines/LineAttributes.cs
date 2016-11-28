using Newtonsoft.Json;

namespace VirtualQNet.Lines
{
    public class LineAttributes
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("direct")]
        public bool Direct { get; set; }

        [JsonProperty("fast-dial-description")]
        public string FastDialDescription { get; set; }

        [JsonProperty("info")]
        public string Info { get; set; }

        [JsonProperty("opening-times-description")]
        public string OpeningTimesDescription { get; set; }

        [JsonProperty("private-line-key")]
        public string PrivateLinesKey { get; set; }

        [JsonProperty("ratings-average")]
        public double RatingsAverage { get; set; }

        [JsonProperty("service-phone-number")]
        public string ServicePhoneNumber { get; set; }

        [JsonProperty("telephone-charge-description")]
        public string TelephoneChargeDescription { get; set; }

        [JsonProperty("virtualq-line-state")]
        public string VirtualQLineState { get; set; }

        [JsonProperty("virtualq-line-state-mode")]
        public string VirtualQLineStateMode { get; set; }

        [JsonProperty("virtualq-phone-number")]
        public string VirtualQPhoneNumber { get; set; }

        [JsonProperty("line-group")]
        public LineGroup LineGroup { get; set; }
    }

    public class LineGroup
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("allow_callback")]
        public bool AllowCallback { get; set; }

        [JsonProperty("allow_sms")]
        public bool AllowSms { get; set; }

        [JsonProperty("service_waiters_count")]
        public int ServiceWaitersCount { get; set; }

        [JsonProperty("virtualq_ewt")]
        public int VirtualQEwt { get; set; }

        [JsonProperty("virtualq_waiters_count")]
        public int VirtualQWaitersCount { get; set; }
    }
}
