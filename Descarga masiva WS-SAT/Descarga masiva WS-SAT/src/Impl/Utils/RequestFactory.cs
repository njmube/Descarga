using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Descarga_masiva_WS_SAT.src.Impl.Utils
{
    public class RequestFactory
    {
        public static String HOST_DEFAULT = "cfdidescargamasivasolicitud.clouda.sat.gob.mx";
        public static String PATH_DEFAULT = "/Autenticacion/Autenticacion.svc";
        public static String SCHEMA_DEFAULT = "https";





        private String wsSchema;
        private String wsHost;
        private String wsPath;



        public RequestFactory(String wsSchema = null, String wsHost = null, String wsPath = null)
        {

            this.wsSchema = wsSchema == null ? SCHEMA_DEFAULT : wsSchema;
            this.wsHost = wsHost == null ? HOST_DEFAULT : wsHost;
            this.wsPath = wsPath == null ? PATH_DEFAULT : wsPath;

        }

        protected UriBuilder newBaseURIBuilder(String path)
        {
            UriBuilder uriBuilder = new UriBuilder();
            uriBuilder.Scheme = wsSchema;
            uriBuilder.Host = wsHost;
            uriBuilder.Path = wsPath + path;

            return uriBuilder;
        }

        protected UriBuilder newBaseURIBuilder(String wsSchema = null, String wsHost = null, String wsPath = null)
        {

            UriBuilder uriBuilder = new UriBuilder();
            uriBuilder.Scheme = wsSchema;
            uriBuilder.Host = wsHost;
            uriBuilder.Path = wsPath;

            return uriBuilder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected UriBuilder newBaseURIBuilder()
        {
            return newBaseURIBuilder(wsPath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public Request newConsultaRequestAutenticacion(Parametros parametros)
        {
            ISerializador<AutenticacionMeta> autenticacion = new AutenticacionSerializador();


            UriBuilder uriBuilder = newBaseURIBuilder();
            uriBuilder.Scheme = this.wsSchema;
            uriBuilder.Host = this.wsHost;
            uriBuilder.Path = this.wsPath;


            Request request = new Request(new Uri(uriBuilder.ToString()),
                                          Request.HttpMethod.POST,
                                          autenticacion.Serializador(parametros));

            request.SoapActionPath = "http://DescargaMasivaTerceros.gob.mx/IAutenticacion/Autentica";

            return request;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public Request newCosultaRequestSolicitudDescarga(Parametros parametros, string token)
        {
            ISerializador<SolicitudDescargaMeta> solicitud = new SolicitudDeserializador();


            UriBuilder uriBuilder = newBaseURIBuilder("https", "cfdidescargamasivasolicitud.clouda.sat.gob.mx", "/SolicitaDescargaService.svc");


            Request request = new Request(new Uri(uriBuilder.ToString()),
                                          Request.HttpMethod.POST,
                                          solicitud.Serializador(parametros));

            request.SoapActionPath = "http://DescargaMasivaTerceros.sat.gob.mx/ISolicitaDescargaService/SolicitaDescarga";
            request.setWSSat(Request.WS_SAT.SOLICITUD);
            request.Token = token;


            return request;


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public Request newCosultaRequestVerificacionSolicitud(Parametros parametros, string token, string idSolicitud)
        {
            ISerializador<VerificadorMeta> verificar = new VerificadorSerializador();


            UriBuilder uriBuilder = newBaseURIBuilder("https", "cfdidescargamasivasolicitud.clouda.sat.gob.mx", "/VerificaSolicitudDescargaService.svc");



            parametros.IDSolicitud = idSolicitud;



            Request request = new Request(new Uri(uriBuilder.ToString()),
                                          Request.HttpMethod.POST,
                                          verificar.Serializador(parametros));

            request.SoapActionPath = "http://DescargaMasivaTerceros.sat.gob.mx/IVerificaSolicitudDescargaService/VerificaSolicitudDescarga";
            request.setWSSat(Request.WS_SAT.SOLICITUD);
            request.Token = token;


            return request;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPaquete"></param>
        /// <param name="parametros"></param>
        /// <param name="signatureType"></param>
        /// <param name="codigo"></param>
        /// <param name="mensaje"></param>
        /// <param name="paquete"></param>
        /// <returns></returns>
        public Request newCosultaRequestDescargaMasiva(Parametros parametros, string token, string idPaquete, string rfcSolicitante)
        {
            ISerializador<DescargaMeta> descarga = new DescargaSerializador();


            UriBuilder uriBuilder = newBaseURIBuilder("https", "cfdidescargamasiva.clouda.sat.gob.mx", "/DescargaMasivaService.svc");

            parametros.IDPaquete = idPaquete;


            Request request = new Request(new Uri(uriBuilder.ToString()),
                                          Request.HttpMethod.POST,
                                          descarga.Serializador(parametros));


            request.SoapActionPath = "http://DescargaMasivaTerceros.sat.gob.mx/IDescargaMasivaTercerosService/Descargar";
            request.setWSSat(Request.WS_SAT.DESCARGA);
            request.Token = token;

            return request;
        }
    }
}
