using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Descarga_masiva_WS_SAT.src.Impl.Http
{
    public class RawResponse
    {
        /// <summary>
        /// 
        /// </summary>
        private String contenido;

        /// <summary>
        /// 
        /// </summary>
        private int code;

        /// <summary>
        /// 
        /// </summary>
        private string xml;

        public RawResponse(String contenido, int code, String xml)
        {
            this.contenido = contenido;
            this.code = code;
            this.xml = xml;
        }

        public String getContenido()
        {
            return this.contenido;
        }

        public int getCode()
        {
            return this.code;
        }

        public string getXML()
        {
            return this.xml;
        }
    }
}
