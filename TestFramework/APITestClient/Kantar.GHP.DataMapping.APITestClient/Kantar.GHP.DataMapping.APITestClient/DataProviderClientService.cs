using Kantar.GHP.APITestClient;
using Kantar.GHP.DataMapping.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Kantar.GHP.DataMapping.APITestClient
{
    public class DataProviderClientService: HttpClientProxy
    {
        private string providerUrl;
        Logger logger;
        public DataProviderClientService(string baseUrl):base(baseUrl) {
            logger = new Logger();
            providerUrl = baseUrl + "DataProvider/";
        }
        public bool GetDataProviderSuccessful(object requestDataProviderId, DataProvider expectedData,Dictionary<string,string> headers=null, params string[] ignore)
        {
            try
            {
                var requestUri = providerUrl + requestDataProviderId;
                return TestHttpGetRequest(requestUri, expectedData, ignore);
            }
            catch (Exception)
            {
                //Logger
                throw;
            }
        }

        //public bool PostDataProviderSuccessfully(DataProvider requestDataProvider, List<DataProvider> responseDataProvider, Dictionary<string, string> headers = null, params string[] ignore)
        //{
        //    try
        //    {
        //        var requestUri = providerUrl;
        //        return TestHttpPostRequest(requestUri,requestDataProvider,responseDataProvider,ignore);
        //    }
        //    catch (Exception)
        //    {
        //        //Logger
        //        throw;
        //    }
        //}

        public bool GetDataProviderFailure(int requestDataProviderId, HttpStatusCode statusCode, Dictionary<string, string> headers = null)
        {
            try
            {
                var requestUri = providerUrl + requestDataProviderId;
                return TestHttpGetFailRequest(requestUri, statusCode);
            }
            catch (Exception)
            {
                //Logger
                throw;
            }
        }

    }
}
