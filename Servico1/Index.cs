using Braga;
using System;
using System.Windows.Forms;

namespace Servico1
{
    public partial class Servico : Form
    {
        public Servico()
        {
            GlobalExceptionHandler.Attach(log);
            InitializeComponent();

            ClientesDAO c = new ClientesDAO();
        }

        public Usuarios usuario;
        public string searchUsuarioAntigo;
        public string previousControlName = "";
        public string atualControleName = "";
        public string caminhoENomeLog;
        public Log log = new Log();

        private void Servico_Load(object sender, EventArgs e)
        {
            log.caminhoENome = caminhoENomeLog;
            log.registrar(log.barra + "O formulário Index foi aberto" + log.barra);

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

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(previousControlName + "\n" + atualControleName);
        }

        private void pDVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool estaAberto = jaEstaAberto(typeof(FormPDV));
            if (estaAberto == false)
            {
                FormPDV formPDV = new FormPDV();
                formPDV.caminhoENomeLog = caminhoENomeLog;
                log.registrar("Botão PDV clicado.");
                formPDV.ShowDialog(this);
            }
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool estaAberto = jaEstaAberto(typeof(Usuarios));
            if (estaAberto == false)
            {
                FormUsuarios formUsuarios = new FormUsuarios();
                formUsuarios.privilegioAtual = usuario.PRIVILEGIO;
                formUsuarios.caminhoENomeLog = caminhoENomeLog;
                log.registrar("Botão USUÁRIOS clicado.");
                formUsuarios.ShowDialog(this);

            }
        }

        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool estaAberto = jaEstaAberto(typeof(FormCadastroCliente));
            if (estaAberto == false)
            {
                FormCadastroCliente formCadastroCliente = new FormCadastroCliente();
                formCadastroCliente.caminhoENomeLog = caminhoENomeLog;
                log.registrar("Botão CADASTRO CLIENTE foi clicado.");
                formCadastroCliente.ShowDialog(this);
            }
        }

        private void controleDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool estaAberto = jaEstaAberto(typeof(FormClientes));
            if (estaAberto == false)
            {
                FormClientes formClientes = new FormClientes();
                log.registrar("Botão CONTROLE CLIENTES foi clicado.");
                formClientes.caminhoENomeLog = caminhoENomeLog;
                formClientes.ShowDialog(this);
            }
        }

        private void clienteDevedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool estaAberto = jaEstaAberto(typeof(FormDevedorCliente));
            if (estaAberto == false)
            {
                FormDevedorCliente formDevedor = new FormDevedorCliente();
                formDevedor.privilegioAtual = usuario.PRIVILEGIO;
                log.registrar("Botão CLIENTE DEVEDOR clicado.");

                formDevedor.caminhoENomeLog = caminhoENomeLog;
                formDevedor.ShowDialog(this);
            }
        }

        private void vendaPorPeríodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool estaAberto = jaEstaAberto(typeof(FormPeriodo));
            if (estaAberto == false)
            {
                if (usuario.PRIVILEGIO == 1)
                {
                    FormPeriodo formPeriodo = new FormPeriodo();
                    formPeriodo.caminhoENomeLog = caminhoENomeLog;
                    log.registrar("Botão VENDAS POR PERIODO clicado.");
                    formPeriodo.ShowDialog(this);
                }
            }
        }

        private void acessoÀVendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool estaAberto = jaEstaAberto(typeof(FormAcessoVendas));
            if (estaAberto == false)
            {
                FormAcessoVendas formAcesso = new FormAcessoVendas();
                formAcesso.privilegioAtual = usuario.PRIVILEGIO;
                formAcesso.caminhoENomeLog = caminhoENomeLog;
                log.registrar("O botão ACESSO A VENDAS foi clicado.");
                formAcesso.ShowDialog(this);
            }
        }

        private void notasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool estaAberto = jaEstaAberto(typeof(FormNotas));
            if (estaAberto == false)
            {
                FormNotas formNota = new FormNotas();
                formNota.caminhoENomeLog = caminhoENomeLog;
                log.registrar("O botão CONTROLE DE NOTAS.");
                formNota.ShowDialog(this);
            }
        }

        private void registroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool estaAberto = jaEstaAberto(typeof(Registro));
            if (estaAberto == false)
            {
                Registro formRegistro = new Registro();
                formRegistro.privilegioAtual = usuario.PRIVILEGIO;
                formRegistro.caminhoENomeLog = caminhoENomeLog;
                log.registrar("Botão REGISTRO foi clicado.");
                formRegistro.ShowDialog(this);
            }
        }
    }
}

