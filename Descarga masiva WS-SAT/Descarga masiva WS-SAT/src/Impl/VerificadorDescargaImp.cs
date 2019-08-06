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
using WSDescargaMasivaSAT.Impl.http.clienteSoap.IO.XMLDocument.Verificacion;

namespace Descarga_masiva_WS_SAT.src.Impl
{
    public class VerificadorDescargaImp : IVerificarSolicitud<VerificadorMeta, TipoEstatus>
    {
        private RequestFactory _requestFactory;
        private UserAgent _userAgent;
        private VerificadorMeta _verificadorMEta;
        private Parametros _parametro;
        private string _idToken;
        private string _idSolicitud;

        public VerificadorDescargaImp(RequestFactory requestFactory,
                                      UserAgent userAgent,
                                      VerificadorMeta verificadorMEta,
                                      Parametros parametro,
                                      string idToken,
                                      string idSolicitud)
        {
            _requestFactory = requestFactory;
            _userAgent = userAgent;
            _verificadorMEta = verificadorMEta;
            _parametro = parametro;
            _idToken = idToken;
            _idSolicitud = idSolicitud;
        }

        public string getCodigoEstadoSolicitud()
        {
            return _verificadorMEta.CodigoEstadoSolicitud;
        }

        public TipoEstatus getCodigoEstatus()
        {
            return _verificadorMEta.CodigoEstatus;
        }

        public string getEstadoSolicitud()
        {
            return _verificadorMEta.EstadoSolicitud;
        }

        public List<string> getListaFolios()
        {
            return _verificadorMEta.ListaIdPaquestes;
        }

        public string getMensaje()
        {
            return _verificadorMEta.Mensaje;
        }

        public string getNumeroCFDI()
        {
            return _verificadorMEta.NumeroCFDIs;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public VerificadorMeta getStatus()
        {
            Request request = _requestFactory.newCosultaRequestVerificacionSolicitud(_parametro, _idToken, _idSolicitud);
            Response response = _userAgent.open(request);

            VerificadorSerializador verificadorSerializador = new VerificadorSerializador();
            VerificadorMeta verificadorMeta = verificadorSerializador.Deserializador(response.getXML());

            return verificadorMeta;
        }



        public bool isCompletado()
        {
            VerificadorMeta verificadorMeta = this.getStatus();

            string status = verificadorMeta.EstadoSolicitud;

            if (status.ToString() == EstadoSolicitud2.TERMINADA || this.isFallo())
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool isFallo()
        {

            VerificadorMeta verificadorMeta = this.getStatus();

            string falloStatus = verificadorMeta.EstadoSolicitud;

            TipoEstatus falloCodigoEstatus = verificadorMeta.CodigoEstatus;


            if (falloStatus == EstadoSolicitud2.ERROR)
            {
                throw new Exception(verificadorMeta.Mensaje + " - " + verificadorMeta.CodigoEstadoSolicitud);
            }

            if (falloStatus == EstadoSolicitud2.RECHAZADA)
            {
                throw new Exception(verificadorMeta.Mensaje + " - " + verificadorMeta.CodigoEstadoSolicitud);
            }


            if (falloStatus == EstadoSolicitud2.VENCIDA)
            {
                throw new Exception("Error solicitud vencidad");
            }
            if (falloCodigoEstatus.ToString() == TipoEstatus._300().ToString())
            {
                throw new Exception(falloCodigoEstatus.getClave() + " - " + verificadorMeta.Mensaje);
            }

            if (falloCodigoEstatus.ToString() == TipoEstatus._301().ToString())
            {
                throw new Exception(falloCodigoEstatus.getClave() + verificadorMeta.Mensaje);
            }

            if (falloCodigoEstatus.ToString() == TipoEstatus._302().ToString())
            {
                throw new Exception(falloCodigoEstatus.getClave() + verificadorMeta.Mensaje);
            }

            if (falloCodigoEstatus.ToString() == TipoEstatus._303().ToString())
            {
                throw new Exception(falloCodigoEstatus.getClave() + verificadorMeta.Mensaje);
            }


            if (falloCodigoEstatus.ToString() == TipoEstatus._304().ToString())
            {
                throw new Exception(falloCodigoEstatus.getClave() + verificadorMeta.Mensaje);
            }


            if (falloCodigoEstatus.ToString() == TipoEstatus._305().ToString())
            {
                throw new Exception(falloCodigoEstatus.getClave() + verificadorMeta.Mensaje);
            }


            if (falloCodigoEstatus.ToString() == TipoEstatus._404().ToString())
            {
                throw new Exception(falloCodigoEstatus.getClave() + verificadorMeta.Mensaje);
            }
            return false;
        }

        public bool isTerminada()
        {
            return this.isCompletado();
        }

    }
}
