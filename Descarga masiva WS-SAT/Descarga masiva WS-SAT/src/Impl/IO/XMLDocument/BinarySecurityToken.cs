using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
 
using System.Xml;
using WSDescargaMasivaSAT.Impl.IO.XMLDocument;



namespace WSDescargaMasivaSAT.Impl.http.clienteSoap.IO
{
    public class BinarySecurityToken
    {

        /// <summary>
        /// 
        /// </summary>
        private string _prefix;

        /// <summary>
        /// 
        /// </summary>
        private string _localName;

        /// <summary>
        /// 
        /// </summary>
        private string _namesSpaceUri;

        public BinarySecurityToken(string prefix = null, string localName = null, string namesSpaceURI = null)
        {
            _prefix = String.IsNullOrEmpty(prefix) ? "o" : prefix;
            _localName = string.IsNullOrEmpty(localName) ? "BinarySecurityToken" : localName;
            _namesSpaceUri = String.IsNullOrEmpty(namesSpaceURI) ? "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd" : namesSpaceURI;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public  XmlElement XmlSecurityBinarySecurityToken(XmlDocument doc)
        {
            XmlElement headerSecurityBinarySecurityTokenXml = doc.CreateElement(_prefix, _localName, _namesSpaceUri);
            //headerSecurityBinarySecurityTokenXml.SetAttribute("Id", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd", parametro.UUIDiRamdon);
            //headerSecurityBinarySecurityTokenXml.SetAttribute("ValueType", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509v3");
            //headerSecurityBinarySecurityTokenXml.SetAttribute("EncodingType", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary");
          
            return headerSecurityBinarySecurityTokenXml;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="headerSecurityXml"></param>
        /// <param name="parametroElement"></param>
        public void addXMlAttributeId(XmlElement headerSecurityXml, string uuid, ParametroXmlElement parametroElement = null)
        {

            if (parametroElement == null)
            {
                parametroElement = new ParametroXmlElement
                {
                    Prefix = "Id",
                    LocalName = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd",
                    NameSpaceURI = uuid

                };
            }
          


                headerSecurityXml.SetAttribute(parametroElement.Prefix, parametroElement.LocalName, parametroElement.NameSpaceURI);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="headerSecurityXml"></param>
        /// <param name="parametroElement"></param>
        public void addXMlAttributeValueType(XmlElement headerSecurityXml, ParametroXmlElement parametroElement = null)
        {


            if (parametroElement == null)
            {
                parametroElement = new ParametroXmlElement
                {
                   
                    LocalName = "EncodingType",
                    NameSpaceURI = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary"

                };
            }

            headerSecurityXml.SetAttribute(parametroElement.LocalName, parametroElement.NameSpaceURI);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="headerSecurityXml"></param>
        /// <param name="parametroElement"></param>
        public void addXMlAttributeEncodingTypee(XmlElement headerSecurityXml, ParametroXmlElement parametroElement = null)
        {
            if (parametroElement == null)
            {
                parametroElement = new ParametroXmlElement
                {

                    LocalName = "ValueType",
                    NameSpaceURI = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509v3"

                };
            }

            headerSecurityXml.SetAttribute(parametroElement.LocalName, parametroElement.NameSpaceURI);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="headerSecurityXml"></param>
        /// <param name="certificado2"></param>
        public void addXInnertTexteSecurity(XmlElement headerSecurityXml , X509Certificate2 certificado2)
        {
            headerSecurityXml.InnerText = new SecurityToken(certificado2).getSecurityTokenToBase64();
        }


    }
}
