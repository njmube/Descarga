using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using System.Xml;
using WSDescargaMasivaSAT.Impl.IO.XMLDocument;

namespace WSDescargaMasivaSAT.Impl.http.clienteSoap.IO
{
    public class DigestMethod
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

        public DigestMethod(string prefix = null, string localName = null, string namesSpaceURI = null)
        {
            _prefix = String.IsNullOrEmpty(prefix) ? "DigestMethod" : prefix;
            _localName = string.IsNullOrEmpty(localName) ? "" : localName;
            _namesSpaceUri = String.IsNullOrEmpty(namesSpaceURI) ? "" : namesSpaceURI;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public  XmlElement xmlReferenceDigestMethod(XmlDocument doc)
        {
            XmlElement digestMethodXML = doc.CreateElement(_prefix);
            
            return digestMethodXML;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="securityElement"></param>
        /// <param name="listaParametrosXmlelement"></param>
        public void XMlAttributeList(XmlElement securityElement, List<ParametroXmlElement> listaParametrosXmlelement)
        {
           
            foreach (ParametroXmlElement parametro in listaParametrosXmlelement)
            {
                securityElement.SetAttribute(parametro.LocalName, parametro.NameSpaceURI);
            }

        }

    }
}
