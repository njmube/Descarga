using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using System.Xml;
using WSDescargaMasivaSAT.Impl.IO.XMLDocument;

namespace WSDescargaMasivaSAT.Impl.http.clienteSoap.IO
{
   
    public class Body 
    {

        private string _prefix;
        private string _localName;
        private string _namesSpaceUri;

        public Body(string prefix = null, string localName = null, string namesSpaceURI = null)
        {
            _prefix = String.IsNullOrEmpty(prefix) ? "s" : prefix;
            _localName = string.IsNullOrEmpty(localName) ? "Body" :localName;
            _namesSpaceUri = String.IsNullOrEmpty(namesSpaceURI) ? "http://schemas.xmlsoap.org/soap/envelope/" : namesSpaceURI;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public  XmlElement XmlBodyXMlElement(XmlDocument doc)
        {
            XmlElement bodyXml = doc.CreateElement(_prefix, _localName, _namesSpaceUri);
            return bodyXml;

        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="securityElement"></param>
        /// <param name="listaParametrosXmlelement"></param>
        public void XMlAttributeListXSI(XmlElement securityElement, ParametroXmlElement parametroElement = null)
        {
            securityElement.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");


        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="securityElement"></param>
        /// <param name="listaParametrosXmlelement"></param>
        public void XMlAttributeListXSD(XmlElement securityElement, ParametroXmlElement parametroElement = null)
        {
            securityElement.SetAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");


        }
    }
}
