using Descarga_masiva_WS_SAT.src.Impl.Meta;

namespace Descarga_masiva_WS_SAT.src.Impl.Contractos
{
    public interface IDescargaMasivaSAT
    {
        /// <summary>
        /// Para utilizar los servicios WEB es nesario autenticarse ante el servidor del SAT, mediante un par de llaves
        /// FIEL(CER;KEY,PASSWORD) proporcinadas por el SAT. El tipo de autenticación del servicio es Security v1.0
        /// (WS-Security-2004).
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        IAutenticacion autenticar(Parametros parametro);

        /// <summary>
        /// Permite realizar solicitudes de descarga de CFDIs o Metatada por un rango de fechas, para que la petición se
        /// realizace, primero deberá autenticarcce para realizar la solicitud.
        /// </summary>
        /// <param name="parametro"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        ISolicitudDescarga solicitudDescarga(Parametros parametro, string token);


        /// <summary>
        /// Permite verificar el estatus de las solicitudes de descarga realizadas previamente del servicio de solicitudes
        /// de descarga realizadas previamente a través del servicio de solicitud de descarga masiva, en caso que la solicitud
        /// sea ACEPTADA y se encuentre con el estatus de terminado, este servicio de verificación devolverá los identificadores
        /// de los paquetes que conforman la solicitud.
        /// Para verificar, necesitamos tener al menos el token, la solicitud y los parametros.
        /// </summary>
        /// <param name="parametro"></param>
        /// <param name="token"></param>
        /// <param name="idSolicitud"></param>
        /// <returns></returns>
        IVerificarSolicitud<VerificadorMeta, TipoEstatus> verificadorDescarga(Parametros parametro, string token, string idSolicitud);


        /// <summary>
        /// Permite realizar la descarga de un paquete especifico, que forme parte de una soicitud de descarga masiva realizada a través del
        /// servicio de solicitud descarga masiva.
        /// </summary>
        /// <param name="parametro"></param>
        /// <param name="token"></param>
        /// <param name="idPaquete"></param>
        /// <param name="rfcSolicitante"></param>
        /// <returns></returns>
        IDescargaMasiva descargaMasiva(Parametros parametro, string token, string idPaquete, string rfcSolicitante);

    }
}
