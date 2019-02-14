using System;
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
                var attributes = new UpdateVersionNumberCallCenterParameters
                {
                    Id = 24,
                    ConnectorVersion = "version number update test via VirtualQ C# SDK is a success| Version Number: 1.5.0"
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
    }
}
