using Kantar.GHP.DataMapping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Kantar.GHP.DataMapping.Controllers
{
    public class DataProviderController : ApiController
    {
        public DataProviderController()
        {

        }
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public DataProvider Get(int id)
        {
            return new DataProvider
            {
                OrganizationName = "Nielsen",
                Location = "NY, USA"
            };
        }

        public DataProvider Filter(string providerName)
        {
            return new DataProvider
            {
                OrganizationName = "Nielsen",
                Location = "NY, USA"
            };
        }

        //public List<DataProvider> Get(int id)
        //{
        //    var temp = ModelState.IsValid;
        //    var listProviders = new List<DataProvider>();
        //    listProviders.Add(new DataProvider { OrganizationName = "Nielsen", Location = "NY, USA" });
        //    listProviders.Add(new DataProvider { OrganizationName = "Ebiquity", Location = "Paris, France" });
        //    return listProviders;
        //}

        // POST api/values
        public List<DataProvider> Post([FromBody]DataProvider dataProvider)
        {
            var temp=ModelState.IsValid;
            var listProviders = new List<DataProvider>();
            listProviders.Add(new DataProvider { OrganizationName="Nielsen",Location="NY, USA"});
            listProviders.Add(new DataProvider { OrganizationName = "Ebiquity", Location = "Paris, France" });
            listProviders.Add(dataProvider);
            return listProviders;
        }

        

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
