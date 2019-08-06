using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Descarga_masiva_WS_SAT.src.Impl.Http
{
    public class Request
    {
        public enum HttpMethod
        {
            GET,
            POST
        }


        public enum MediaType
        {
            X_WWW_FORM_URLENCODED, //x-www-form-urlencoded
            JSON, // application/json
            TEXT_XML // text/xml
        }



        public enum WS_SAT
        {
            AUTENTICACION,
            SOLICITUD,
            VERIFICACION,
            DESCARGA
        }


        private Uri uri;
        private HttpMethod method;
        private String XML;
        private MediaType acceptMediaType;
        private MediaType mediaType = MediaType.TEXT_XML;
        private Dictionary<String, String> entity;
        private string cadena;
        private WS_SAT wsSAT;


        public int MaxTimeMilliseconds { get; set; } = 120000;
        public string SoapActionPath { get; set; }
        public string Header { get; set; }

        public Parametros parametros { get; set; }
        public string IdSolicitud { get; set; }
        public string IdPaquete { get; set; }
        public string paquete { get; set; }
        public EstadoSolicitud CodigoEstatus { get; set; }
        public string Mensaje { get; set; }
        public string RFcSolicitante { get; set; }
        public XmlDocument _xmlDocuments;

        public string Token { get; set; }



        public Request(Uri uri, HttpMethod httpMethod, XmlDocument xmlDocuments)
        {
            this.uri = uri;
            this.method = httpMethod;
            _xmlDocuments = xmlDocuments;
        }




        public XmlDocument getXMlDocument()
        {
            return _xmlDocuments;
        }


        public Uri getURI()
        {
            return this.uri;
        }


        public void setWSSat(WS_SAT sat)
        {
            this.wsSAT = sat;
        }


        public WS_SAT getWSSAT()
        {
            return this.wsSAT;
        }


        public HttpMethod setMethod(HttpMethod method)
        {
            return this.method = method;
        }


        public HttpMethod getMethod()
        {
            return this.method;
        }

        public MediaType getAcceptMediaType()
        {
            return this.acceptMediaType;
        }

        public MediaType setAcceptMediaType(MediaType acceptMediaType)
        {
            return this.acceptMediaType = acceptMediaType;

        }

        public string setCadena(string cadena)
        {
            return this.cadena = cadena;

        }

        public string getCadena()
        {
            return this.cadena;
        }

        public Dictionary<String, String> getEntity()
        {
            return this.entity;
        }

        public Request setEntity(Dictionary<String, String> entity)
        {
            this.entity = entity;

            return this;
        }


        public MediaType getMediaType()
        {
            return this.mediaType;
        }


        public MediaType setMediaType(MediaType mediaType)
        {
            return this.mediaType = mediaType;
        }


    }
}
