using Kantar.GHP.DataMapping.APITestClient;
using Kantar.GHP.DataMapping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseRunner
{
    class Program
    {
        static void Main(string[] args)
        {

            DataProviderClientService dataProviderService = new DataProviderClientService();

            #region GetMethod
            var expecedGetData= new DataProvider
            {
                OrganizationName = "Nielsen",
                Location = "NY, USA"
            };
            var success=dataProviderService.GetDataProviderSuccessfully(1, expecedGetData);
            #endregion

            #region PostMethod
            var requestData = new DataProvider
            {
                OrganizationName = "Nielsen",
                Location = "NY, USA"
            };
            var listProviders = new List<DataProvider>();
            listProviders.Add(new DataProvider {Id=1, OrganizationName = "Nielsen", Location = "NY, USA" });
            listProviders.Add(new DataProvider {Id=2, OrganizationName = "Ebiquity", Location = "Paris, France" });
            listProviders.Add(requestData);
            success = dataProviderService.PostDataProviderSuccessfully(requestData,listProviders);
            #endregion

            #region PostMethod With Ignore Id
            var requestIgnoreData = new DataProvider
            {
                OrganizationName = "Nielsen",
                Location = "NY, USA"
            };
            var listProvidersIgnore = new List<DataProvider>();
            listProvidersIgnore.Add(new DataProvider { Id = 1, OrganizationName = "Nielsen", Location = "NY, USA" });
            listProvidersIgnore.Add(new DataProvider { Id = 2, OrganizationName = "Ebiquity", Location = "Paris, France" });
            listProvidersIgnore.Add(requestData);
            success = dataProviderService.PostDataProviderSuccessfully(requestIgnoreData, listProvidersIgnore, null, "Id");
            #endregion
        }
    }
}
