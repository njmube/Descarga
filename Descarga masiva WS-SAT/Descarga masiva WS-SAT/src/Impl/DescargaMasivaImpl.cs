using Descarga_masiva_WS_SAT.src.Impl.Contractos;
using Descarga_masiva_WS_SAT.src.Impl.Http.lSoap;
using Descarga_masiva_WS_SAT.src.Impl.Meta;
using Descarga_masiva_WS_SAT.src.Impl.Utils;
using System;

namespace Descarga_masiva_WS_SAT.src.Impl
{
    public class DescargaMasivaImpl : IDescargaMasiva
    {
        private DescargaMeta _descargaMeta;
        private RequestFactory _requestFactory;
        private UserAgent _userAgent;

        public DescargaMasivaImpl(RequestFactory requestFactory,
                                  UserAgent userAgent,
                                   DescargaMeta descargaMeta)
        {
            _requestFactory = requestFactory;
            _userAgent = userAgent;
            _descargaMeta = descargaMeta;
        }


        public byte[] getIdPaqueteFromBase64String()
        {
            validarCodigoEstatus();

            byte[] file = Convert.FromBase64String(_descargaMeta.idPaquete);

            return file;
        }

        public string getIdPaquete()
        {
            validarCodigoEstatus();
            return _descargaMeta.idPaquete;
        }

        public DescargaMeta getDescargaMeta()
        {
            return _descargaMeta;
        }


        public string getNombre()
        {
            return _descargaMeta.CodigoEstatus.getNombre();
        }

        public string getDescripcion()
        {
            return _descargaMeta.CodigoEstatus.getDescripcion();
        }

        public string getClave()
        {
            return _descargaMeta.CodigoEstatus.getClave();
        }



        public void validarCodigoEstatus()
        {


            TipoEstatus falloCodigoEstatus = _descargaMeta.CodigoEstatus;

            if (falloCodigoEstatus.ToString() == TipoEstatus._300().ToString())
            {
                throw new Exception(falloCodigoEstatus.getClave() + " - " + _descargaMeta.Mensaje);
            }

            if (falloCodigoEstatus.ToString() == TipoEstatus._301().ToString())
            {
                throw new Exception(falloCodigoEstatus.getClave() + " - " + _descargaMeta.Mensaje);
            }

            if (falloCodigoEstatus.ToString() == TipoEstatus._302().ToString())
            {
                throw new Exception(falloCodigoEstatus.getClave() + " - " + _descargaMeta.Mensaje);
            }

            if (falloCodigoEstatus.ToString() == TipoEstatus._303().ToString())
            {
                throw new Exception(falloCodigoEstatus.getClave() + " - " + _descargaMeta.Mensaje);
            }


            if (falloCodigoEstatus.ToString() == TipoEstatus._304().ToString())
            {
                throw new Exception(falloCodigoEstatus.getClave() + " - " + _descargaMeta.Mensaje);
            }


            if (falloCodigoEstatus.ToString() == TipoEstatus._305().ToString())
            {
                throw new Exception(falloCodigoEstatus.getClave() + " - " + _descargaMeta.Mensaje);
            }


            if (falloCodigoEstatus.ToString() == TipoEstatus._5004().ToString())
            {
                throw new Exception(falloCodigoEstatus.getClave() + " - " + _descargaMeta.Mensaje);
            }

            if (falloCodigoEstatus.ToString() == TipoEstatus._5007().ToString())
            {
                throw new Exception(falloCodigoEstatus.getClave() + " - " + _descargaMeta.Mensaje);
            }

            if (falloCodigoEstatus.ToString() == TipoEstatus._5008().ToString())
            {
                throw new Exception(falloCodigoEstatus.getClave() + " - " + _descargaMeta.Mensaje);
            }



            if (falloCodigoEstatus.ToString() == TipoEstatus._404().ToString())
            {
                throw new Exception(falloCodigoEstatus.getClave() + " - " + _descargaMeta.Mensaje);
            }



        }
    }
}
