using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using WSSATMasiva.Impl;

namespace WSSATMasiva
{
    interface IConsultaWSSAT<T,M>
    {

        /// <summary>
        /// Para utilizar el WS del sat es necesario autenticarse ante el servidor de servicios web mediante un par de llaves
        /// proporcionados por el SAT(CER, KEY)  corresponden al certificado de e.firma vigente.
        /// Pametros de entrado son:
        /// - Sello digital
        /// </summary>
        /// <returns>Token para poder consultar los demas servicios
        /// del  WS SAT</returns>
        IAutenticacion autenticar();


        /// <summary>
        /// Permite solicitar la descarga de CFDIs o Metadata esté devolvera un ID de solicitud o estatus de la petición realizada.
        /// Los parametros de entrada son:
        /// - Authorization.
        /// - FechaInicial.
        /// - FechaFinal.
        /// - RfcReceptor.
        /// - RfcEmisor.
        /// - RFCSolicitante.
        /// - TipoSolicitud.
        /// - Signature.
        /// Los parametros de salida son:
        /// - IdSolicitud.
        /// - CodEstatus.
        /// - Mensaje.
        /// </summary>
        /// <returns></returns>
        ISolicitudDescarga solicitud();


        /// <summary>
        /// Permite verificar el status de las solicitudes de descarga realizada previamente a través del servicio de solictud
        /// de descarga masiva, en caso de que la solictud de descarga haya sido aceptada y se encuentre con status de terminado,
        /// este servicio de verificación devolverá los identificadores de los paquetes que conforman la solictud de descarga.
        /// Los parametros de entra son:
        /// - Authorization.
        /// - IdSolicitud.
        /// - RfcSolicitante.
        /// - Signature.
        /// Los parametros de salida son:
        /// - IdsPaquete.
        /// - EstadoSolicitud.
        /// - CodigoEstadoSol.
        /// - NumeroCFDIs.
        /// - CodEstatus.
        /// - Mensaje.
        /// </summary>
        /// <returns></returns>
        IVerificarSolicitud<T,M> verificarSolicitud();



        /// <summary>
        /// Permite realizar la descarga de los paquetes que contiene los XML, los parametros necesarios son:
        /// - IdPaquete.
        /// - RFCSolicitante.
        /// - Signature.
        /// - CodEstatus.
        /// - Mensaje.
        /// - Paquete.
        /// </summary>
        /// <returns></returns>
        IDescargaMasiva descargaMasiva();



    }
}
