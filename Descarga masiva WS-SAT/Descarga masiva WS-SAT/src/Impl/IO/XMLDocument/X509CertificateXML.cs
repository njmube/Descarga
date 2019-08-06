using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using System.Xml;

namespace WSDescargaMasivaSAT.Impl.IO.XMLDocument
{
    class X509CertificateXML
    {
        private string _prefix;
        private string _localName;
        private string _namesSpaceUri;

        public X509CertificateXML(string prefix = null, string localName = null, string namesSpaceURI = null)
        {
            _prefix = String.IsNullOrEmpty(prefix) ? "o" : prefix;
            _localName = string.IsNullOrEmpty(localName) ? "X509Certificate" : localName;
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
    }
}
