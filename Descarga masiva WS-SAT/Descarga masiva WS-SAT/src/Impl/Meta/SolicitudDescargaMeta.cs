using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Descarga_masiva_WS_SAT.src.Impl.Meta
{
    public class SolicitudDescargaMeta
    { 
        /// <summary>
      /// Contiene el resultado de la petición con el código de respuesta y de los UUIDs de los CFDIs 
      /// cuales se solicitud la descarga.
      /// </summary>
        public string IdSolicitud { get; set; }

        /// <summary>
        /// Código estatus de la solicitud
        /// </summary>
        public TipoEstatus CodigoEstatus { get; set; }


        /// <summary>
        /// Pequeña descripción del código estatus.
        /// </summary>
        public string Mensaje { get; set; }
    }
}
