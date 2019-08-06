using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Descarga_masiva_WS_SAT.src
{
    public enum EstadoSolicitud
    {
        Aceptada = 1,
        EnProceso = 2,
        Terminada = 3,
        Error = 4,
        Rechazada = 5,
        Vencidad = 6
    }

    public enum TipoSolicitud
    {
        CFDI,
        Metadata
    }

    public class Parametros
    {
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public RFC RFCEmisor { get; set; }
        public RFC RFCReceptor { get; set; }
        public RFC RFCSolicitane { get; set; }
        public string IDSolicitud { get; set; }
        public TipoSolicitud TipoSolicitud { get; set; }
        public Certificado certificado { get; set; }
        public string UUIDiRamdon { get; set; }
        public string IDPaquete { get; set; }
    }
}
