using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kantar.GHP.APITestClient
{
    /// <summary>
    /// Logger connection, DB Connection etc.
    /// </summary>
    public class Store
    {
        private Dictionary<string, string> settings = new Dictionary<string, string>();

        public void Add(string key,string value)
        {

        }

        public void Remove(string key)
        {

        }

        public void Modify(string key, string value)
        {

        }

        public string GetValue(string key)
        {
            return settings[key];
        }
    }
}
