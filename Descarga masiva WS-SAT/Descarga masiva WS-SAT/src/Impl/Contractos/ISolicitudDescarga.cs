using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Descarga_masiva_WS_SAT.src.Impl.Contractos
{
    public interface ISolicitudDescarga
    {
        /// <summary>
        /// Obtenemos el UUID con el que podremos hacer la petición de nuestra consulta.
        /// </summary>
        /// <returns></returns>
        string getIDSolicitud();
    }
}
