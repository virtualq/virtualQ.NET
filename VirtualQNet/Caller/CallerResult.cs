using System;
using VirtualQNet.Messages;

namespace VirtualQNet.Caller
{
    public class CallerResult
    {
        internal CallerResult(SingleApiMessage<CallerMessage> message)
        {
            Id = message?.Data?.Id;
            ActionVcc = message?.Data?.Attributes?.ActionVcc;
            Channel = message?.Data?.Attributes?.Channel;
            ConnectedAt = message?.Data?.Attributes?.ConnectedAt;
            CreatedAt = message?.Data?.Attributes?.CreatedAt;
            EstimatedUpTimeAt = message?.Data?.Attributes?.EstimatedUpTimeAt;
            Ewt = message?.Data?.Attributes?.Ewt;
            Message = message?.Data?.Attributes?.Message;
            NotifiedAt = message?.Data?.Attributes?.NotifiedAt;
            Phone = message?.Data?.Attributes?.Phone;
            Source = message?.Data?.Attributes?.Source;
            Token = message?.Data?.Attributes?.Token;
            UpdatedAt = message?.Data?.Attributes?.UpdatedAt;
            VirtualQCallerState = message?.Data?.Attributes?.VirtualQCallerState;
            WaitTime = message?.Data?.Attributes?.WaitTime;
            WaitingTimeInSeconds = message?.Data?.Attributes?.WaitingTimeInSeconds;
            LineId = message?.Data?.Attributes?.Line?.Id;
            LineName = message?.Data?.Attributes?.Line?.Name;
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
