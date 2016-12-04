using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualQNet.LineGroups;
using VirtualQNet.Results;

namespace VirtualQNet.Tests
{
    [TestClass]
    public class LineGroupsHandlerTest
    {
        [TestMethod]
        public void UpdateLinegroup_SendValidGroupId_ExpectSuccess()
        {
            string apiKey = ConfigurationHelper.GetApiKey();
            VirtualQClientConfiguration configuration = new VirtualQClientConfiguration
            {
                ApiBaseAddress = ConfigurationHelper.GetApiUrl(),
                Timeout = null
            };
            using (VirtualQ client = new VirtualQ(apiKey, configuration))
            {
                long lineGroupIdToUpdate = 192;
                UpdateLineGroupAttributes attributes = new UpdateLineGroupAttributes
                {
                    ServiceAgentsCount = 60,
                    ServiceEwt = 70
                };

                Result result = client.LineGroups.UpdateLineGroup(lineGroupIdToUpdate, attributes).Result;

                Assert.IsTrue(result.RequestWasSuccessful);
            }
        }

        [TestMethod]
        public void UpdateLinegroup_SendInvalidGroupId_ExpectFailure()
        {
            string apiKey = ConfigurationHelper.GetApiKey();
            VirtualQClientConfiguration configuration = new VirtualQClientConfiguration
            {
                ApiBaseAddress = ConfigurationHelper.GetApiUrl(),
                Timeout = null
            };
            using (VirtualQ client = new VirtualQ(apiKey, configuration))
            {
                long lineGroupIdToUpdate = 1925;
                UpdateLineGroupAttributes attributes = new UpdateLineGroupAttributes
                {
                    ServiceAgentsCount = 60,
                    ServiceEwt = 70
                };

                Result result = client.LineGroups.UpdateLineGroup(lineGroupIdToUpdate, attributes).Result;

                Assert.IsFalse(result.RequestWasSuccessful);
                Assert.IsTrue(result.Error.Code == "not-found");
            }
        }
    }
}
