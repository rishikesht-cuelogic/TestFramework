using Kantar.GHP.DataMapping.APITestClient;
using Kantar.GHP.DataMapping.Entity.APIResponse;
using Kantar.GHP.DataMapping.Entity.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kantar.GHP.DataMapping.Test
{
    [TestClass]
    public class TestDataMappingClientService
    {
        DataMappingClientService dataMappingService = new DataMappingClientService(Common.GetUrl());
        [TestMethod]
        public void TestGetDataPrvider()
        {
            List<User> users = new List<User>();
            users.Add(new User { Id = 112, Name = "Andre Hortness", Email = "Andre.Hortness@abc.com" });
            JsonResponse expecedGetData = new JsonResponse
            {
                Status = new Status
                {
                    Messages = new string[] { "Successful" },
                    Code = "API_SUCCESS"
                },
                Data =new UserListModel{
                    Users=users,
                    Paging=new Paging
                    {
                        TotalCount=700,
                        SearchedCount=1
                    }
                }
            };

            var requestData = new TableModel
            {
                SearchText = "112"
            };
            var success = dataMappingService.GetAllUserSuccessful(requestData, expecedGetData,null, "TotalCount");
            Assert.IsTrue(success);
        }
    }
}
