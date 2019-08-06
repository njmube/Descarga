using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
 
using System.Xml;

namespace WSDescargaMasivaSAT.Impl.IO.XMLDocument
{
   public  class SignedXmlWithId : SignedXml
    {
        public SignedXmlWithId(XmlDocument xml)
           : base(xml)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlDocument"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public override XmlElement GetIdElement(XmlDocument xmlDocument, string id)
        {
            var standardIdReferenceElement = base.GetIdElement(xmlDocument, id);

            if (standardIdReferenceElement != null)
            {
                return standardIdReferenceElement;
            }

            var namespaceManager = new XmlNamespaceManager(xmlDocument.NameTable);
            namespaceManager.AddNamespace("wsu", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd");
            return xmlDocument.SelectSingleNode("//*[@wsu:Id=\"" + id + "\"]", namespaceManager) as XmlElement;
        }
    }
}
