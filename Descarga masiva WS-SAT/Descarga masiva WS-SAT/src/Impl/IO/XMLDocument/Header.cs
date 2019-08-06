using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using System.Xml;
using System.Xml.Serialization;

namespace WSDescargaMasivaSAT.Impl.http.clienteSoap.IO
{
       public class Header
     {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static XmlElement XmlHeader(XmlDocument doc)
        {
            XmlElement headerXml = doc.CreateElement("s", "Header", "http://schemas.xmlsoap.org/soap/envelope/");

            return headerXml;

        }





    }
}
