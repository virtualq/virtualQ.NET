﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualQNet.CallCenter.Parameters;
using VirtualQNet.CallCenter.Results;
using VirtualQNet.Results;

namespace VirtualQNet.Tests
{
    [TestClass]
    public class CallCenterHandlerTests
    {
        [TestMethod]
        public void UpdateCallCenter()
        {
            string apiKey = ConfigurationHelper.GetApiKey();
            var configuration = new VirtualQClientConfiguration
            {
                ApiBaseAddress = ConfigurationHelper.GetApiUrl(),
                Timeout = null
            };
            using (VirtualQ client = new VirtualQ(apiKey, configuration))
            {
                var attributes = new UpdateCallCenterParameters
                {
                    Id = 1,
                    ConnectorVersion = "Testing Version zak 7777",
                    ConnectorConnectionStatus = "Its UP o up",
                    ConnectorLastRestartTime = DateTime.Now
                };

                Result result = client.CallCenter.UpdateCallCenter(attributes).Result;

                Assert.IsTrue(result.RequestWasSuccessful);
            }
        }
        
        [TestMethod]
        public void ListCallCenters()
        {
            string apiKey = ConfigurationHelper.GetApiKey();
            var configuration = new VirtualQClientConfiguration
            {
                ApiBaseAddress = ConfigurationHelper.GetApiUrl(),
                Timeout = null
            };
            using (VirtualQ client = new VirtualQ(apiKey, configuration))
            {
                var attributes = new ListCallCenterParameters
                {
                    Id = 1
                };

                Result<IEnumerable<CallCenterResult>> result = client.CallCenter.ListCallCenters(attributes).Result;

                if (result.Value.Any())
                    Trace.WriteLine("Call Centter Names: \n" + string.Join("\n", result.Value.Select(c => c.Name)));

                Assert.IsTrue(result.RequestWasSuccessful);
                Assert.IsTrue(result.Value.Any());
            }
        }

        [TestMethod]
        public void GetCallCenter()
        {
            string apiKey = ConfigurationHelper.GetApiKey();
            var configuration = new VirtualQClientConfiguration
            {
                ApiBaseAddress = ConfigurationHelper.GetApiUrl(),
                Timeout = null
            };
            using (VirtualQ client = new VirtualQ(apiKey, configuration))
            {
                var attributes = new ListCallCenterParameters
                {
                    Id = 1
                };

                Result<CallCenterResult> result = client.CallCenter.GetCallCenter(attributes).Result;

                if (result.Value != null)
                    Trace.WriteLine("Call Centter Names:" + result.Value);

                Assert.IsTrue(result.RequestWasSuccessful);
                Assert.IsTrue(result.Value != null);
            }
        }
    }
}
