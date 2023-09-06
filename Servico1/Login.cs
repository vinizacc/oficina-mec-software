using Braga;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Servico1
{
    public partial class Login : Form
    {

        public Login()
        {
            GlobalExceptionHandler.Attach(log);
            InitializeComponent();
        }

        Log log = new Log();
        int privilegio = 0;

        
        private void Login_Load(object sender, EventArgs e)
        {
            
            log.iniciaArquivoLog();
            log.registrar("O PROGRAMA FOI ABERTO");
            log.registrar("NOME DO ARQUIVO: " + log.nome);

            string data = DateTime.Now.Day.ToString();
            data += DateTime.Now.Month.ToString();
            data += DateTime.Now.Year.ToString();

            pBoxAberto.Enabled = false;
            pBoxAberto.Visible = false;
            pBoxFechado.Enabled = true;
            pBoxFechado.Visible = true;
            button1.Enabled = false;
        }

        private void txtUsuario_MouseDown(object sender, MouseEventArgs e)
        {
            label4.Text = "";
        }

        public class validacao
        {
            public bool validarLogin { get; set; }

            public Usuarios usuario { get; set; }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            log.registrar("O botão login foi clicado.");
            UsuariosDAO usuariosDAO = new UsuariosDAO();
            validacao v = new validacao();
            
            v = usuariosDAO.validarLogin(txtUsuario.Text, txtSenha.Text);

            if (v.validarLogin)
            {
                
                this.Hide();
                var servico = new Servico();
                servico.usuario = v.usuario;
                privilegio = v.usuario.PRIVILEGIO;
                
                log.registrar("O login foi validado.");
                log.registrar("LOGIN: " + txtUsuario.Text + "|| SENHA: " + txtSenha.Text);

                if (log.caminhoENome != "")
                {
                    servico.caminhoENomeLog = log.caminhoENome;
                }

                servico.Closed += (s, args) => this.Close();
                servico.Show();
            }
            else
            {
                label4.Text = "Usuário ou senha inválidos.";
                log.registrar("O login foi invalidado.");
                log.registrar("TENTATIVA DE LOGIN.");
                log.registrar("LOGIN: " + txtUsuario.Text + "|| SENHA: " + txtSenha.Text);
            }

            if (txtSenha.Text == "" || txtUsuario.Text == "")
            {
                log.registrar("Campo login ou senha estão vazios.");
                label4.Text = "Usuário ou senha inválidos.";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Login_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
            {
                btnRegistrar_Click(sender, e);
            }
        }

        private void txtSenha_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRegistrar_Click(sender, e);
            }
        }

        private void txtConf_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void pBoxAberto_Click(object sender, EventArgs e)
        {
            log.registrar("O botão \'ver senha\' foi clicado");
            pBoxAberto.Enabled = false;
            pBoxAberto.Visible = false;
            pBoxFechado.Enabled = true;
            pBoxFechado.Visible = true;
            txtSenha.PasswordChar = '*';
        }

        private void pBoxFechado_Click(object sender, EventArgs e)
        {
            log.registrar("O botão \'não ver senha\' foi clicado");
            pBoxAberto.Enabled = true;
            pBoxAberto.Visible = true;
            pBoxFechado.Enabled = false;
            pBoxFechado.Visible = false;
            txtSenha.PasswordChar = '\0';

        }

        private void button1_Click(object sender, EventArgs e)
        {
            log.registrar("Botão REGISTRAR foi clicado.");
            var registro = new Registro();
            registro.log = log;
            registro.privilegioAtual = privilegio;
            registro.Show();
        }

        private void txtSenha_MouseDown(object sender, MouseEventArgs e)
        {
            label4.Text = "";
        }

    }
}
