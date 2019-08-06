using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using System.Xml;

namespace WSDescargaMasivaSAT.Impl.IO.XMLDocument
{ 
   public class PeticionDescargaMasivaTercerosEntradaXML
    {
        private string _prefix;
        private string _localName;
        private string _namesSpaceUri;

        public PeticionDescargaMasivaTercerosEntradaXML(string prefix = null, string localName = null, string namesSpaceURI = null)
        {
            _prefix = String.IsNullOrEmpty(prefix) ? "des" : prefix;
            _localName = string.IsNullOrEmpty(localName) ? "PeticionDescargaMasivaTercerosEntrada" : localName;
            _namesSpaceUri = String.IsNullOrEmpty(namesSpaceURI) ? "http://DescargaMasivaTerceros.sat.gob.mx" : namesSpaceURI;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public XmlElement XmlElement(XmlDocument doc)
        {
            XmlElement xml = doc.CreateElement(_prefix,_localName, _namesSpaceUri);
            return xml;
        }


      
    }
}
