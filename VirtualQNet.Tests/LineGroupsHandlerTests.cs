using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualQNet.LineGroups;
using VirtualQNet.Results;

namespace VirtualQNet.Tests
{
    [TestClass]
    public class LineGroupsHandlerTests
    {
        [TestMethod]
        public void UpdateLinegroup_ValidGroupId_ExpectSuccess()
        {
            string apiKey = ConfigurationHelper.GetApiKey();
            VirtualQClientConfiguration configuration = new VirtualQClientConfiguration
            {
                ApiBaseAddress = ConfigurationHelper.GetApiUrl(),
                Timeout = null
            };
            using (VirtualQ client = new VirtualQ(apiKey, configuration))
            {
                long lineGroupIdToUpdate = 185;
                UpdateLineGroupAttributes attributes = new UpdateLineGroupAttributes
                {
                    ServiceAgentsCount = 60,
                    ServiceEwt = 70,
                    ServiceCallersCount = 120,

                };

                Result result = client.LineGroups.UpdateLineGroup(lineGroupIdToUpdate, attributes).Result;

                Assert.IsTrue(result.RequestWasSuccessful);
            }
        }

        [TestMethod]
        public void UpdateLinegroup_InvalidGroupId_ExpectFailure()
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
