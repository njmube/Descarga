using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using System.Xml;

namespace WSDescargaMasivaSAT.Impl.http.clienteSoap.IO
{
    class SecurityTokenReference
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static XmlElement xmlKeyInfoSecurityTokenReference(XmlDocument doc, string uuid)
        {
            XmlElement securityTokenReferenceXML = doc.CreateElement("o", "SecurityTokenReference", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
            securityTokenReferenceXML.AppendChild(SecurityTokenReferenceReference(doc, uuid));


            return securityTokenReferenceXML;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        private static XmlElement SecurityTokenReferenceReference(XmlDocument doc, string uuid)
        {
            XmlElement reference = doc.CreateElement("o", "Reference", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
            reference.SetAttribute("ValueType", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509v3");
            reference.SetAttribute("URI", $"#{uuid}");

            return reference;
        }

    }
}
