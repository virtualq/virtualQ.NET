using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using VirtualQNet.Lines;
using VirtualQNet.Results;

namespace VirtualQNet.Tests
{
    [TestClass]
    public class LinesHandlerTests
    {
        [TestMethod]
        public void IsVirtualQActive_ActiveLineId_ExpectTrue()
        {
            string apiKey = ConfigurationHelper.GetApiKey();
            var configuration = new VirtualQClientConfiguration
            {
                ApiBaseAddress = ConfigurationHelper.GetApiUrl(),
                Timeout = null
            };
            using (VirtualQ client = new VirtualQ(apiKey, configuration))
            {
                var lineId = 3042L;

                Result<bool> result = client.Lines.IsVirtualQActive(lineId).Result;

                Assert.IsTrue(result.RequestWasSuccessful);
                Assert.IsTrue(result.Value);
            }
        }

        [TestMethod]
        public void IsVirtualQActive_InnactiveLineId_ExpectFalse()
        {
            string apiKey = ConfigurationHelper.GetApiKey();
            var configuration = new VirtualQClientConfiguration
            {
                ApiBaseAddress = ConfigurationHelper.GetApiUrl(),
                Timeout = null
            };
            using (VirtualQ client = new VirtualQ(apiKey, configuration))
            {
                var lineId = 3036L;

                Result<bool> result = client.Lines.IsVirtualQActive(lineId).Result;

                Assert.IsTrue(result.RequestWasSuccessful);
                Assert.IsFalse(result.Value);
            }
        }

        [TestMethod]
        public void IsVirtualQActive_InvalidLineId_ExpectFailure()
        {
            string apiKey = ConfigurationHelper.GetApiKey();
            var configuration = new VirtualQClientConfiguration
            {
                ApiBaseAddress = ConfigurationHelper.GetApiUrl(),
                Timeout = null
            };
            using (VirtualQ client = new VirtualQ(apiKey, configuration))
            {
                var lineId = 0L;

                Result<bool> result = client.Lines.IsVirtualQActive(lineId).Result;

                Assert.IsFalse(result.RequestWasSuccessful);
                Assert.IsFalse(result.Value);
                Assert.IsTrue(result.Error.Code == "not-found");
            }
        }

        [TestMethod]
        public void ListLine_ValidFilters_ExpectResults()
        {
            string apiKey = ConfigurationHelper.GetApiKey();
            var configuration = new VirtualQClientConfiguration
            {
                ApiBaseAddress = ConfigurationHelper.GetApiUrl(),
                Timeout = null
            };
            using (VirtualQ client = new VirtualQ(apiKey, configuration))
            {
                var attributes = new ListLinesParameters
                {
                    CallCenterId = 1,
                    LineGroupId = 185
                };

                Result<IEnumerable<LineResult>> result = client.Lines.ListLines(attributes).Result;

                Assert.IsTrue(result.RequestWasSuccessful);
                Assert.IsTrue(result.Value.Any());
            }
        }
    }
}
