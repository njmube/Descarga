using Descarga_masiva_WS_SAT.src.Impl.Contractos;
using Descarga_masiva_WS_SAT.src.Impl.Http.lSoap;
using Descarga_masiva_WS_SAT.src.Impl.Utils;
using System;

namespace Descarga_masiva_WS_SAT.src.Impl
{
    public class AutenticacionImpl : IAutenticacion
    {
        private RequestFactory _requestFactory;
        private UserAgent _userAgent;
        private string _token;


        public AutenticacionImpl(RequestFactory requestFactory, UserAgent userAgent, string token)
        {
            _requestFactory = requestFactory;
            _userAgent = userAgent;
            _token = token;
        }


        public String getToken()
        {
            return _token;
        }
    }
}
