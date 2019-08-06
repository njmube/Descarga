using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Descarga_masiva_WS_SAT.src.Impl.Meta
{
    public class DescargaMeta
    {
        /// <summary>
        /// 
        /// </summary>
        public string idPaquete { get; set; }

        /// <summary>
        /// Coódigo de estatus de la petición de verificación.
        /// </summary>
        public TipoEstatus CodigoEstatus { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Mensaje { get; set; }
    }
}
