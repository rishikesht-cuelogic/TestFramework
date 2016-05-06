﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace Kantar.GHP.DataMapping.APITestClient
{
    public class HttpClientProxy
    {
        protected string baseUrl;
        private HttpClient client;
        public HttpClientProxy() {
            client = new HttpClient();
            baseUrl = Settings.GetUrl();
        }
        protected bool TestHttpGetRequest(string requestUri,object expectedData, params string[] ignore)
        {
            var response = Get(requestUri);
            return IsExpectedResponse(response, expectedData,ignore);
        }
        protected bool TestHttpDeleteRequest(string requestUri, object expectedData, params string[] ignore)
        {
            var response = Delete(requestUri);
            return IsExpectedResponse(response, expectedData,ignore);
        }
        protected bool TestHttpPostRequest(string requestUri,object requestData, object expectedData, params string[] ignore)
        {
            var response = Post(requestUri,requestData);
            return IsExpectedResponse(response, expectedData,ignore);
        }
        protected bool TestHttpPutRequest(string requestUri, object requestData, object expectedData, params string[] ignore)
        {
            var response = Put(requestUri, requestData);
            return IsExpectedResponse(response, expectedData,ignore);
        }
        private static bool IsExpectedResponse(HttpResponseMessage response,object expectedData, params string[] ignore)
        {
            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content;
                string responseJson = responseContent.ReadAsStringAsync().Result;
                var expectedJson = JsonConvert.SerializeObject(expectedData);
                var success = Validate.IsEqualJsons(responseJson, expectedJson,ignore);
                if (!success)
                {
                    //Logger
                }
                return success;
            }
            else
                return false;

           
        }
        private void getHttpRequest(string uri, Dictionary<string, string> headers)
        {
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(uri),
                Method = HttpMethod.Get,
            };
            if (headers != null && headers.Count > 0)
            {
                foreach (var item in headers)
                {
                    request.Headers.Add(item.Key, item.Value);
                }
            }
        }
        private HttpResponseMessage Get(string url)
        {
            return client.GetAsync(url).Result;
        }
        private HttpResponseMessage Post(string url, object requestData)
        {
            return client.PostAsJsonAsync(url, requestData).Result;
        }
        private HttpResponseMessage Put(string url, object requestData)
        {
            return client.PutAsJsonAsync(url, requestData).Result;
        }
        private HttpResponseMessage Delete(string url)
        {
            return client.DeleteAsync(url).Result;
        }
    }
}
