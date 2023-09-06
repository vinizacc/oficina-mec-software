using System;
using System.Data;

namespace Servico1
{
    internal class Servicos
    {
        public int ID_N_SERVICO { get; set; }
        public String DATA { get; set; }
        public float VALOR_TOTAL { get; set; }
        public float VALOR_PAGO { get; set; }
        public int TIPO_PAG { get; set; }
        public int PAGO { get; set; }
        public string NOME_ARQ { get; set; }
        public DataTable LISTA_DADOS { get; set; }
        public int NUM_NOTA { get; set; }
        public int ID_CLIENTE { get; set; }

    }
}
