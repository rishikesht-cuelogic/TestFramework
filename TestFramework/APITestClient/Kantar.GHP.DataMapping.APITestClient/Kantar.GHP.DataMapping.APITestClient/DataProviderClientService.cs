using Kantar.GHP.DataMapping.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Kantar.GHP.DataMapping.APITestClient
{
    public class DataProviderClientService: HttpClientProxy
    {
        private string providerUrl;
        public DataProviderClientService() {
            providerUrl = baseUrl + "DataProvider/";
        }
        public bool GetDataProviderSuccessfully(int requestDataProviderId, DataProvider responseDataProvider,Dictionary<string,string> headers=null, params string[] ignore)
        {
            try
            {
                var requestUri = providerUrl + requestDataProviderId;
                return TestHttpGetRequest(requestUri, responseDataProvider,ignore);
            }
            catch (Exception)
            {
                //Logger
                throw;
            }
        }

        public bool PostDataProviderSuccessfully(DataProvider requestDataProvider, List<DataProvider> responseDataProvider, Dictionary<string, string> headers = null, params string[] ignore)
        {
            try
            {
                var requestUri = providerUrl;
                return TestHttpPostRequest(requestUri,requestDataProvider,responseDataProvider,ignore);
            }
            catch (Exception)
            {
                //Logger
                throw;
            }
        }

    }
}
