using Descarga_masiva_WS_SAT.src.Impl.Contractos;
using Descarga_masiva_WS_SAT.src.Impl.Http.lSoap;
using Descarga_masiva_WS_SAT.src.Impl.Meta;
using Descarga_masiva_WS_SAT.src.Impl.Utils;
using System;

namespace Descarga_masiva_WS_SAT.src.Impl
{
    public class SolicitaDescargaImp : ISolicitudDescarga
    {
        private RequestFactory _requestFactory;
        private UserAgent _userAgent;
        private SolicitudDescargaMeta _solicitaDescarga;



        public SolicitaDescargaImp(RequestFactory requestFactory, UserAgent userAgent, SolicitudDescargaMeta solicitaDescarga)
        {
            _requestFactory = requestFactory;
            _userAgent = userAgent;
            _solicitaDescarga = solicitaDescarga;
        }



        public string getIDSolicitud()
        {
            validarSolicitud();

            return _solicitaDescarga.IdSolicitud;
        }


        private void validarSolicitud()
        {
            TipoEstatus falloCodigoEstatus = _solicitaDescarga.CodigoEstatus;

            if (falloCodigoEstatus.ToString() == TipoEstatus._300().ToString())
            {
                throw new Exception(falloCodigoEstatus.getClave() + " - " + _solicitaDescarga.Mensaje);
            }

            if (falloCodigoEstatus.ToString() == TipoEstatus._301().ToString())
            {
                throw new Exception(falloCodigoEstatus.getClave() + " - " + _solicitaDescarga.Mensaje);
            }

            if (falloCodigoEstatus.ToString() == TipoEstatus._302().ToString())
            {
                throw new Exception(falloCodigoEstatus.getClave() + " - " + _solicitaDescarga.Mensaje);
            }

            if (falloCodigoEstatus.ToString() == TipoEstatus._303().ToString())
            {
                throw new Exception(falloCodigoEstatus.getClave() + " - " + _solicitaDescarga.Mensaje);
            }


            if (falloCodigoEstatus.ToString() == TipoEstatus._304().ToString())
            {
                throw new Exception(falloCodigoEstatus.getClave() + " - " + _solicitaDescarga.Mensaje);
            }


            if (falloCodigoEstatus.ToString() == TipoEstatus._305().ToString())
            {
                throw new Exception(falloCodigoEstatus.getClave() + " - " + _solicitaDescarga.Mensaje);
            }


            if (falloCodigoEstatus.ToString() == TipoEstatus._5004().ToString())
            {
                throw new Exception(falloCodigoEstatus.getClave() + " - " + _solicitaDescarga.Mensaje);
            }

            if (falloCodigoEstatus.ToString() == TipoEstatus._5007().ToString())
            {
                throw new Exception(falloCodigoEstatus.getClave() + " - " + _solicitaDescarga.Mensaje);
            }

            if (falloCodigoEstatus.ToString() == TipoEstatus._5008().ToString())
            {
                throw new Exception(falloCodigoEstatus.getClave() + " - " + _solicitaDescarga.Mensaje);
            }



            if (falloCodigoEstatus.ToString() == TipoEstatus._404().ToString())
            {
                throw new Exception(falloCodigoEstatus.getClave() + " - " + _solicitaDescarga.Mensaje);
            }

        }
    }
}
