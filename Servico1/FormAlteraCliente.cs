using Braga;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Servico1
{
    public partial class FormAlteraCliente : Form
    {
        public FormAlteraCliente()
        {
            GlobalExceptionHandler.Attach(log);
            InitializeComponent();
        }
        private void FormAlteraCliente_Load(object sender, EventArgs e)
        {
            log.caminhoENome = caminhoENomeLog;
            log.registrar(log.barra + "O formulário Altera cliente foi aberto" + log.barra);
        }
        Log log = new Log();
        public string caminhoENomeLog;
        private string nomeInicial;
        public void setNomeInicial(string nome) { this.nomeInicial = nome; }

        private string docInicial;
        public void setDocInicial(string doc) { this.docInicial = doc; }

        private string id;
        public void setId(string id) { this.id = id; }
        private void setTxtNome(string nomeAtual) { txtNome.Text = nomeAtual; }
        private void setTxtEnd(string end) { txtEndereco.Text = end; }
        private void setTxtTel(string tel) { txtTel.Text = tel; }
        private void setTxtDoc(string doc) { txtDoc.Text = doc; }
        private void setTxtDesc(string desc) { rTxtBoxDescricao.Text = desc; }

        public bool setCampos(List<string> campos)
        {
            setId(campos[0]);
            setTxtNome(campos[1]);
            setTxtEnd(campos[2]);
            setTxtTel(campos[3]);
            setTxtDoc(campos[4]);
            setTxtDesc(campos[5]);

            return true;
        }
        private void FormAlteraCliente_TextChanged(object sender, EventArgs e)
        {
        }

        private void labelAlterar_Click(object sender, EventArgs e)
        {
            log.registrar("Botão ALTERAR clicado.");
            ClientesDAO clienteDAO = new ClientesDAO();

            if (clienteDAO.validarCamposCadastro(txtNome.Text, txtDoc.Text))
            {
                log.registrar("Perfil - Nome: " + txtNome.Text + " | Documento: "+ txtDoc.Text);
                string validar = clienteDAO.updateCliente(id, nomeInicial, docInicial, txtNome.Text, txtEndereco.Text, txtTel.Text, txtDoc.Text, rTxtBoxDescricao.Text);
                if (validar == "Atualização falhou")
                {
                    log.registrar("Atualização falho.");
                    MessageBox.Show(validar);
                }
                else
                {
                    log.registrar("Perfil atualizado.");
                    MessageBox.Show(validar);
                }
            }
        }

        private void FormAlteraCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            log.registrar(log.barra);
        }
    }
}
