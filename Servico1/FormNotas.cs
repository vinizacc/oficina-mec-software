using Braga;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Form = System.Windows.Forms.Form;

namespace Servico1
{
    public partial class FormNotas : Form
    {
        public FormNotas()
        {
            GlobalExceptionHandler.Attach(log);
            InitializeComponent();
        }

        private void FormNotas_Load(object sender, EventArgs e)
        {
            checkBoxDeletado.Enabled = false;
            checkBoxAtivo.Checked = true;
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
        BindingSource notasBindingSource = new BindingSource();

        private string nomeAtual;
        private string docAtual;
        private string idAtual;
        List<JObject> notasAtualAtivos;
        List<JObject> notasAtualDeletados;

        private string idNotaParaDeletar;
        public string getNomeAtual() { return nomeAtual; }
        public string getDocAtual() { return docAtual; }

        Log log = new Log();
        public string caminhoENomeLog;

        private void btnProcurarCliente_Click(object sender, EventArgs e)
        {
            log.registrar("Botão PROCURAR clicado.");
            ClientesDAO clientesDAO = new ClientesDAO();
            notasAtualAtivos = null;
            notasAtualDeletados = null;

            //NOME
            if(Regex.IsMatch(txtProcuraNome.Text, @"^[a-zA-Z\s]+$") && txtProcuraNome.Text != null)
            {
                log.registrar("Procura por nome: " + txtProcuraNome.Text);
                clientesBindingSource.DataSource = clientesDAO.procurarClientePeloNomeRetornLista(txtProcuraNome.Text);
                dataGridViewBusca.DataSource = clientesBindingSource;
                configuraColunas();
            }
            //DOC
            if (Regex.IsMatch(txtBoxProcuraDoc.Text, @"^[0-9]+$") && txtBoxProcuraDoc.Text != null)
            {
                log.registrar("Procura por documento: " + txtBoxProcuraDoc.Text);
                clientesBindingSource.DataSource = clientesDAO.procurarClientePeloDocRetornaLista(txtBoxProcuraDoc.Text);
                dataGridViewBusca.DataSource = clientesBindingSource;
                configuraColunas();
            }
            //TEL
            if (Regex.IsMatch(txtBoxTel.Text, @"^[0-9]+$") && txtBoxTel.Text != null)
            {
                log.registrar("Procura por tel: " + txtBoxTel.Text);
                clientesBindingSource.DataSource = clientesDAO.procurarClientePeloTelRetornaLista(txtBoxTel.Text);
                dataGridViewBusca.DataSource = clientesBindingSource;
                configuraColunas();
            }


        }

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

                DataGridViewSelectedRowCollection colecaoLinhas = dataGridViewBusca.SelectedRows;

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
        }

        private void txtBoxProcuraDoc_Enter(object sender, EventArgs e)
        {
        }

