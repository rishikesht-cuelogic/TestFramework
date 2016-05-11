using Kantar.GHP.APITestClient;
using Kantar.GHP.DataMapping.Entity.APIResponse;
using Kantar.GHP.DataMapping.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kantar.GHP.DataMapping.APITestClient
{
    public class DataMappingClientService: HttpClientProxy
    {
        private string providerUrl;
        public DataMappingClientService(string baseUrl):base(baseUrl) {
            providerUrl = baseUrl + "Test/";
        }

        private string SetUrl(TableModel model)
        {
            string getAllUserUrl = providerUrl;
            getAllUserUrl = getAllUserUrl + String.Format("GetAllUsers?PageSize={0}&PageNumber={1}", model.PageSize, model.PageNumber);

            if (!string.IsNullOrWhiteSpace(model.OrderBy))
                getAllUserUrl = getAllUserUrl+ "&OrderBy=" + model.OrderBy;

            if (!string.IsNullOrWhiteSpace(model.OrderByDir))
                getAllUserUrl = getAllUserUrl+"&OrderByDir=" + model.OrderByDir;

            if (!string.IsNullOrWhiteSpace(model.SearchText))
                getAllUserUrl = getAllUserUrl+"&SearchText=" + model.SearchText;

            return getAllUserUrl;
        }

        public bool GetAllUserSuccessful(TableModel requestData, JsonResponse expectedData, Dictionary<string, string> headers = null, params string[] ignore)
        {
            try
            {
                var requestUri=SetUrl(requestData);
                return TestHttpGetRequest(requestUri, expectedData, ignore);
            }
            catch (Exception)
            {
                //Logger
                throw;
            }
        }
    }
}
