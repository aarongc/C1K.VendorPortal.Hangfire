using System.Web;
using System.Web.Mvc;

namespace C1K.VendorPortal.BackgroundWorker
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
