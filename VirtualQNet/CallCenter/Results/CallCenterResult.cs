﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualQNet.CallCenter.Messages;

namespace VirtualQNet.CallCenter.Results
{
    public class CallCenterResult
    {
        internal CallCenterResult(CallCenterMessage callCenterMessage)
        {
            Id = callCenterMessage?.Id;
            Name = callCenterMessage?.Attributes?.Name;
            CallCenterOpen = callCenterMessage?.Attributes?.CallCenterOpen;
            TriggerCallActive = callCenterMessage?.Attributes?.TriggerCallActive;
            TrigerCallFrequencyInMinutes = callCenterMessage?.Attributes?.TrigerCallFrequencyInMinutes;
            TriggerCallPhoneNumber = callCenterMessage?.Attributes?.TriggerCallPhoneNumber;
            VirtualqActive = callCenterMessage?.Attributes?.VirtualqActive;
            AllowManual = callCenterMessage?.Attributes?.AllowManual;
            TimeZone = callCenterMessage?.Attributes?.TimeZone;
            AcdTypeVersion = callCenterMessage?.Attributes?.AcdTypeVersion;
            ConnectorVersion = callCenterMessage?.Attributes?.ConnectorVersion;
            Notes = callCenterMessage?.Attributes?.Notes;
            ConnectorConfiguration = callCenterMessage?.Attributes?.ConnectorConfiguration;
            ConnectorLastRestartTime = callCenterMessage?.Attributes?.ConnectorLastRestartTime;
            ConnectorConnectionStatus = callCenterMessage?.Attributes?.ConnectorConnectionStatus;
        }

        public long? Id { get; }
        public string Name { get; }
        public bool? CallCenterOpen { get; }
        public string TriggerCallActive { get; }
        public int? TrigerCallFrequencyInMinutes { get; }
        public string TriggerCallPhoneNumber { get; }
        public bool? VirtualqActive { get; }
        public bool? AllowManual { get; }
        public string TimeZone { get; }
        public string AcdTypeVersion { get; }
        public string ConnectorVersion { get; }
        public string Notes { get; }
        public string ConnectorConfiguration { get; set; }
        public DateTime? ConnectorLastRestartTime { get; set; }
        public string ConnectorConnectionStatus { get; set; }
    }
}
