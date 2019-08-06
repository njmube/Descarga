using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Descarga_masiva_WS_SAT.src.Impl.Contractos
{
    public interface IAutenticacion
    {
        /// <summary>
        /// Obtenemos el token para hacer las demas solicitudes al
        /// WS del SAT.
        /// </summary>
        /// <returns></returns>
        String getToken();
    }
}
