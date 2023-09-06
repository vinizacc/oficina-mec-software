using Braga;
using System;
using System.Windows.Forms;

namespace Servico1
{
    public partial class FormCadastroCliente : Form
    {
        public FormCadastroCliente()
        {
            GlobalExceptionHandler.Attach(log);
            InitializeComponent();
        }
        private void FormCadastroCliente_Load(object sender, EventArgs e)
        {
            log.caminhoENome = caminhoENomeLog;
            log.registrar(log.barra + "O formulário Cadastro de clientes foi aberto." + log.barra);
        }

        Log log = new Log();
        public string caminhoENomeLog;

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }

            return base.ProcessDialogKey(keyData);
        }

        private void labelCadastrar_Click(object sender, EventArgs e)
        {
            log.registrar("Botão CADASTRAR clicado.");
            ClientesDAO clientesDAO = new ClientesDAO();

            if (clientesDAO.validarCamposCadastro(txtNome.Text, txtDoc.Text))
            {
                bool cadastrado = false;

                cadastrado = clientesDAO.insertCliente(txtNome.Text, txtEndereco.Text, txtTel.Text, clientesDAO.dataHoje(), txtDoc.Text, rTxtBoxDescricao.Text, 0);

                if (cadastrado)
                {
                    MessageBox.Show("Cadastro feito com sucesso", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    log.registrar("Cadastrado.\r\nUsuário: "+txtNome.Text);
                    txtTel.Text = "";
                    txtEndereco.Text = "";
                    txtNome.Text = "";
                    rTxtBoxDescricao.Text = "";
                    txtDoc.Text = "";
                    txtNome.Focus();
                }
                else
                {
                    log.registrar("Cadastro inválido.");
                }
            }
            else
            {
                log.registrar("Campos Nome e Documento invalidados.");
            }
        }

        private void txtNome_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtEndereco_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtTel_Leave(object sender, EventArgs e)
        {
            
        }

        private void rTxtBoxDescricao_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtDoc_Leave(object sender, EventArgs e)
        {
            
        }

        private void FormCadastroCliente_Leave(object sender, EventArgs e)
        {
            
        }

        private void FormCadastroCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            log.registrar(log.barra);
        }
    }
}
