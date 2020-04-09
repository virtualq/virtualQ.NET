using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Dynamic;
using VirtualQNet.Caller;
using VirtualQNet.Results;

namespace VirtualQNet.Tests
{
    [TestClass]
    public class CallersHandlerTests
    {
        [TestMethod]
        public void LineUpCaller_ValidLineId_ExpectSuccess()
        {
            string apiKey = ConfigurationHelper.GetApiKey();
            var configuration = new VirtualQClientConfiguration
            {
                ApiBaseAddress = ConfigurationHelper.GetApiUrl(),
                Timeout = null
            };
            using (VirtualQ client = new VirtualQ(apiKey, configuration))
            {
                dynamic properties = new ExpandoObject();
                properties.StringProp = "Value1";
                properties.ArrayProp = new[] { 45, 25, 78 };
                properties.DateProp = DateTime.Now;
                properties.ObjectProp = new { Id = 5, Value = "Value1" };
                properties.DictionaryProp = new Dictionary<string, string>() { { "prop1", "Value1" }, { "prop2", "Value2" } };

                var attributes = new LineUpCallerParameters
                {
                    LineId = 3384,
                    Phone = "+17343305027",
                    Channel = "CallIn",
                    Source = "Phone",
                    Language = "en",
                    Skills = new string[] { "Skill1", "Skill2", "Skill3" },
                    Properties = properties
                };

                Result result = client.Callers.LineUpCaller(attributes).Result;

                Assert.IsTrue(result.RequestWasSuccessful);
            }
        }

        [TestMethod]
        public void VerifyCaller_ValidLineIdAndPhone_ExpectSuccess()
        {
            string apiKey = ConfigurationHelper.GetApiKey();
            var configuration = new VirtualQClientConfiguration
            {
                ApiBaseAddress = ConfigurationHelper.GetApiUrl(),
                Timeout = null
            };
            using (VirtualQ client = new VirtualQ(apiKey, configuration))
            {
                var attributes = new CallerParameters
                {
                    LineId = 2600,
                    Phone = "+17343305027"
                };

                Result<bool> result = client.Callers.VerifyCaller(attributes).Result;

                Assert.IsTrue(result.RequestWasSuccessful);
                Assert.IsTrue(result.Value);
            }
        }

        [TestMethod]
        public void VerifyCaller_InvalidPhone_ExpectFailure()
        {
            string apiKey = ConfigurationHelper.GetApiKey();
            var configuration = new VirtualQClientConfiguration
            {
                ApiBaseAddress = ConfigurationHelper.GetApiUrl(),
                Timeout = null
            };
            using (VirtualQ client = new VirtualQ(apiKey, configuration))
            {
                var attributes = new CallerParameters
                {
                    LineId = 2600,
                    Phone = "+17343305000"
                };

                Result<bool> result = client.Callers.VerifyCaller(attributes).Result;

                Assert.IsTrue(result.RequestWasSuccessful);
                Assert.IsFalse(result.Value);
            }
        }

        [TestMethod]
        public void GetCaller_ValidLineIdAndPhone_ExpectSuccess()
        {
            string apiKey = ConfigurationHelper.GetApiKey();
            var configuration = new VirtualQClientConfiguration
            {
                ApiBaseAddress = ConfigurationHelper.GetApiUrl(),
                Timeout = null
            };
            using (VirtualQ client = new VirtualQ(apiKey, configuration))
            {
                var attributes = new CallerParameters
                {
                    LineId = 3384,
                    Phone = "+17343305027"
                };

                Result<CallerResult> result = client.Callers.GetCaller(attributes).Result;

                Assert.IsTrue(result.RequestWasSuccessful);
                Assert.IsNotNull(result.Value);
            }
        }

        [TestMethod]
        public void GetCaller_InvalidPhone_ExpectFailure()
        {
            string apiKey = ConfigurationHelper.GetApiKey();
            var configuration = new VirtualQClientConfiguration
            {
                ApiBaseAddress = ConfigurationHelper.GetApiUrl(),
                Timeout = null
            };
            using (VirtualQ client = new VirtualQ(apiKey, configuration))
            {
                var attributes = new CallerParameters
                {
                    LineId = 3384,
                    Phone = "+17343305000"
                };

                Result<CallerResult> result = client.Callers.GetCaller(attributes).Result;

                Assert.IsTrue(result.RequestWasSuccessful);
                Assert.IsNull(result.Value);
            }
        }

        [TestMethod]
        public void NotifyCallerConnected_ValidLineIdAndPhone_ExpectSuccess()
        {
            string apiKey = ConfigurationHelper.GetApiKey();
            var configuration = new VirtualQClientConfiguration
            {
                ApiBaseAddress = ConfigurationHelper.GetApiUrl(),
                Timeout = null
            };
            using (VirtualQ client = new VirtualQ(apiKey, configuration))
            {
                var attributes = new CallerParameters
                {
                    LineId = 2600,
                    Phone = "+17343305027"
                };

                Result result = client.Callers.NotifyCallerConnected(attributes).Result;

                Assert.IsTrue(result.RequestWasSuccessful);
            }
        }

        [TestMethod]
        public void NotifyCallerTransferred_ValidLineIdAndPhone_ExpectSuccess()
        {
            string apiKey = ConfigurationHelper.GetApiKey();
            var configuration = new VirtualQClientConfiguration
            {
                ApiBaseAddress = ConfigurationHelper.GetApiUrl(),
                Timeout = null
            };
            using (VirtualQ client = new VirtualQ(apiKey, configuration))
            {
                var attributes = new NotifyCallerTransferredParameters
                {
                    LineId = 2600,
                    Phone = "+17343305027",
                    AgentId = "B"
                };

                Result result = client.Callers.NotifyCallerTransferred(attributes).Result;

                Assert.IsTrue(result.RequestWasSuccessful);
            }
        }

        [TestMethod]
        public void UpdateCallerInformation_ValidLineIdAndPhone_ExpectSuccess()
        {
            string apiKey = ConfigurationHelper.GetApiKey();
            var configuration = new VirtualQClientConfiguration
            {
                ApiBaseAddress = ConfigurationHelper.GetApiUrl(),
                Timeout = null
            };
            using (VirtualQ client = new VirtualQ(apiKey, configuration))
            {
                dynamic properties = new ExpandoObject();
                properties.StringProp = "Value2";
                properties.ArrayProp = new[] { 5, 2 };

                var attributes = new UpdateCallerInformationParameters
                {
                    LineId = 2600,
                    Phone = "+17343305027",
                    AgentId = "A345",
                    TalkTime = 518,
                    WaitTimeWhenUp = 30,
                    EWT = 50,
                    Skills = new string[] { "Skill4", "Skill5", "Skill6" },
                    Properties = properties
                };

                Result result = client.Callers.UpdateCallerInformation(attributes).Result;

                Assert.IsTrue(result.RequestWasSuccessful);
            }
        }

        [TestMethod]
        public void ListCallersWaiting_ValidFilters_ExpectResults()
        {
            string apiKey = ConfigurationHelper.GetApiKey();
            var configuration = new VirtualQClientConfiguration
            {
                ApiBaseAddress = ConfigurationHelper.GetApiUrl(),
                Timeout = null
            };
            using (VirtualQ client = new VirtualQ(apiKey, configuration))
            {
                var attributes = new ListCallersWaitingParameters
                {
                    CallCenterId = 24,
                    LineId = 3384
                };

                Result<IEnumerable<CallerResult>> result = client.Callers.ListCallersWaiting(attributes).Result;

                Assert.IsTrue(result.RequestWasSuccessful);
            }
        }
    }
}
