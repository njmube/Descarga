using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using System.Xml;
using WSDescargaMasivaSAT.Impl.IO.XMLDocument;

namespace WSDescargaMasivaSAT.Impl.http.clienteSoap.IO
{
    public class Security
    {
        private string _prefix;
        private string _localName;
        private string _namesSpaceUri;

        public Security(string prefix = null, string localName = null, string namesSpaceURI = null)
        {
            _prefix = String.IsNullOrEmpty(prefix) ? "o" : prefix;
            _localName = string.IsNullOrEmpty(localName) ? "Security" : localName;
            _namesSpaceUri = String.IsNullOrEmpty(namesSpaceURI) ? "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd" : namesSpaceURI;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public  XmlElement XmlSecurity(XmlDocument doc)
        {
            XmlElement headerSecurityXml = doc.CreateElement(_prefix, _localName, _namesSpaceUri);
            return headerSecurityXml;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="securityElement"></param>
        /// <param name="listaParametrosXmlelement"></param>
        public void XMlAttributeList(XmlElement headerSecurityXml, List<ParametroXmlElement> listaParametrosXmlelement)
        {

            foreach (ParametroXmlElement parametro in listaParametrosXmlelement)
            {
                headerSecurityXml.SetAttribute(parametro.Prefix, parametro.LocalName, parametro.NameSpaceURI);
            }

        }


    }
}
