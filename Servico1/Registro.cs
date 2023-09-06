using Braga;
using System;
using System.Windows.Forms;
using static Syncfusion.Windows.Forms.ThemedComboBoxDrawing;

namespace Servico1
{
    public partial class Registro : Form
    {
        public Registro()
        {
            GlobalExceptionHandler.Attach(log);
            InitializeComponent();
        }
        public int privilegioAtual { get; set; }
        public Log log = new Log();
        public string caminhoENomeLog;

        private void Registro_Load(object sender, EventArgs e)
        {
            pBoxAberto.Enabled = false;
            pBoxAberto.Visible = false;
            pBoxFechado.Enabled = true;
            pBoxFechado.Visible = true;
            cBoxConta.DropDownStyle = ComboBoxStyle.DropDownList;
            cBoxConta.Items.Add("comum");
            cBoxConta.Items.Add("administrador");
            cBoxConta.SelectedIndex = 0;
            //lblPriv.Text = privilegioAtual.ToString();
            log.caminhoENome = caminhoENomeLog;
            log.registrar(log.barra+"O formulário Registro foi aberto."+log.barra);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            lblWarning.Text = "";

            if (txtUsuario.Text != "" && txtSenha.Text != "" && txtConf.Text != "")
            {
                if (txtSenha.Text == txtConf.Text)
                {
                    if (txtSenha.Text.Length <= 16)
                    {
                        UsuariosDAO usuariosDAO = new UsuariosDAO();

                        if (usuariosDAO.validarRegistro(txtUsuario.Text))
                        {
                            DialogResult dialog = MessageBox.Show("Tem certeza que deseja cadastrar a conta: " + txtUsuario.Text, "Registro", MessageBoxButtons.OKCancel);
                            if (dialog == DialogResult.OK)
                            {

                                bool podeRegistrar = false;
                                
                                if (cBoxConta.SelectedIndex == 1 && privilegioAtual == 1) { podeRegistrar = true; }
                                if (cBoxConta.SelectedIndex == 0 && privilegioAtual == 1) { podeRegistrar = true; }
                                if (cBoxConta.SelectedIndex == 1 && privilegioAtual == 0) { podeRegistrar = false; }
                                if (cBoxConta.SelectedIndex == 0 && privilegioAtual == 0) { podeRegistrar = true; }


                                if (podeRegistrar)
                                {
                                    usuariosDAO.insertRegistro(txtUsuario.Text, txtSenha.Text, cBoxConta.SelectedIndex);

                                    log.registrar("Conta cadastrada: " + "\r\n" + "- Usuário novo: " + txtUsuario.Text + "\r\n" + "- Senha: " + txtSenha.Text + "\r\n" + "- Privilégio: " + privilegioAtual.ToString() + "\r\n");
                                    MessageBox.Show("Conta cadastrada.", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                else
                                {
                                    log.registrar("Registrar: a conta não tem privilégio para criar conta adm.");
                                    MessageBox.Show("A conta atual não tem privilégio para criar uma administrativa", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                        else
                        {
                            log.registrar("Registrar: já existe o usuário: "+ txtUsuario.Text + ".");
                            MessageBox.Show("Já existe esse usuário!", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        log.registrar("Registrar: a senha excede a 16 caracteres: "+ txtSenha.Text);
                        MessageBox.Show("A senha deve ter no máximo 16 caracteres.", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    log.registrar("Registrar: as senhas não batem.");
                    MessageBox.Show("A senha e a confirmação de devem ser iguais.", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                log.registrar("Registrar: nenhum campo foi preenchido.");
                MessageBox.Show("Os campos devem ser preenchidos.", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        

        private void pBoxFechado_Click(object sender, EventArgs e)
        {
            
            pBoxAberto.Enabled = true;
            pBoxAberto.Visible = true;
            pBoxFechado.Enabled = false;
            pBoxFechado.Visible = false;
            txtSenha.PasswordChar = '\0';
            txtConf.PasswordChar = '\0';
        }

        private void pBoxAberto_Click(object sender, EventArgs e)
        {
            pBoxAberto.Enabled = false;
            pBoxAberto.Visible = false;
            pBoxFechado.Enabled = true;
            pBoxFechado.Visible = true;
            txtSenha.PasswordChar = '*';
            txtConf.PasswordChar = '*';
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsuario_Click(object sender, EventArgs e)
        {
            lblWarning.Text = "";
        }

        private void Registro_FormClosing(object sender, FormClosingEventArgs e)
        {
            log.registrar(log.barra);
        }



        //public void eventosMouseEntreSai(Control control)
        //{
        //    if (control is Label || control is PictureBox)
        //    {
        //        control.MouseEnter += new System.EventHandler(lbl_MouseEnter);
        //        control.MouseLeave += new System.EventHandler(lbl_MouseLeave);

        //    }
        //    else
        //    {
        //        foreach (Control ctrl in control.Controls)
        //        {
        //            eventosMouseEntreSai(ctrl);
        //        }
        //    }
        //}
    }
}
