using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WSSATMasiva
{
    /// <summary>
    /// Código recibidos desde la operación SolicitudDescarga.
    /// </summary>
    public class TipoEstatus
    {
        private string clave;
        private string descripcion;
        private string nombre;

        public TipoEstatus(string clave, string nombre, String descripcion = null)
        {
            this.clave = clave;
            this.nombre = nombre;
            this.descripcion = descripcion;
        }

        /// <summary>
        /// Código de error que regresa cuando el Request posee información invalidad.
        /// </summary>
        /// <returns></returns>
        public static TipoEstatus _300()
        {
            return new TipoEstatus("300", "Usuario No Válido", "");
        }

        /// <summary>
        /// Código de error del XML mal formado.
        /// </summary>
        /// <returns></returns>
        public static TipoEstatus _301()
        {
            return new TipoEstatus("301", "XML Mal Formado", "Código de error se regresa cuando el request" +
                "posee información invalidad.");
        }

        /// <summary>
        /// Código de error del Sello mal formado.
        /// </summary>
        /// <returns></returns>
        public static TipoEstatus _302()
        {
            return new TipoEstatus("302", "Sello Mal Formado");
        }

        /// <summary>
        /// Código de error del sello que no corresponde al RFC Solicitante.
        /// </summary>
        /// <returns></returns>
        public static TipoEstatus _303()
        {
            return new TipoEstatus("303", "Sello no corresponde con RFCSolicitante");
        }

        /// <summary>
        /// Código de error del certificado revocado o caducado.
        /// </summary>
        /// <returns></returns>
        public static TipoEstatus _304()
        {
            return new TipoEstatus("304", "Certificado Revocado o Caduco.", "El certificado fue revocado" +
                " o bien la fecha de vigencia expiró");
        }

        /// <summary>
        /// Código de error por que el certificado puede estar invalidado, por multiples
        /// razones.
        /// </summary>
        /// <returns></returns>
        public static TipoEstatus _305()
        {
            return new TipoEstatus("305", "Certificado Inválido", "El certificado puede ser invalido por" +
                "múltiples razones como son el tipo codificación incorrecta etc.");
        }

        /// <summary>
        /// Código de Solicitud con éxito.
        /// </summary>
        /// <returns></returns>
        public static TipoEstatus _5000()
        {
            return new TipoEstatus("5000", "Solicitud recibida con éxito",
                "Indica que la solicitud de descarga que se" +
                    " esta verificando fue aceptada.");
        }

        /// <summary>
        /// Código de tercero no autorizado.
        /// </summary>
        /// <returns></returns>
        public static TipoEstatus _5001()
        {
            return new TipoEstatus("5001", "Tercero no autorizado");
        }

        /// <summary>
        /// Código de limite de solicitudes, se tiene un liminte máximo para las solicitudes
        /// en el SAT.
        /// </summary>
        /// <returns></returns>
        public static TipoEstatus _5002()
        {
            return new TipoEstatus("5002", "Se agotó las solicitudes de por vida.", "Para el caso de descarga de tipo CFDI" +
                    " se tiene un límite máximo para solicitudes con los mismos parametros(F.I, F.F, RFCEMISOR, RFCRECEPTOR");
        }

        /// <summary>
        /// Código que indica que esta superando el tipo máximo de CFDI o Metadata, por solicitud.
        /// </summary>
        /// <returns></returns>
        public static TipoEstatus _5003()
        {
            return new TipoEstatus("5003", "Tope máximo", "Indica que en base a los parametros de consulta se esta superando" +
                    " el tpo máximo de CFDI o Metadata por solicitud de descarga masiva.");
        }


        /// <summary>
        /// Código que indica la solicitud de descarga que se esta verificando no género paquetes.
        /// </summary>
        /// <returns></returns>
        public static TipoEstatus _5004()
        {
            return new TipoEstatus("5004", "No se encontro la información o la solicitud", "Indica que en base a los parametros de consulta se esta superando" +
                    " el tpo máximo de CFDI o Metadata por solicitud de descarga masiva.");
        }

        /// <summary>
        /// Código que tiene un límite máximo de solicitudes con los mismos parametros
        /// (Fecha inicial, Fecha Final, RFCEmisor, RFCReceptor).
        /// </summary>
        /// <returns></returns>
        public static TipoEstatus _5005()
        {
            return new TipoEstatus("5005", "Solicitud duplicada", "En caso de que exista una solicitud" +
                "vigente con los mismos parámetros (F.I F.F RFCEmisor, RfcReceptor, RFCSolicitante, TipoSolictud");
        }

        /// <summary>
        /// Código de paquete solicitado inaxistente.
        /// </summary>
        /// <returns></returns>
        public static TipoEstatus _5007()
        {
            return new TipoEstatus("5007", "No existe el paquete solicitado");
        }


        /// <summary>
        /// Código de máxima descargas permitidas.
        /// </summary>
        /// <returns></returns>
        public static TipoEstatus _5008()
        {
            return new TipoEstatus("5008", "Máximo de descargas permitidas");
        }

        /// <summary>
        /// Código de error no controlado.
        /// </summary>
        /// <returns></returns>
        public static TipoEstatus _404()
        {
            return new TipoEstatus("404", "Error no controlado", "Error generíco, en caso " +
                "de presentarse realizar nuevamente la petición y si el error persiste levantar un " +
                "RMA");
        }


        public String getClave()
        {
            return this.clave;
        }


        public String getDescripcion()
        {
            return this.descripcion;
        }

        public string getNombre()
        {
            return this.nombre;
        }


        public override string ToString()
        {
            return this.getClave() + " - " + this.getNombre() + " - " + this.getDescripcion();
        }



        public static TipoEstatus parseCodigoEstatus(String clave)
        {
            if (clave == null)
            {
                throw new IllegalArgumentException("clave == null");
            }

            TipoEstatus codigo;

            switch (clave)
            {
                case "5000":
                    codigo = TipoEstatus._5000();
                    break;
                case "5001":
                    codigo = TipoEstatus._5001();
                    break;
                case "5002":
                    codigo = TipoEstatus._5002();
                    break;
                case "5004":
                    codigo = TipoEstatus._5004();
                    break;
                case "5005":
                    codigo = TipoEstatus._5007();
                    break;
                case "5007":
                    codigo = TipoEstatus._5004();
                    break;
                case "5008":
                    codigo = TipoEstatus._5008();
                    break;
                case "300":
                    codigo = TipoEstatus._300();
                    break;
                case "301":
                    codigo = TipoEstatus._301();
                    break;
                case "302":
                    codigo = TipoEstatus._302();
                    break;
                case "303":
                    codigo = TipoEstatus._303();
                    break;
                case "304":
                    codigo = TipoEstatus._304();
                    break;
                case "305":
                    codigo = TipoEstatus._305();
                    break;
                case "404":
                    codigo = TipoEstatus._404();
                    break;
                case "todas":
                default:
                    codigo = TipoEstatus._5002();
                    break;
            }

            return codigo;
        }


        public static TipoEstatus parseCodigoEstatusSolicitud(String clave)
        {
            if (clave == null)
            {
                throw new IllegalArgumentException("clave == null");
            }

            TipoEstatus codigo;

            switch (clave)
            {
                case "5000":
                    codigo = TipoEstatus._5000();
                    break;
                case "5001":
                    codigo = TipoEstatus._5001();
                    break;
                case "5002":
                    codigo = TipoEstatus._5002();
                    break;
                case "5004":
                    codigo = TipoEstatus._5004();
                    break;
                case "todas":
                default:
                    codigo = null;
                    break;
            }

            return codigo;
        }

    }
}
