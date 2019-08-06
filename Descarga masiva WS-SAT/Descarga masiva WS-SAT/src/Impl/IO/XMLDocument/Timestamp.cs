using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using System.Xml;
using WSDescargaMasivaSAT.src.Impl.Utils;

namespace WSDescargaMasivaSAT.Impl.http.clienteSoap.IO
{
    public class Timestamp
    {

  

        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public  XmlElement XmlSecurityTimeStap(XmlDocument doc)
        {
            XmlElement headerSecurityTimeStapXml = doc.CreateElement("u", "Timestamp", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd");
            headerSecurityTimeStapXml.SetAttribute("Id", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd", "_0");

            return headerSecurityTimeStapXml;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public  XmlElement XmlTimestampCreate(XmlDocument doc)
        {


            var utcNow = DateTime.UtcNow;
            XmlElement timestampCreateXML = doc.CreateElement("u", "Created", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd");
            timestampCreateXML.InnerText = utcNow.ToString(DateUtility.DateFormat);
            return timestampCreateXML;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public  XmlElement XmlTimestampExperired(XmlDocument doc)
        {
            var utcNow = DateTime.UtcNow;
            XmlElement timestampExpiresXML = doc.CreateElement("u", "Expires", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd");
            timestampExpiresXML.InnerText = utcNow.AddSeconds(300).ToString(DateUtility.DateFormat);
            return timestampExpiresXML;
        }

    }
}
