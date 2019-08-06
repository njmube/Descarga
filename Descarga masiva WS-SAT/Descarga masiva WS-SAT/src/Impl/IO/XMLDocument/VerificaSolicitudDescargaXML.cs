using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using System.Xml;

namespace WSDescargaMasivaSAT.Impl.IO.XMLDocument
{
    public class VerificaSolicitudDescargaXML
    {
        private string _prefix;
        private string _localName;
        private string _namesSpaceUri;

        public VerificaSolicitudDescargaXML(string prefix = null, string localName = null, string namesSpaceURI = null)
        {
            _prefix = String.IsNullOrEmpty(prefix) ? "des" : prefix;
            _localName = string.IsNullOrEmpty(localName) ? "VerificaSolicitudDescarga" : localName;
            _namesSpaceUri = String.IsNullOrEmpty(namesSpaceURI) ? "http://DescargaMasivaTerceros.sat.gob.mx" : namesSpaceURI;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public XmlElement XmlXMlElement(XmlDocument doc)
        {
            XmlElement bodyXml = doc.CreateElement(_prefix, _localName, _namesSpaceUri);
            return bodyXml;

        }
    }
}
