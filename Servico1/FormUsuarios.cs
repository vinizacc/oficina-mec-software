using Microsoft.Extensions.Logging;
using System;
using System.Windows.Forms;

namespace Servico1
{
    public partial class FormUsuarios : Form
    {
        public FormUsuarios()
        {
            InitializeComponent();
        }

        Log log = new Log();
        public string caminhoENomeLog;
        
        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            log.caminhoENome = caminhoENomeLog;
            log.registrar(log.barra + "O formulário Usuários foi aberto." + log.barra);
            gBoxAlterar.Enabled = false;
            //btnNovo.Enabled = false;
            //btnNovo.Visible = false;
            //btnTodos.Enabled = false;
            //btnTodos.Visible = false;

            UsuariosDAO usuariosDAO = new UsuariosDAO();

            //conectar a lista com o gridview

            usuarioBindingSource.DataSource = usuariosDAO.getAllUsuarios();
            dataGridViewUsuarios.DataSource = usuarioBindingSource;
            dataGridViewUsuarios.Columns.Remove("ID");
            dataGridViewUsuarios.Columns.Remove("SENHA");
            dataGridViewUsuarios.Columns.Remove("PRIVILEGIO");
        }

        BindingSource usuarioBindingSource = new BindingSource();
        public string searchUsuarioAntigo;
        public int privilegioAtual { get; set; }

        private void btnProcura_Click(object sender, EventArgs e)
        {
            log.registrar("Clicou no botão procurar.");
            if (txtProcura.Text != "")
            {
                UsuariosDAO usuariosDAO = new UsuariosDAO();
                //conectar a lista com o gridview

                usuarioBindingSource.DataSource = usuariosDAO.procurarUsuarios(txtProcura.Text);

                dataGridViewUsuarios.DataSource = usuarioBindingSource;
                dataGridViewUsuarios.Columns.Remove("ID");
                dataGridViewUsuarios.Columns.Remove("SENHA");
                dataGridViewUsuarios.Columns.Remove("PRIVILEGIO");
                log.registrar("Procurou e achou o usuário: " + txtProcura.Text);
            }
            else
            {
                log.registrar("O campo usuários estava vazio.");
            }
        }

        string usuarioParaDeletar = "";
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            log.registrar("Clicou no botão excluir usuário.");
            UsuariosDAO usuariosDAO = new UsuariosDAO();
            gBoxAlterar.Enabled = false;

