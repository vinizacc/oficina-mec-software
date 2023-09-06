using Braga;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Form = System.Windows.Forms.Form;

namespace Servico1
{
    public partial class FormClientes : Form
    {
        public FormClientes()
        {
            GlobalExceptionHandler.Attach(log);
            InitializeComponent();
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            btnAlterarCliente.Enabled = false;
            log.caminhoENome = caminhoENomeLog;
            log.registrar(log.barra + "O formulário Controle de clientes foi aberto." + log.barra);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }

            return base.ProcessDialogKey(keyData);
        }

        BindingSource clientesBindingSource = new BindingSource();

        private string nomeAtual;
        private string docAtual;
        private string idAtual;
        public string getNomeAtual() { return nomeAtual; }
        public string getDocAtual() { return docAtual; }

        Log log = new Log();
        public string caminhoENomeLog;
        private void btnProcurarCliente_Click(object sender, EventArgs e)
        {
            log.registrar("Botão PROCURAR clicado.");
            btnAlterarCliente.Enabled = true;
            ClientesDAO clientesDAO = new ClientesDAO();

            if (txtProcuraNome.Text != "")
            {
                if (Regex.IsMatch(txtProcuraNome.Text, @"^[a-zA-Z\s]+$"))
                {
                    log.registrar("Procura por nome: "+ txtProcuraNome.Text);
                    clientesBindingSource.DataSource = clientesDAO.procurarClientePeloNomeRetornLista(txtProcuraNome.Text);
                    dataGridViewCLientes.DataSource = clientesBindingSource;
                    configuraColunas();
                }
                else
                {
                    log.registrar("Procura por nome incorreta: ." + txtProcuraNome.Text);
                    MessageBox.Show("Só pode letras ao procurar por NOME.", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                }
            }
            else if (txtBoxProcuraDoc.Text != "")
            {
                txtProcuraNome.Text = "";
                if (Regex.IsMatch(txtBoxProcuraDoc.Text, @"^[0-9]+$"))
                {
                    log.registrar("Procura por documento: " + txtBoxProcuraDoc.Text);
                    clientesBindingSource.DataSource = clientesDAO.procurarClientePeloDocRetornaLista(txtBoxProcuraDoc.Text);
                    dataGridViewCLientes.DataSource = clientesBindingSource;
                    configuraColunas();
                }
                else
                {
                    log.registrar("Procura por documento incorreta: "+ txtBoxProcuraDoc.Text);
                    MessageBox.Show("Só pode números ao procurar por DOCUMENTO.", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                }
            }

        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            ClientesDAO clientesDAO = new ClientesDAO();
            clientesBindingSource.DataSource = clientesDAO.getAllClientes();
            dataGridViewCLientes.DataSource = clientesBindingSource;
            log.registrar("Botão TODOS clicado.");
            configuraColunas();
            btnAlterarCliente.Enabled = true;

        }

        //private void btnCadastrarCliente_Click(object sender, EventArgs e)
        //{
        //    ClientesDAO clientesDAO = new ClientesDAO();

        //    if (validarCamposCadastro())
        //    {
        //        clientesDAO.insertCliente(txtNome.Text, txtEndereco.Text, txtTel.Text, clientesDAO.dataHoje(), txtDoc.Text, rTxtBoxDescricao.Text, 0);
        //    }
        //}

        private void btnAlterarCliente_Click(object sender, EventArgs e)
        {
            log.registrar("Botão ALTERAR clicado.");
            ClientesDAO clientesDAO = new ClientesDAO();

            bool estaAberto = jaEstaAberto(typeof(FormAlteraCliente));
            if (estaAberto == false)
            {
                string id = "";
                string nome = "";
                string end = "";
                string tel = "";
                string doc = "";
                string desc = "";

                DataGridViewSelectedRowCollection colecaoLinhas = dataGridViewCLientes.SelectedRows;

                foreach (DataGridViewRow linha in colecaoLinhas)
                {
                    id = linha.Cells[0].Value.ToString();
                    nome = linha.Cells[1].Value.ToString(); // 01245 12356
                    end = linha.Cells[2].Value.ToString();
                    tel = linha.Cells[3].Value.ToString();
                    doc = linha.Cells[5].Value.ToString();
                    desc = linha.Cells[6].Value.ToString();
                }

                List<string> campos = new List<string>();
                log.registrar("Será alterado infos do perfil: - NOME: " + nome + " | - DOC: " + doc);
                campos.Add(id);
                campos.Add(nome);
                campos.Add(end);
                campos.Add(tel);
                campos.Add(doc);
                campos.Add(desc);

                FormAlteraCliente formAltera = new FormAlteraCliente();

                formAltera.setNomeInicial(nomeAtual);
                formAltera.setDocInicial(docAtual);

                formAltera.setCampos(campos);
                formAltera.caminhoENomeLog = caminhoENomeLog;
                formAltera.ShowDialog(this);
                btnAlterarCliente.Enabled = false;
            }

        }
        //public bool validarCamposCadastro()
        //{
        //    bool validar = true;

        //    if(txtNome.Text != "" && txtEndereco.Text != "" && txtDoc.Text != "" && txtTel.Text != "")
        //    {
        //        if(txtNome.Text.Length > 45) { lblWarning.Text = "O campo nome deve ter menos de 45 letras"; validar = false; }
        //        else if(txtEndereco.Text.Length > 100) { lblWarning.Text = "O campo endereço deve ter menos de 100 letras"; validar = false; }
        //        else if(txtTel.Text.Length > 15) { lblWarning.Text = "O campo telefone deve ter menos de 15 letras"; validar = false; }
        //        else if(txtDoc.Text.Length > 15) { lblWarning.Text = "O campo documento deve ter menos de 15 letras"; validar = false; }
        //    }
        //    else
        //    {
        //        lblWarning.Text = "Os campos devem ser preenchidos. (Menos no campo descrição)";
        //        validar = false;
        //    }

        //    return validar;
        //}


        private void dateTimePicker2_MouseDown(object sender, MouseEventArgs e)
        {
            log.registrar("Botão SElEÇÃO POR DATA clicado.");
            bool estaAberto = jaEstaAberto(typeof(FormData));
            if (estaAberto == false)
            {

                FormData formData = new FormData();
                log.registrar("Abrindo formulário de seleção de datas.");
                formData.caminhoENomeLog = caminhoENomeLog;
                formData.ShowDialog(this);

                List<DateTime> listaDatas = new List<DateTime>
                {
                    formData.dataInicial,
                    formData.dataFinal
                };

                ClientesDAO clientesDAO = new ClientesDAO();
                clientesBindingSource.DataSource = clientesDAO.procurarClientePorDataRetornaLista(listaDatas);
                
                dataGridViewCLientes.DataSource = clientesBindingSource;
                configuraColunas();
            }
        }

        private bool jaEstaAberto(Type formType)
        {
            bool isOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == formType)
                {
                    f.BringToFront();

                    f.WindowState = FormWindowState.Normal;

                    isOpen = true;
                }
            }
            return isOpen;
        }

