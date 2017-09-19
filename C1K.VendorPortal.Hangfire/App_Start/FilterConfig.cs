using System.Web;
using System.Web.Mvc;

namespace C1K.VendorPortal.BackgroundServices
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
