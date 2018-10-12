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
            var configuration = new VirtualQClientConfiguration
            {
                ApiBaseAddress = ConfigurationHelper.GetApiUrl(),
                Timeout = null
            };
            using (VirtualQ client = new VirtualQ(apiKey, configuration))
            {
                var lineGroupIdToUpdate = 185L;
                var attributes = new UpdateLineGroupParameters
                {
                    ServiceEwt = 300,
                    ServiceCallersCount = 2,
                    ServiceAverageTalkTime = 35,
                    ServiceAgentsCount = 3,
                    ServiceAgentsIdleCount = 1,
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
            var configuration = new VirtualQClientConfiguration
            {
                ApiBaseAddress = ConfigurationHelper.GetApiUrl(),
                Timeout = null
            };
            using (VirtualQ client = new VirtualQ(apiKey, configuration))
            {
                var lineGroupIdToUpdate = 1925L;
                var attributes = new UpdateLineGroupParameters
                {
                    ServiceAgentsCount = 60,
                    ServiceAgentsIdleCount = 10,
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
            var configuration = new VirtualQClientConfiguration
            {
                ApiBaseAddress = ConfigurationHelper.GetApiUrl(),
                Timeout = null
            };
            using (VirtualQ client = new VirtualQ(apiKey, configuration))
            {
                var lineGroupsToupdate = new List<UpdateLineGroupParameters>();
                lineGroupsToupdate.Add(new UpdateLineGroupParameters
                {
                    Id = 2,
                    ServiceAgentsCount = 60,
                    ServiceAgentsIdleCount = 10,
                    ServiceEwt = 70

                });
                lineGroupsToupdate.Add(new UpdateLineGroupParameters
                {
                    Id = 223,
                    ServiceAgentsCount = 12,
                    ServiceAgentsIdleCount = 8,
                    ServiceEwt = 45
                });
                var attributes = new UpdateLineGroupCollectionParameters
                {
                    CallCenterId = 1,
                    LineGroups = lineGroupsToupdate
                };

                Result result = client.LineGroups.UpdateLineGroupCollection(attributes).Result;

                Assert.IsTrue(result.RequestWasSuccessful);
            }
        }

        [TestMethod]
        public void ListLineGroups_ValidFilters_ExpectResults()
        {
            string apiKey = ConfigurationHelper.GetApiKey();
            var configuration = new VirtualQClientConfiguration
            {
                ApiBaseAddress = ConfigurationHelper.GetApiUrl(),
                Timeout = null
            };
            using (VirtualQ client = new VirtualQ(apiKey, configuration))
            {
                var attributes = new ListLineGroupsParameters
                {
                    CallCenterId = 1
                };

                Result<IEnumerable<LineGroupResult>> result = client.LineGroups.ListLineGroups(attributes).Result;

                Assert.IsTrue(result.RequestWasSuccessful);
            }
        }
    }
}