        private void txtProcuraNome_Enter(object sender, EventArgs e)
        {
            if (txtBoxProcuraDoc.Text != "") txtBoxProcuraDoc.Text = "";
        }

        private void txtBoxProcuraDoc_Enter(object sender, EventArgs e)
        {
            if (txtProcuraNome.Text != "") txtProcuraNome.Text = "";
        }

        private void dataGridViewCLientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                e.Value = e.Value.ToString().Substring(0, 10);
                e.FormattingApplied = true;
            }
        }

        public void configuraColunas()
        {
            dataGridViewCLientes.Columns["ID_PF"].Visible = false;
            dataGridViewCLientes.Columns["NOME"].HeaderText = "Nome";
            dataGridViewCLientes.Columns["ENDERECO"].HeaderText = "Endereço";
            dataGridViewCLientes.Columns["CELULAR"].HeaderText = "Telefone";
            dataGridViewCLientes.Columns["DT_CADASTRO"].HeaderText = "Data de cadastro";
            dataGridViewCLientes.Columns["DOC_PESSOAL"].HeaderText = "Documento";
            dataGridViewCLientes.Columns.Remove("DESCRICAO");
            dataGridViewCLientes.Columns["N_NF"].HeaderText = "Notas fiscais";
            //dataGridViewCLientes.Columns.Remove("N_NF");
        }

        private void dataGridViewCLientes_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            string nome = "";
            string doc = "";
            string id = "";

            foreach (DataGridViewRow row in dataGridViewCLientes.SelectedRows)
            {
                if(row.Cells[0].Value != null)
                {
                    id = row.Cells[0].Value.ToString();
                    nome = row.Cells[1].Value.ToString();
                    doc = row.Cells[5].Value.ToString();
                }
            }
            nomeAtual = nome;
            docAtual = doc;
            idAtual = id;
            if(nomeAtual != "")
            {
                log.registrar("Selecionou o cliente: "+ nomeAtual);
            }
        }

        private void btnExcluirCliente_Click(object sender, EventArgs e)
        {
            log.registrar("Botão EXCLUIR foi clicado.");
            DialogResult dialogResult = MessageBox.Show("Deseja deletar esse cliente?", "Deletar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            log.registrar("Cliente para exclusão: " + nomeAtual);
            if (dialogResult == DialogResult.Yes)
            {
                ClientesDAO clientesDAO = new ClientesDAO();
                if (clientesDAO.deleteCliente(idAtual))
                {
                    log.registrar("Deletou o cliente.");
                    MessageBox.Show("DELETE SUCESSO");
                    clientesBindingSource.DataSource = clientesDAO.getAllClientes();
                    dataGridViewCLientes.DataSource = clientesBindingSource;
                    configuraColunas();
                }
            }
            else
            {
                log.registrar("Cancelou a exclusão do cliente.");
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void FormClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            log.registrar(log.barra);
        }
    }
}
