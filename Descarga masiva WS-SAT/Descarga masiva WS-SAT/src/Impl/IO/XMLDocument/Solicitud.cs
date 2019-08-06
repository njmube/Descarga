using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using System.Xml;
using WSDescargaMasivaSAT.src;

namespace WSDescargaMasivaSAT.Impl.IO.XMLDocument
{
   public  class Solicitud
    {

        private static String FECHA_FORMATO = "yyyy-MM-ddTHH:mm:ss";
        private string _prefix;
        private string _localName;
        private string _namesSpaceUri;

        public Solicitud(string prefix = null, string localName = null, string namesSpaceURI = null)
        {
            _prefix = String.IsNullOrEmpty(prefix) ? "des" : prefix;
            _localName = string.IsNullOrEmpty(localName) ? "solicitud" : localName;
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
        public void XMlAttributeRFCEmisor(XmlElement securityElement, string rfcEmisor)
        {
            securityElement.SetAttribute("RfcEmisor", rfcEmisor);


        }


        public void XMlAttributeRFCREceptor(XmlElement securityElement, string rfcReceptor)
        {
            securityElement.SetAttribute("RfcReceptor", rfcReceptor);


        }

        public void XMlAttributeRFCSolicitando(XmlElement securityElement, string rfcSolicitante)
        {

            if (string.IsNullOrEmpty(rfcSolicitante))
            {
                throw new Exception("El RFC Solicitante no se ha declarado.");
            }


            securityElement.SetAttribute("RfcSolicitante", rfcSolicitante);


        }

        public void XMlAttributeFechaInicial(XmlElement securityElement, DateTime fechaInicialD)
        {

            if (fechaInicialD == null)
            {
                throw new Exception("La fecha Inicial no se ha declarado");

            }


            string fechaInicial = fechaInicialD.ToString(FECHA_FORMATO);

            securityElement.SetAttribute("FechaInicial", fechaInicial);


        }


        public void XMlAttributeFechaFinal(XmlElement securityElement, DateTime fechaFinalD)
        {

            if (fechaFinalD == null)
            {
                throw new Exception("La fecha final no se ha declarado");
            }


            string fechaFinal = fechaFinalD.ToString(FECHA_FORMATO);

            securityElement.SetAttribute("FechaFinal", fechaFinal);


        }

        public void XMlAttributeTipoSolicitud(XmlElement securityElement, TipoSolicitud tipoSolicitud)
        {
            securityElement.SetAttribute("TipoSolicitud", tipoSolicitud.ToString());

        }


        public void XMlAttributeIdSolicitud(XmlElement securityElement,string idSolicitud, ParametroXmlElement parametroElement = null)
        {

            securityElement.SetAttribute("IdSolicitud", idSolicitud);
        }


        public void XMlAttributeRfcSolicitante(XmlElement securityElement, string rfcSolicitante, ParametroXmlElement parametroElement = null)
        {

            if (string.IsNullOrEmpty(rfcSolicitante))
            {
                throw new Exception("El rfc solicitante no se ha declaro en la Solicitud");
            }

            securityElement.SetAttribute("RfcSolicitante", rfcSolicitante);
        }
    }
}
