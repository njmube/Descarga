using Descarga_masiva_WS_SAT.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using System.Xml;

namespace WSDescargaMasivaSAT.Impl.http.clienteSoap.IO.XMLDocument
{
    public interface ISerializador<T>
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        T Deserializador(string XML);


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        XmlDocument Serializador(Parametros parametro);
    }
}
