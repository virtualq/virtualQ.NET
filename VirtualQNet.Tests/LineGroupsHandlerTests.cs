using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
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
                UpdateLineGroupParameters attributes = new UpdateLineGroupParameters
                {
                    ServiceEwt = 300,
                    ServiceCallersCount = 2,
                    ServiceAverageTalkTime = 35,
                    ServiceAgentsCount = 3,
                    ServiceAgentList = new string[] { "A", "B", "C" }
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
                UpdateLineGroupParameters attributes = new UpdateLineGroupParameters
                {
                    ServiceAgentsCount = 60,
                    ServiceEwt = 70
                };

                Result result = client.LineGroups.UpdateLineGroup(lineGroupIdToUpdate, attributes).Result;

                Assert.IsFalse(result.RequestWasSuccessful);
                Assert.IsTrue(result.Error.Code == "not-found");
            }
        }

        [TestMethod]
        public void UpdateLineGroupCollection_ValidIds_ExpectSuccess()
        {
            string apiKey = ConfigurationHelper.GetApiKey();
            VirtualQClientConfiguration configuration = new VirtualQClientConfiguration
            {
                ApiBaseAddress = ConfigurationHelper.GetApiUrl(),
                Timeout = null
            };
            using (VirtualQ client = new VirtualQ(apiKey, configuration))
            {
                List<UpdateLineGroupParameters> lineGroupsToupdate = new List<UpdateLineGroupParameters>();
                lineGroupsToupdate.Add(new UpdateLineGroupParameters
                {
                    Id  = 191,
                    ServiceAgentsCount = 60,
                    ServiceEwt = 70
                    
                });
                lineGroupsToupdate.Add(new UpdateLineGroupParameters
                {
                    Id = 185,
                    ServiceAgentsCount = 12,
                    ServiceEwt = 45
                });
                UpdateLineGroupCollectionParameters attributes = new UpdateLineGroupCollectionParameters
                {
                    CallCenterId = 1,
                    LineGroups = lineGroupsToupdate
                };

                Result result = client.LineGroups.UpdateLineGroupCollection(attributes).Result;

                Assert.IsTrue(result.RequestWasSuccessful);
            }
        }
    }
}
