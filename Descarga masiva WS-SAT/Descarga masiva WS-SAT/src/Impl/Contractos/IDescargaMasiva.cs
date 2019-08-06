using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Descarga_masiva_WS_SAT.src.Impl.Contractos
{
    public interface IDescargaMasiva
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        byte[] getIdPaqueteFromBase64String();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string getIdPaquete();


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string getNombre();


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string getDescripcion();


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string getClave();
    }
}