        private void dataGridViewCLientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                e.Value = e.Value.ToString().Substring(0, 10);
                e.FormattingApplied = true;

            }
        }

        public void configuraColAltera()    
        {
            dataGridViewAltera.Columns["NOME"].HeaderText = "Nome";
            dataGridViewAltera.Columns["VALOR_PAGO"].HeaderText = "Valor pago";
            dataGridViewAltera.Columns["VALOR_TOTAL"].HeaderText = "Valor total";
            dataGridViewAltera.Columns["NUM_NOTA"].HeaderText = "Nota";
            dataGridViewAltera.Columns["DATA"].HeaderText = "Data";
            dataGridViewAltera.Columns["ID_N_SERVICO"].Visible = false;
        }
        public void configuraColunas()
        {
            dataGridViewBusca.Columns["ID_PF"].Visible = false;
            dataGridViewBusca.Columns["NOME"].HeaderText = "Nome";
            dataGridViewBusca.Columns["ENDERECO"].HeaderText = "Endereço";
            dataGridViewBusca.Columns["CELULAR"].HeaderText = "Telefone";
            dataGridViewBusca.Columns["DT_CADASTRO"].HeaderText = "Dt cadastro";
            dataGridViewBusca.Columns["DOC_PESSOAL"].HeaderText = "Documento";
            dataGridViewBusca.Columns.Remove("DESCRICAO");
            dataGridViewBusca.Columns["N_NF"].HeaderText = "Num notas";
            //dataGridViewCLientes.Columns.Remove("N_NF");
        }

        private void dataGridViewCLientes_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewBusca.SelectedRows)
            {
                if (row.Cells[0].Value != null)
                {
                    idAtual = row.Cells[0].Value.ToString();
                }
            }
        }
        private void FormNotas_FormClosing(object sender, FormClosingEventArgs e)
        {
            log.registrar(log.barra);
        }
        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            if (idNotaParaDeletar != "" && (checkBoxDeletado.Checked && !checkBoxAtivo.Checked))
            {
                DialogResult dR = MessageBox.Show("Deseja deletar a nota (serviço)?\nEssa operação não é definitiva.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dR == DialogResult.Yes)
                {
                    ServicosDAO sDAO = new ServicosDAO();
                    try
                    {
                        MessageBox.Show("Nota: " + idNotaParaDeletar + "\nCliente: " + idAtual);
                        sDAO.reativarNota(idNotaParaDeletar);
                        dataGridViewAltera.Rows.RemoveAt(dataGridViewAltera.CurrentRow.Index);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Não foi possível recuperar a nota.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        idNotaParaDeletar = "";
                    }
                }
            }
        }
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if(idNotaParaDeletar != null && (!checkBoxDeletado.Checked && checkBoxAtivo.Checked))
            {
                DialogResult dR = MessageBox.Show("Deseja deletar a nota (serviço)?\nEssa operação não é definitiva.", "",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                if(dR == DialogResult.Yes)
                {
                    ServicosDAO sD = new ServicosDAO();
                    try
                    {
                        MessageBox.Show("Nota: "+idNotaParaDeletar +"\nCliente: " + idAtual);
                        sD.ocultaNota(Convert.ToInt32(idNotaParaDeletar));
                        dataGridViewAltera.Rows.RemoveAt(dataGridViewAltera.CurrentRow.Index);
                    
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Não foi possível deletar a nota.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        idNotaParaDeletar = "";
                    }
                }
            }
        }

        private void dataGridViewBusca_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {   
            foreach (DataGridViewRow row in dataGridViewBusca.SelectedRows)
            {
                if (row.Cells[0].Value != null)
                {
                    idAtual = row.Cells[0].Value.ToString();
                }
            }

            ServicosDAO s = new ServicosDAO();
            checkBoxDeletado.Enabled = true;
            notasAtualDeletados = s.getServicosByIdNaoAtivos(Convert.ToInt32(idAtual));
            notasAtualAtivos = s.getServicosByIdAtivos(Convert.ToInt32(idAtual));
                
            if (notasAtualAtivos.Count != 0 && (checkBoxAtivo.Checked && !checkBoxDeletado.Checked))
            {
                notasBindingSource.DataSource = notasAtualAtivos;
                dataGridViewAltera.DataSource = notasBindingSource;
                configuraColAltera();
            }
            else if (notasAtualDeletados.Count != 0 && (checkBoxDeletado.Checked && !checkBoxAtivo.Checked))
            {
                notasBindingSource.DataSource = notasAtualDeletados;
                dataGridViewAltera.DataSource = notasBindingSource;
                configuraColAltera();
            }
            else
            {
                MessageBox.Show("Não tem notas para apagar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
        private void dataGridViewAltera_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewAltera.SelectedRows)
            {
                if (row.Cells[0].Value != null)
                {
                    idNotaParaDeletar = row.Cells[5].Value.ToString();
                    MessageBox.Show("Selection Changed id: " +idNotaParaDeletar);
                }
            }
        }

        private void dataGridViewBusca_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewBusca.SelectedRows)
            {
                if (row.Cells[0].Value != null)
                {
                    idAtual = row.Cells[0].Value.ToString();
                }
            }
        }

        private void checkBoxAtivo_Click(object sender, EventArgs e)
        {
            string name = (sender as Control)?.Name;
            if (name == "checkBoxAtivo")
            {
                if (checkBoxAtivo.Checked && notasAtualAtivos.Count != 0)
                {
                    ServicosDAO sDAO = new ServicosDAO();
                    checkBoxAtivo.Checked = true;
                    notasAtualAtivos = sDAO.getServicosByIdAtivos(Convert.ToInt32(idAtual));

                    notasBindingSource.DataSource = notasAtualAtivos;
                    dataGridViewAltera.DataSource = notasBindingSource;
                    configuraColAltera();
                }
                else
                {
                    MessageBox.Show("Não tem notas para apagar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (checkBoxDeletado.Checked)
                {
                    checkBoxDeletado.Checked = false;
                }
            }
            if (name == "checkBoxDeletado")
            {
                if (checkBoxDeletado.Checked && notasAtualDeletados.Count != 0)
                {
                    ServicosDAO sDAO = new ServicosDAO();
                    checkBoxDeletado.Checked = true;
                    notasAtualDeletados = sDAO.getServicosByIdNaoAtivos(Convert.ToInt32(idAtual));

                    notasBindingSource.DataSource = notasAtualDeletados;
                    dataGridViewAltera.DataSource = notasBindingSource;
                    configuraColAltera();
                }
                else
                {
                    MessageBox.Show("Não tem notas para recuperar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (checkBoxDeletado.Checked)
                {
                    checkBoxAtivo.Checked = false;
                }
            }
        }

        private void checkBoxAtivo_CheckedChanged(object sender, EventArgs e)
        {

        }

        
    }
}
