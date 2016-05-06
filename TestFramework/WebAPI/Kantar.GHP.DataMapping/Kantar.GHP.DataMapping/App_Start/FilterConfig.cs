using System.Web;
using System.Web.Mvc;

namespace Kantar.GHP.DataMapping
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
