using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using System.Xml;
using WSDescargaMasivaSAT.Impl.IO.XMLDocument;

namespace WSDescargaMasivaSAT.Impl.IO
{
    public class SolicitaDescarga
    {
        private string _prefix;
        private string _localName;
        private string _namesSpaceUri;

        public SolicitaDescarga(string prefix = null, string localName = null, string namesSpaceURI = null)
        {
            _prefix = String.IsNullOrEmpty(prefix) ? "des" : prefix;
            _localName = string.IsNullOrEmpty(localName) ? "SolicitaDescarga" : localName;
            _namesSpaceUri = String.IsNullOrEmpty(namesSpaceURI) ? "http://DescargaMasivaTerceros.sat.gob.mx" : namesSpaceURI;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public XmlElement XmlBodyXMlElement(XmlDocument doc)
        {
            XmlElement bodyXml = doc.CreateElement(_prefix,_localName, _namesSpaceUri);
            return bodyXml;

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="securityElement"></param>
        /// <param name="listaParametrosXmlelement"></param>
        public void XMlAttributeListXMLNS(XmlElement securityElement, ParametroXmlElement parametroElement = null)
        {
            securityElement.SetAttribute("xmlns", "http://DescargaMasivaTerceros.sat.gob.mx");


        }


     

    }
}
