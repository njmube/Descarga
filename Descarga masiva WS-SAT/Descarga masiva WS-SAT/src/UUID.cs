using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Descarga_masiva_WS_SAT.src
{
    public class UUID
    {
        private string valor;

        public UUID(string valor)
        {
            this.valor = valor;
        }

        public string getValor()
        {
            return this.valor;
        }
    }
}
