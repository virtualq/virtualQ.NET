using System;
using System.Collections.Generic;

namespace VirtualQNet.Caller
{
    public class CallerResult
    {
        internal CallerResult(CallerMessage message)
        {
            Id = message?.Id;
            ActionVcc = message?.Attributes?.ActionVcc;
            Channel = message?.Attributes?.Channel;
            ConnectedAt = message?.Attributes?.ConnectedAt;
            CreatedAt = message?.Attributes?.CreatedAt;
            EstimatedUpTimeAt = message?.Attributes?.EstimatedUpTimeAt;
            Ewt = message?.Attributes?.Ewt;
            Message = message?.Attributes?.Message;
            NotifiedAt = message?.Attributes?.NotifiedAt;
            Phone = message?.Attributes?.Phone;
            Properties = message?.Attributes?.Properties;
            Skills = message?.Attributes?.Skills;
            Source = message?.Attributes?.Source;
            Token = message?.Attributes?.Token;
            UpdatedAt = message?.Attributes?.UpdatedAt;
            VirtualQCallerState = message?.Attributes?.VirtualQCallerState;
            WaitTime = message?.Attributes?.WaitTime;
            WaitingTimeInSeconds = message?.Attributes?.WaitingTimeInSeconds;
            LineId = message?.Attributes?.Line?.Id;
            LineName = message?.Attributes?.Line?.Name;
        }

        public long? Id { get; }
        public string ActionVcc { get; }
        public string Channel { get; }
        public DateTime? ConnectedAt { get; }
        public DateTime? CreatedAt { get; }
        public DateTime? EstimatedUpTimeAt { get; }
        public int? Ewt { get; }
        public string Message { get; }
        public DateTime? NotifiedAt { get; }
        public string Phone { get; }
        public string Properties { get; set; }
        public IEnumerable<string> Skills { get; set; }
        public string Source { get; }
        public string Token { get; }
        public DateTime? UpdatedAt { get; }
        public string VirtualQCallerState { get; }
        public int? WaitTime { get; }
        public int? WaitingTimeInSeconds { get; }
        public long? LineId { get; }
        public string LineName { get; }
    }
}
