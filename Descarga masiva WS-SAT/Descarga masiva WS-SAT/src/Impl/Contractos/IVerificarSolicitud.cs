using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Descarga_masiva_WS_SAT.src.Impl.Contractos
{
    public interface IVerificarSolicitud<T, M>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        T getStatus();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Boolean isTerminada();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool isFallo();


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool isCompletado();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        M getCodigoEstatus();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string getEstadoSolicitud();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string getCodigoEstadoSolicitud();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string getNumeroCFDI();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string getMensaje();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<String> getListaFolios();
    }
}
