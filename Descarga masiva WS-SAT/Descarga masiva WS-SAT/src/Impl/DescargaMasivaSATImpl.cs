using Descarga_masiva_WS_SAT.src.Impl.Contractos;
using Descarga_masiva_WS_SAT.src.Impl.Http;
using Descarga_masiva_WS_SAT.src.Impl.Http.lSoap;
using Descarga_masiva_WS_SAT.src.Impl.Meta;
using Descarga_masiva_WS_SAT.src.Impl.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSDescargaMasivaSAT.Impl.http.clienteSoap.IO.XMLDocument.Autenticacion;
using WSDescargaMasivaSAT.Impl.http.clienteSoap.IO.XMLDocument.Descarga;
using WSDescargaMasivaSAT.Impl.http.clienteSoap.IO.XMLDocument.Solicitud;
using WSDescargaMasivaSAT.Impl.http.clienteSoap.IO.XMLDocument.Verificacion;

namespace Descarga_masiva_WS_SAT.src.Impl
{
    public class DescargaMasivaSATImpl : IDescargaMasivaSAT
    {
        /// <summary>
        /// 
        /// </summary>
        private RequestFactory _requestFactory;
        private UserAgent _userAgent;


        public DescargaMasivaSATImpl()
        {
            _requestFactory = new RequestFactory();
            _userAgent = new UserAgent();
        }

        /// <summary>
        /// Solicitamos la autenticación al SAT, esto nos devolvera el token para seguir utilizando las peticiones.
        /// TODO: Cada 5 minutos se tiene que crear un nuevo token.
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        public IAutenticacion autenticar(Parametros parametro)
        {

            Request request = _requestFactory.newConsultaRequestAutenticacion(parametro);

            Response response = _userAgent.open(request);

            if (response.getCode() != 200)
            {
                throw new Exception("Ocurrió un error al "
                + "comunicarse con el servidor de descarga masiva del SAT ."
                + "Código del servidor: "
                + response.getCode());
            }


            AutenticacionSerializador autenticador = new AutenticacionSerializador();
            AutenticacionMeta autenticacionMeta = autenticador.Deserializador(response.getXML());

            IAutenticacion autenticacion = new AutenticacionImpl(_requestFactory, _userAgent, autenticacionMeta.IdToken);

            return autenticacion;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametro"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public ISolicitudDescarga solicitudDescarga(Parametros parametro, string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new Exception("Token no se declarado");
            }


            Request request = _requestFactory.newCosultaRequestSolicitudDescarga(parametro, token);

            Response response = _userAgent.open(request);

            if (response.getCode() != 200)
            {
                throw new Exception("Ocurrió un error al "
                + "comunicarse con el servidor de descarga masiva del SAT ."
                + "Código del servidor: "
                + response.getCode());
            }


            SolicitudDeserializador solicitudDeserializador = new SolicitudDeserializador();
            SolicitudDescargaMeta soicitudDescarga = solicitudDeserializador.Deserializador(response.getXML());


            ISolicitudDescarga solicituDescarga = new SolicitaDescargaImp(_requestFactory, _userAgent, soicitudDescarga);


            return solicituDescarga;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametro"></param>
        /// <param name="token"></param>
        /// <param name="idSolicitud"></param>
        /// <returns></returns>
        public IVerificarSolicitud<VerificadorMeta, TipoEstatus> verificadorDescarga(Parametros parametro, string token, string idSolicitud)
        {

            if (string.IsNullOrEmpty(token))
            {
                throw new Exception("Token no se declarado");
            }


            if (string.IsNullOrEmpty(idSolicitud))
            {
                throw new Exception("IdSolicitud no se ha declarado22");
            }




            Request request = _requestFactory.newCosultaRequestVerificacionSolicitud(parametro, token, idSolicitud);
            Response response = _userAgent.open(request);



            VerificadorSerializador verificadorSerializador = new VerificadorSerializador();
            VerificadorMeta verificadorMeta = verificadorSerializador.Deserializador(response.getXML());



            IVerificarSolicitud<VerificadorMeta, TipoEstatus> verificador = newVerificadorImpl(parametro, verificadorMeta, token, idSolicitud);

            return verificador;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametro"></param>
        /// <param name="token"></param>
        /// <param name="idPaquete"></param>
        /// <param name="rfcSolicitante"></param>
        /// <returns></returns>
        public IDescargaMasiva descargaMasiva(Parametros parametro, string token, string idPaquete, string rfcSolicitante)
        {

            if (string.IsNullOrEmpty(token))
            {
                throw new Exception("Token no se declarado");
            }


            if (string.IsNullOrEmpty(rfcSolicitante))
            {
                throw new Exception("El RFC solicitante no se ha declarado.");
            }

            Request request = _requestFactory.newCosultaRequestDescargaMasiva(parametro, token, idPaquete, rfcSolicitante);

            Response response = _userAgent.open(request);



            DescargaSerializador descargaSerializador = new DescargaSerializador();
            DescargaMeta descargaMeta = descargaSerializador.Deserializador(response.getXML());


            IDescargaMasiva descargaMasiva = new DescargaMasivaImpl(_requestFactory, _userAgent, descargaMeta);

            return descargaMasiva;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametro"></param>
        /// <param name="verificadorMeta"></param>
        /// <param name="idToken"></param>
        /// <param name="idSolicitud"></param>
        /// <returns></returns>
        private IVerificarSolicitud<VerificadorMeta, TipoEstatus> newVerificadorImpl(Parametros parametro, VerificadorMeta verificadorMeta, string idToken, string idSolicitud)
        {

            IVerificarSolicitud<VerificadorMeta, TipoEstatus> verificador = new VerificadorDescargaImp(_requestFactory,
                                                                        _userAgent,
                                                                        verificadorMeta,
                                                                        parametro,
                                                                        idToken,
                                                                        idSolicitud);

            return verificador;

        }
    }
}
