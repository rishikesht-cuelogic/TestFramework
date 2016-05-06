using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kantar.GHP.DataMapping.APITestClient
{
    internal static class Settings
    {
        public static string GetUrl()
        {
            // return ConfigurationManager.AppSettings["DataMappingUrl"];
            return "http://localhost:54699/api/";
        }
    }
}