            DialogResult dialog = MessageBox.Show("Tem ceretza que deseja deletar esse usuário?", "Deletar usuário", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (dialog == DialogResult.OK && usuarioParaDeletar != "")
            {
                bool podeDeletar = false;
                int tipoPrivilegioDaContaPraAlterar = usuariosDAO.procurarPrivilegioDoUsuario(usuarioParaDeletar);
                if (tipoPrivilegioDaContaPraAlterar == 1 && privilegioAtual == 1) { podeDeletar = true; }
                if (tipoPrivilegioDaContaPraAlterar == 0 && privilegioAtual == 1) { podeDeletar = true; }
                if (tipoPrivilegioDaContaPraAlterar == 1 && privilegioAtual == 0) { podeDeletar = false; }
                if (tipoPrivilegioDaContaPraAlterar == 0 && privilegioAtual == 0) { podeDeletar = true; }

                if (podeDeletar)
                {
                    usuariosDAO.deletarUsuarios(usuarioParaDeletar);
                    log.registrar("Deletou o usuário: "+ usuarioParaDeletar);
                    MessageBox.Show("Usuário deletado", "Deletado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    log.registrar("Tentou excluir o usuário: " + usuarioParaDeletar + " mas não teve privilégio.");
                    MessageBox.Show("Você não tem acesso na alteração desta conta.", "Erro ao deletar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
            usuarioBindingSource.DataSource = usuariosDAO.getAllUsuarios();
            dataGridViewUsuarios.DataSource = usuarioBindingSource;
            dataGridViewUsuarios.Columns.Remove("ID");
            dataGridViewUsuarios.Columns.Remove("SENHA");
            dataGridViewUsuarios.Columns.Remove("PRIVILEGIO");
            log.registrar("Foi carregado todos os usuários do GridView.");
        }

        private void dataGridViewUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            gBoxAlterar.Enabled = true;
            txtUsuario.Text = dataGridViewUsuarios.SelectedCells[0].Value.ToString();

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            log.registrar("Clicou no botão Novo. O formulário Registro abrirá.");
            gBoxAlterar.Enabled = false;
            Registro registro = new Registro();
            registro.caminhoENomeLog = caminhoENomeLog;
            registro.ShowDialog(this);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            log.registrar("Clicou no botão alterar conta.");
            if (txtUsuario.Text != "" && txtSenha.Text != "" && txtConf.Text != "")
            {
                if (txtSenha.Text == txtConf.Text)
                {
                    if (txtSenha.Text.Length <= 16)
                    {
                        UsuariosDAO usuariosDAO = new UsuariosDAO();

                        bool podeUpdate = false;
                        int tipoPrivilegioDaContaPraAlterar = usuariosDAO.procurarPrivilegioDoUsuario(txtUsuario.Text);
                        if(tipoPrivilegioDaContaPraAlterar == 1 && privilegioAtual == 1) { podeUpdate = true; }
                        if (tipoPrivilegioDaContaPraAlterar == 0 && privilegioAtual == 1) { podeUpdate = true; }
                        if (tipoPrivilegioDaContaPraAlterar == 1 && privilegioAtual == 0) { podeUpdate = false; }
                        if (tipoPrivilegioDaContaPraAlterar == 0 && privilegioAtual == 0) { podeUpdate = true; }

                        if (podeUpdate)
                        {
                            //cadastrar a conta
                            usuariosDAO.updateRegistro(txtUsuario.Text, txtSenha.Text);

                            log.registrar("Tentativa de alteração: Sucesso.");
                            MessageBox.Show("Conta alterada.", "Alterar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            gBoxAlterar.Enabled = false;
                            txtUsuario.Text = "";
                            txtSenha.Text = "";
                            txtConf.Text = "";
                        }
                        else
                        {
                            log.registrar("Tentativa de alteração: Não teve acesso a conta.");
                            MessageBox.Show("Você não tem acesso na alteração desta conta.", "Alteração", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        log.registrar("Tentativa de alteração: a senha é maior que 16 caracteres.");
                        lblWarning.Text = "A senha deve ter no máximo 16 caracteres.";
                    }
                }
                else
                {
                    log.registrar("Tentativa de alteração: as senhas devem bater.");
                    lblWarning.Text = "A senha e a confirmação de devem ser iguais.";
                }
            }
            else
            {
                log.registrar("Tentativa de alteração: nenhum campo estava preenchido.");
                lblWarning.Text = "Os campos devem ser preenchidos.";
            }
        }

        private void pBoxAberto_Click(object sender, EventArgs e)
        {
            log.registrar("Clicou no botão \'ver senha\'.");
            pBoxAberto.Enabled = false;
            pBoxAberto.Visible = false;
            pBoxFechado.Enabled = true;
            pBoxFechado.Visible = true;
            txtSenha.PasswordChar = '*';
            txtConf.PasswordChar = '*';
        }

        private void pBoxFechado_Click(object sender, EventArgs e)
        {
            log.registrar("Clicou no botão \'não ver senha\'.");
            pBoxAberto.Enabled = true;
            pBoxAberto.Visible = true;
            pBoxFechado.Enabled = false;
            pBoxFechado.Visible = false;
            txtSenha.PasswordChar = '\0';
            txtConf.PasswordChar = '\0';
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            log.registrar("Clicou no botão Todos os usuários.");
            UsuariosDAO usuariosDAO = new UsuariosDAO();
            usuarioBindingSource.DataSource = usuariosDAO.getAllUsuarios();
            dataGridViewUsuarios.DataSource = usuarioBindingSource;
            dataGridViewUsuarios.Columns.Remove("ID");
            dataGridViewUsuarios.Columns.Remove("SENHA");
            dataGridViewUsuarios.Columns.Remove("PRIVILEGIO");
        }

        private void dataGridViewUsuarios_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Verifica se o índice da linha e coluna é válido
            {
                DataGridView dataGridView = (DataGridView)sender;
                DataGridViewCell cell = dataGridView.Rows[e.RowIndex].Cells[0]; // Obtém a célula da primeira coluna (índice 0)
                if (cell.Value != null)
                {
                    object value = cell.Value; // Obtém o valor da célula
                                               // Faça algo com o valor da primeira célula
                    
                    usuarioParaDeletar = value.ToString();
                    log.registrar("Clicou em uma célula - Usuário: " + cell.Value);
                }
            }
        }

        private void dataGridViewUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewUsuarios_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridViewUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            
            //DataGridView dataGridView = (DataGridView)sender;
            //if (dataGridView.CurrentRow != null) // Verifica se é uma linha válida
            //{
            //    DataGridViewRow row = dataGridView.CurrentRow;
            //    if (row.Cells.Count > 0)
            //    {
            //        object value = row.Cells[0].Value; // Obtém o valor da primeira célula (índice 0)
            //                                           // Faça algo com o valor da primeira célula
            //        MessageBox.Show("Valor da primeira célula da linha: " + value.ToString() + "\n" + this.IsDisposed.ToString());
            //    }
            //}
        }

        private void dataGridViewUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
