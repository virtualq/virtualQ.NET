using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            VirtualQClientConfiguration configuration = new VirtualQClientConfiguration
            {
                ApiBaseAddress = ConfigurationHelper.GetApiUrl(),
                Timeout = null
            };
            using (VirtualQ client = new VirtualQ(apiKey, configuration))
            {
                long lineId = 3042;

                Result<bool> result = client.Lines.IsVirtualQActive(lineId).Result;

                Assert.IsTrue(result.RequestWasSuccessful);
                Assert.IsTrue(result.Value);
            }
        }

        [TestMethod]
        public void IsVirtualQActive_InnactiveLineId_ExpectFalse()
        {
            string apiKey = ConfigurationHelper.GetApiKey();
            VirtualQClientConfiguration configuration = new VirtualQClientConfiguration
            {
                ApiBaseAddress = ConfigurationHelper.GetApiUrl(),
                Timeout = null
            };
            using (VirtualQ client = new VirtualQ(apiKey, configuration))
            {
                long lineId = 2600;

                Result<bool> result = client.Lines.IsVirtualQActive(lineId).Result;

                Assert.IsTrue(result.RequestWasSuccessful);
                Assert.IsFalse(result.Value);
            }
        }

        [TestMethod]
        public void IsVirtualQActive_InvalidLineId_ExpectFailure()
        {
            string apiKey = ConfigurationHelper.GetApiKey();
            VirtualQClientConfiguration configuration = new VirtualQClientConfiguration
            {
                ApiBaseAddress = ConfigurationHelper.GetApiUrl(),
                Timeout = null
            };
            using (VirtualQ client = new VirtualQ(apiKey, configuration))
            {
                long lineId = 0;

                Result<bool> result = client.Lines.IsVirtualQActive(lineId).Result;

                Assert.IsFalse(result.RequestWasSuccessful);
                Assert.IsFalse(result.Value);
                Assert.IsTrue(result.Error.Code == "not-found");
            }
        }
    }
}
