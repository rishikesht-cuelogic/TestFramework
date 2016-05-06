using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kantar.GHP.DataMapping.APITestClient;
using Kantar.GHP.DataMapping.Model;

namespace Kantar.GHP.Test
{
    [TestClass]
    public class TestDataProviderService
    {
        [TestMethod]
        public void TestGetStudentWithValidData()
        {
            DataProviderClientService register = new DataProviderClientService();
            var responseDataProvider = new DataProvider
            {
                OrganizationName = "Nielsen",
                Location = "NY, USA"
            };
            var success = register.GetDataProviderSuccessfully(1,responseDataProvider);
            Assert.IsTrue(success,"");
        }
    }
}
