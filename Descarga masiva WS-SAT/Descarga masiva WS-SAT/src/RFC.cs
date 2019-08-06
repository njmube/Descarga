using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Descarga_masiva_WS_SAT.src
{
    public class RFC
    {
        private string _valor;


        public RFC(string valor)
        {
            _valor = valor;
        }



        public string getValor()
        {
            return _valor;
        }
    }
}
