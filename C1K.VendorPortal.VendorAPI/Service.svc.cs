using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Xml;

namespace C1K.VendorPortal.WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service.svc or Service.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string GetSampleOrderRequest()
        {            
            XmlDocument xml = new XmlDocument();

            xml.Load(string.Concat(AppDomain.CurrentDomain.BaseDirectory, 
                @"cXMLFile\OrderRequest.xml"));

            return xml.OuterXml;
        }
        
        public void ProcessPO(string cXML)
        {
            //malformed xml file
            //using (StreamWriter orderRequest = new StreamWriter(HostingEnvironment.MapPath("~/cXMLFile/po1.xml"), true))
            //{
            //    orderRequest.WriteLine(cXML);
            //}

            XmlDocument orderRequest = new XmlDocument();
            orderRequest.LoadXml(cXML);
            orderRequest.Save(HostingEnvironment.MapPath("~/cXMLFile/po1.xml"));
        }
    }
}
