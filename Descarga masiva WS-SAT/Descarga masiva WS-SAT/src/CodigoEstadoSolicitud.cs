using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Descarga_masiva_WS_SAT.src
{
    public class CodigoEstadoSolicitud
    {
        private static string SOLICITUD_RECIBIDAD_CON_EXITO = "5000";
        private static string SE_AGOTO_LAS_SOLICITUDES_DE_POR_VIDA;
        private static string TOPE_MAXIMO;
        private static string NO_SE_ENCONTRO_INFORMACION;
        private static string SOLICITUD_DUPLICADA;
        private static string ERROR_NO_CONTROLADO;
        private static string CERTIFICADO_INVALIDO;
        private static string SELLO_NO_CORRESPONDE_CON_RFC_SOLICITANTE;
        private static string SELLO_MAL_FORMADO;
        private static string XML_MAL_FORMADO;
        private static string USUARIO_NO_VALIDO;


        private String nombre;
        private String clave;
        private String descripcion;


        public CodigoEstadoSolicitud(String clave, String nombre, String descripcion)
        {
            this.clave = clave;
            this.nombre = nombre;
            this.descripcion = descripcion;

        }

        public static String _SOLICITUD_RECIBIDAD_CON_EXITO()
        {
            if (CodigoEstadoSolicitud.SOLICITUD_RECIBIDAD_CON_EXITO.Length < 0)
            {
                new CodigoEstadoSolicitud("5000", "Solicitud recibida con éxtio.", "Indica que la solicitud de descarga que se" +
                    " esta verificando fue aceptada.");
            }
            return CodigoEstadoSolicitud.SOLICITUD_RECIBIDAD_CON_EXITO;
        }


        public static String _SE_AGOTO_LAS_SOLICITUDES_DE_POR_VIDA()
        {
            if (CodigoEstadoSolicitud.SE_AGOTO_LAS_SOLICITUDES_DE_POR_VIDA.Length < 0)
            {
                new CodigoEstadoSolicitud("5002", "Se agoto las solicitudes de por vida.", "Para el caso de descarga de tipo CFDI" +
                    " se tiene un límite máximo para solicitudes con los mismos parametros(F.I, F.F, RFCEMISOR, RFCRECEPTOR");
            }
            return CodigoEstadoSolicitud.SE_AGOTO_LAS_SOLICITUDES_DE_POR_VIDA;
        }


        public static String _TOPE_MAXIMO()
        {
            if (CodigoEstadoSolicitud.TOPE_MAXIMO.Length < 0)
            {
                new CodigoEstadoSolicitud("5003", "Tope máximo", "Indica que en base a los parametros de consulta se esta superando" +
                    " el tpo máximo de CFDI o Metadata por solicitud de descarga masiva.");
            }
            return CodigoEstadoSolicitud.TOPE_MAXIMO;
        }


        public String getClave()
        {
            return this.clave;
        }

        public String getNombre()
        {
            return this.nombre;
        }

        public String getDescripcion()
        {
            return this.descripcion;
        }

        public override string ToString()
        {
            return this.getClave() + " - " + this.getNombre() + " - " + this.getDescripcion();
        }
    }
}
