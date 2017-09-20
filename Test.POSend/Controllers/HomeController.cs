using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using Test.POSend.ServiceReference;

namespace Test.POSend.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SendTestPO()
        {
            XmlDocument xml = new XmlDocument(); xml.Load(string.Concat(AppDomain.CurrentDomain.BaseDirectory, @"cXMLFile\OrderRequest.xml"));            

            using (ServiceClient client = new ServiceClient())
            {
                client.ProcessPO(xml.OuterXml);
            }

            return Content(xml.OuterXml, "text/xml");
        }
    }
}