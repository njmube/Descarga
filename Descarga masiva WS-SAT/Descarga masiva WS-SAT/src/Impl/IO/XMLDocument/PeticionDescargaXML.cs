using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using System.Xml;

namespace WSDescargaMasivaSAT.Impl.IO.XMLDocument
{
    public class PeticionDescargaXML
    {
        private string _prefix;
        private string _localName;
        private string _namesSpaceUri;

        public PeticionDescargaXML(string prefix = null, string localName = null, string namesSpaceURI = null)
        {
            _prefix = String.IsNullOrEmpty(prefix) ? "o" : prefix;
            _localName = string.IsNullOrEmpty(localName) ? "des:peticionDescarga" : localName;
            _namesSpaceUri = String.IsNullOrEmpty(namesSpaceURI) ? "http://DescargaMasivaTerceros.sat.gob.mx" : namesSpaceURI;
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="securityElement"></param>
        /// <param name="listaParametrosXmlelement"></param>
        public void XMlAttributeIdPaquete(XmlElement securityElement, string idPaquete)
        {
            securityElement.SetAttribute("IdPaquete", idPaquete);


        }


        public void XMlAttributeRfcSolicitante(XmlElement securityElement, string rfcSolicitante)
        {
            securityElement.SetAttribute("RfcSolicitante", rfcSolicitante);


        }
    }
}
