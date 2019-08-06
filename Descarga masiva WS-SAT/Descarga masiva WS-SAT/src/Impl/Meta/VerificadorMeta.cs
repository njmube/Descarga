using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Descarga_masiva_WS_SAT.src.Impl.Meta
{
    public class VerificadorMeta
    {
        /// <summary>
        /// Contiene los identificadores de los paquetes que componen la solicitud de descarga masiva.
        /// Solo devuelve cuando la solicitud posee un estatus  de finalizado
        /// </summary>
        public List<string> ListaIdPaquestes { get; set; }


        /// <summary>
        /// Contiene el número correspondiente al estado de la solicitud de la descarga
        /// Estados:
        /// - Aceptada = 1,
        /// - EnProceso = 2;
        /// - Terminada = 3;
        /// - Error = 4;
        /// - Rechazada = 5;
        /// - Vencida = 6;
        /// </summary>
        public string EstadoSolicitud { get; set; }


        /// <summary>
        /// Coódigo de estatus de la petición de verificación.
        /// </summary>
        public TipoEstatus CodigoEstatus { get; set; }



        /// <summary>
        /// Contiene el código de estado de la solicitud de descarga,
        /// los cuales pueden ser:
        /// 5000
        /// 5002
        /// 5003
        /// 5004
        /// 5005
        /// </summary>
        public string CodigoEstadoSolicitud { get; set; }



        /// <summary>
        /// Número de CFDI que conforman la solicitud de descarga consultada.
        /// </summary>
        public string NumeroCFDIs { get; set; }


        /// <summary>
        /// Descripción del código correspondiente a la petición.
        /// </summary>
        public string Mensaje { get; set; }
    }
}
