using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using System.Xml;
using System.Xml.Serialization;
using WSDescargaMasivaSAT.Impl.IO.XMLDocument;


namespace WSDescargaMasivaSAT.Impl.http.clienteSoap.IO
{

    public class Envelope
    {
        private string _prefix;
        private string _localName;
        private string _namesSpaceUri;

        public Envelope(string prefix = null, string localName = null, string namesSpaceURI = null)
        {
            _prefix = String.IsNullOrEmpty(prefix) ? "s" : prefix;
            _localName = string.IsNullOrEmpty(localName) ? "Envelope" : localName;
            _namesSpaceUri = String.IsNullOrEmpty(namesSpaceURI) ? "http://schemas.xmlsoap.org/soap/envelope/" : namesSpaceURI;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public XmlElement XmlEnvelopeElement(XmlDocument doc)
        {

            XmlElement securityElement = doc.CreateElement(_prefix, _localName, _namesSpaceUri);

            return securityElement;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="securityElement"></param>
        /// <param name="listaParametrosXmlelement"></param>
        public void XMlAttributeListXMLN_SU(XmlElement securityElement, ParametroXmlElement parametroElement = null)
        {

            if (parametroElement == null)
            {
                parametroElement = new ParametroXmlElement()
                {
                    LocalName = "xmlns:u",
                    NameSpaceURI = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"
                };
            }

            securityElement.SetAttribute(parametroElement.LocalName, parametroElement.NameSpaceURI);


        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="securityElement"></param>
        /// <param name="parametroElement"></param>
        public void XMlAttributeListXMLNS_DES (XmlElement securityElement, ParametroXmlElement parametroElement = null)
        {

            if (parametroElement == null)
            {
                parametroElement = new ParametroXmlElement()
                {
                    LocalName = "xmlns:des",
                    NameSpaceURI = "http://DescargaMasivaTerceros.sat.gob.mx"
                };
            }

            securityElement.SetAttribute(parametroElement.LocalName, parametroElement.NameSpaceURI);


        }


        public void XMlAttributeListXMLNS_XS(XmlElement securityElement, ParametroXmlElement parametroElement = null)
        {

            if (parametroElement == null)
            {
                parametroElement = new ParametroXmlElement()
                {
                    LocalName = "xmlns:xd",
                    NameSpaceURI = "http://www.w3.org/2000/09/xmldsig#"
                };
            }

            securityElement.SetAttribute(parametroElement.LocalName, parametroElement.NameSpaceURI);


        }

    }
}
