using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kantar.GHP.DataMapping.APITestClient;
using Kantar.GHP.DataMapping.Model;
using System.Collections.Generic;

namespace Kantar.GHP.DataMapping.Test
{
    [TestClass]
    public class TestDataProviderServices
    {
        DataProviderClientService dataProviderService = new DataProviderClientService("http://localhost:54699/api/");
        [TestMethod]
        public void TestGetDataPrvider()
        {
            var expecedGetData = new DataProvider
            {
                OrganizationName = "Nielsen",
                Location = "NY, USA"
            };
            var success = dataProviderService.GetDataProviderSuccessful(1, expecedGetData);
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void TestGetAllDataPrvider()
        {
            var expecedGetData = new DataProvider
            {
                OrganizationName = "Nielsen",
                Location = "NY, USA"
            };
            var success = dataProviderService.GetDataProviderSuccessful(1, expecedGetData);
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void TestPostMethodWithoutIgnoreId()
        {
            var requestData = new DataProvider
            {
                OrganizationName = "Nielsen",
                Location = "NY, USA"
            };
            var listProviders = new List<DataProvider>();
            listProviders.Add(new DataProvider { Id = 1, OrganizationName = "Nielsen", Location = "NY, USA" });
            listProviders.Add(new DataProvider { Id = 2, OrganizationName = "Ebiquity", Location = "Paris, France" });
            listProviders.Add(requestData);
            //var success = dataProviderService.PostDataProviderSuccessfully(requestData, listProviders);
            //Assert.IsFalse(success);
        }

        [TestMethod]
        public void TestPostMethodWithIgnoreId()
        {
            var requestData = new DataProvider
            {
                OrganizationName = "Nielsen",
                Location = "NY, USA"
            };
            var listProvidersIgnore = new List<DataProvider>();
            listProvidersIgnore.Add(new DataProvider { Id = 1, OrganizationName = "Nielsen", Location = "NY, USA" });
            listProvidersIgnore.Add(new DataProvider { Id = 2, OrganizationName = "Ebiquity", Location = "Paris, France" });
            listProvidersIgnore.Add(requestData);
            //var success = dataProviderService.PostDataProviderSuccessfully(requestData, listProvidersIgnore, null, "Id");
            //Assert.IsTrue(success);
        }
    }
}
