using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using System.Xml;

namespace WSDescargaMasivaSAT.Impl.IO.XMLDocument
{
   public  class ReferenceXML
    {
        private string _prefix;
        private string _localName;
        private string _namesSpaceUri;

        public ReferenceXML(string prefix = null, string localName = null, string namesSpaceURI = null)
        {
            _prefix = String.IsNullOrEmpty(prefix) ? "o" : prefix;
            _localName = string.IsNullOrEmpty(localName) ? "Reference" : localName;
            _namesSpaceUri = String.IsNullOrEmpty(namesSpaceURI) ? "http://www.w3.org/2000/09/xmldsig#" : namesSpaceURI;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public XmlElement XmlElement(XmlDocument doc)
        {
            XmlElement xml = doc.CreateElement(_localName, _namesSpaceUri);
            return xml;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="securityElement"></param>
        /// <param name="listaParametrosXmlelement"></param>
        public void XMlAttributeURI(XmlElement securityElement, ParametroXmlElement parametroElement = null)
        {
            securityElement.SetAttribute("URI", "#_0");


        }
    }
}
