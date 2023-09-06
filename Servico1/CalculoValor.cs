using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Braga
{
    internal class CalculoValor
    {
        public string calcularpontoflutuante(string valor)
        {
            string r = Convert.ToSingle(valor).ToString("C");
            return r;
        }
    }
}
