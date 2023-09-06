namespace Servico1
{
    internal class Items
    {
        private Servicos s { get; set; }

        private Clientes c { get; set; }
        public Items(int cIdPF, string cNome, string cCel, string cDtCadastro, string cDoc, string cDesc, string cEnd, int cNF, int sIdNServ, int sTipoPag, float sValorPago, float sValorTotal, string sData, int sIdCliente)
        {
            c.ID_PF = cIdPF;
            c.NOME = cNome;
            c.ENDERECO = cEnd;
            c.CELULAR = cCel;
            c.DT_CADASTRO = cDtCadastro;
            c.DOC_PESSOAL = cDoc;
            c.DESCRICAO = cDesc;
            c.N_NF = cNF;
            s.ID_N_SERVICO = sIdNServ;
            s.TIPO_PAG = sTipoPag;
            s.VALOR_PAGO = sValorPago;
            s.VALOR_TOTAL = sValorTotal;
            s.DATA = sData;
            s.ID_CLIENTE = sIdCliente;
        }

        public Items() { }
    }
}
