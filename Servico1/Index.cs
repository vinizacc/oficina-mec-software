using Braga;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Color = System.Drawing.Color;
using Control = System.Windows.Forms.Control;

namespace Servico1
{
    public partial class Servico : Form
    {
        public Servico()
        {
            GlobalExceptionHandler.Attach(log);
            InitializeComponent();

            apB4.Enabled = false;
            apB4.Visible = false;
            alabel5.Enabled = false;
            alabel5.Visible = false;
            apB3.Enabled = false;
            apB3.Visible = false;
            alabel3.Enabled = false;
            alabel3.Visible = false;
            ClientesDAO c = new ClientesDAO();
        }
        public Usuarios usuario;
        
        private void Servico_Load(object sender, EventArgs e)
        {
            eventosMouseEntreSai(this);
            eventosClickMenu(this);
            esconderTodosItems();
            posicionarLabelEmPicBox();
            log.caminhoENome = caminhoENomeLog;
            log.registrar(log.barra + "O formulário Index foi aberto" + log.barra);

            if (usuario.PRIVILEGIO != null)
            {
                if(usuario.PRIVILEGIO == 1) { lblTipoDeConta.Text = "usuário: " + usuario.USUARIO + " | conta adm"; }
                else if (usuario.PRIVILEGIO == 0) { lblTipoDeConta.Text = "usuário: " + usuario.USUARIO + ""; }
            }
        }

        public string searchUsuarioAntigo;
        public string previousControlName = "";
        public string atualControleName = "";
        public string caminhoENomeLog;
        public Log log = new Log();

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

        private void menuClick(object sender, System.EventArgs e)
        {
            Control control = (Control)sender;

            if (control is Label || control is PictureBox)
            {
                if (control.Name == "pB1" || control.Name == "label1") //USUÁRIOS
                {
                    bool estaAberto = jaEstaAberto(typeof(FormUsuarios));
                    if (estaAberto == false)
                    {
                        FormUsuarios formUsuarios = new FormUsuarios();
                        formUsuarios.privilegioAtual = usuario.PRIVILEGIO;
                        formUsuarios.caminhoENomeLog = caminhoENomeLog;
                        log.registrar("Botão USUÁRIOS clicado.");
                        formUsuarios.ShowDialog(this);
                        
                    }
                }
                else if (control.Name == "pBoxRegistro" || control.Name == "label15") //REGISTRO
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
                else if (control.Name == "pB5" || control.Name == "label6") // PDV
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
                else if (control.Name == "pBoxCadastroCliente" || control.Name == "label10") // Cadastro cliente
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
                else if (control.Name == "pBoxAbrirCliente" || control.Name == "label9") // Controle clientes
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
                else if (control.Name == "pBoxDevedor" || control.Name == "label13") // Cliente devedor
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
                else if (control.Name == "pBoxPeriodo" || control.Name == "label14") // Vendas periodo
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
                else if (control.Name == "pBoxAcesso" || control.Name == "label30") // Acesso Vendas
                {
                    bool estaAberto = jaEstaAberto(typeof(FormAcessoVendas));
                    if (estaAberto == false)
                    {
                        FormAcessoVendas formAcesso = new FormAcessoVendas();
                        formAcesso.privilegioAtual = usuario.PRIVILEGIO;
                        formAcesso.caminhoENomeLog = caminhoENomeLog;
                        log.registrar("O botão Acesso vendas foi clicado. \r\n O formulário vai ser aberto.");
                        formAcesso.ShowDialog(this);
                    }
                }
            }
        }
        //16997723896
        //47534228875
        public void lbl_MouseEnter(object sender, System.EventArgs e)
        {
            Control controle = (Control)sender;

            if (controle is Label || controle is PictureBox)
            {
                if (controle.Name == "label1" || controle.Name == "pB1") // USUARIOS
                {
                    label1.BackColor = corDoFundo();
                    pB1.BackColor = corDoFundo();
                    label1.ForeColor = corDasLabelEnter();
                }
                else if (controle.Name == "label15" || controle.Name == "pBoxRegistro") // REGISTRO
                {
                    label15.BackColor = corDoFundo();
                    pBoxRegistro.BackColor = corDoFundo();
                    label15.ForeColor = corDasLabelEnter();
                }
                else if (controle.Name == "label2" || controle.Name == "pB2") //Clientes
                {
                    label2.BackColor = corDoFundo();
                    pB2.BackColor = corDoFundo();
                    label2.ForeColor = corDasLabelEnter();

                    esconderTodosItems();

                    label9.Enabled = true;
                    label9.Visible = true;
                    label10.Enabled = true;
                    label10.Visible = true;
                    pBoxCadastroCliente.Enabled = true;
                    pBoxCadastroCliente.Visible = true;
                    pBoxAbrirCliente.Enabled = true;
                    pBoxAbrirCliente.Visible = true;
                }
                else if (controle.Name == "label3" || controle.Name == "pB3") //vendas
                {
                    alabel3.BackColor = corDoFundo();
                    apB3.BackColor = corDoFundo();
                    alabel3.ForeColor = corDasLabelEnter();

                    esconderTodosItems();

                    label11.Enabled = true;
                    label11.Visible = true;
                    label12.Enabled = true;
                    label12.Visible = true;
                    pBoxPesquisar.Enabled = true;
                    pBoxPesquisar.Visible = true;
                    pBoxEfetuarVenda.Enabled = true;
                    pBoxEfetuarVenda.Visible = true;
                }
                else if (controle.ToString().Contains("Serviços") || controle.Name == "pB4") // Serviços
                {
                    alabel5.BackColor = corDoFundo();
                    apB4.BackColor = corDoFundo();
                    alabel5.ForeColor = corDasLabelEnter();

                    esconderTodosItems();

                    alabel7.Enabled = true;
                    alabel7.Visible = true;
                    label8.Enabled = true;
                    label8.Visible = true;
                    apBoxAbrirServ.Enabled = true;
                    apBoxAbrirServ.Visible = true;
                    apBoxCadastroServ.Enabled = true;
                    apBoxCadastroServ.Visible = true;

                }
                else if (controle.Name == "label4" || controle.Name == "pB6") // RELATORIOS
                {
                    label4.BackColor = corDoFundo();
                    pB6.BackColor = corDoFundo();
                    label4.ForeColor = corDasLabelEnter();

                    esconderTodosItems();

                    label13.Enabled = true;
                    label13.Visible = true;
                    label14.Enabled = true;
                    label14.Visible = true;
                    pBoxDevedor.Enabled = true;
                    pBoxDevedor.Visible = true;
                    pBoxPeriodo.Enabled = true;
                    pBoxPeriodo.Visible = true;
                    pBoxAcesso.Enabled = true;
                    pBoxAcesso.Visible = true;
                    label30.Enabled = true;
                    label30.Visible = true;

                }
                else if (controle.Name == "label6" || controle.Name == "pB5")
                {
                    esconderTodosItems();

                    label6.BackColor = corDoFundo();
                    pB5.BackColor = corDoFundo();
                    label6.ForeColor = corDasLabelEnter();
                }
                else if (controle.ToString().Contains("Cadastro Serviço") || controle.Name == "pBoxCadastroServ")
                {
                    alabel7.BackColor = corDoFundo();
                    apBoxCadastroServ.BackColor = corDoFundo();
                    alabel7.ForeColor = corDasLabelEnter();
                }
                else if (controle.ToString().Contains("Todos serviços") || controle.Name == "pBoxAbrirServ")
                {
                    label8.BackColor = corDoFundo();
                    apBoxAbrirServ.BackColor = corDoFundo();
                    label8.ForeColor = corDasLabelEnter();
                }
                else if (controle.ToString().Contains("Efetuar venda") || controle.Name == "pBoxEfetuarVenda")
                {
                    label11.BackColor = corDoFundo();
                    pBoxEfetuarVenda.BackColor = corDoFundo();
                    label11.ForeColor = corDasLabelEnter();
                }
                else if (controle.ToString().Contains("Pesquisar vendas") || controle.Name == "pBoxPesquisar")
                {
                    label12.BackColor = corDoFundo();
                    pBoxPesquisar.BackColor = corDoFundo();
                    label12.ForeColor = corDasLabelEnter();
                }
                else if (controle.Name == "label10" || controle.Name == "pBoxCadastroCliente")
                {
                    label10.BackColor = corDoFundo();
                    pBoxCadastroCliente.BackColor = corDoFundo();
                    label10.ForeColor = corDasLabelEnter();
                }
                else if (controle.Name == "label9" || controle.Name == "pBoxAbrirCliente")
                {
                    label9.BackColor = corDoFundo();
                    pBoxAbrirCliente.BackColor = corDoFundo();
                    label9.ForeColor = corDasLabelEnter();
                }
                else if (controle.Name == "label13" || controle.Name == "pBoxDevedor")
                {
                    label13.BackColor = corDoFundo();
                    pBoxDevedor.BackColor = corDoFundo();
                    label13.ForeColor = corDasLabelEnter();
                }
                else if (controle.Name == "label14" || controle.Name == "pBoxPeriodo")
                {
                    label14.BackColor = corDoFundo();
                    pBoxPeriodo.BackColor = corDoFundo();
                    label14.ForeColor = corDasLabelEnter();
                }
                else if (controle.Name == "label30" || controle.Name == "pBoxAcesso")
                {
                    label30.BackColor = corDoFundo();
                    pBoxAcesso.BackColor = corDoFundo();
                    label30.ForeColor = corDasLabelEnter();
                }
            }
        }

        public void lbl_MouseLeave(object sender, System.EventArgs e)
        {
            Control controle = (Control)sender;


            if (controle is Label || controle is PictureBox)
            {

                if (controle.ToString().Contains("Usuários") || controle.Name == "pB1")
                {
                    label1.BackColor = corFundoPanel1();
                    pB1.BackColor = corFundoPanel1();
                    label1.ForeColor = corDasLabelLeave();
                }
                else if (controle.ToString().Contains("Registro") || controle.Name == "pBoxRegistro")
                {
                    label15.BackColor = corFundoPanel1();
                    pBoxRegistro.BackColor = corFundoPanel1();
                    label15.ForeColor = corDasLabelLeave();
                }
                else if (controle.ToString().Contains("Clientes") || controle.Name == "pB2")
                {
                    label2.BackColor = corFundoPanel1();
                    pB2.BackColor = corFundoPanel1();
                    label2.ForeColor = corDasLabelLeave();
                }
                else if (controle.ToString().Contains("Vendas") || controle.Name == "pB3")
                {
                    alabel3.BackColor = corFundoPanel1();
                    apB3.BackColor = corFundoPanel1();
                    alabel3.ForeColor = corDasLabelLeave();
                }
                else if (controle.ToString().Contains("Serviços") || controle.Name == "pB4")
                {
                    alabel5.BackColor = corFundoPanel1();
                    apB4.BackColor = corFundoPanel1();
                    alabel5.ForeColor = corDasLabelLeave();
                }
                else if (controle.ToString().Contains("Financeiro") || controle.Name == "pB6")
                {
                    label4.BackColor = corFundoPanel1();
                    pB6.BackColor = corFundoPanel1();
                    label4.ForeColor = corDasLabelLeave();
                }
                else if (controle.ToString().Contains("PDV") || controle.Name == "pB5")
                {
                    label6.BackColor = corFundoPanel1();
                    pB5.BackColor = corFundoPanel1();
                    label6.ForeColor = corDasLabelLeave();
                }
                else if (controle.ToString().Contains("Cadastro Serviço") || controle.Name == "pBoxCadastroServ")
                {
                    alabel7.BackColor = corFundoPanel1();
                    apBoxCadastroServ.BackColor = corFundoPanel1();
                    alabel7.ForeColor = corDasLabelLeave();

                }
                else if (controle.ToString().Contains("Todos serviços") || controle.Name == "pBoxAbrirServ")
                {
                    label8.BackColor = corFundoPanel1();
                    apBoxAbrirServ.BackColor = corFundoPanel1();
                    label8.ForeColor = corDasLabelLeave();
                }
                else if (controle.ToString().Contains("Efetuar venda") || controle.Name == "pBoxEfetuarVenda")
                {
                    label11.BackColor = corFundoPanel1();
                    pBoxEfetuarVenda.BackColor = corFundoPanel1();
                    label11.ForeColor = corDasLabelLeave();
                }
                else if (controle.ToString().Contains("Pesquisar vendas") || controle.Name == "pBoxPesquisar")
                {
                    label12.BackColor = corFundoPanel1();
                    pBoxPesquisar.BackColor = corFundoPanel1();
                    label12.ForeColor = corDasLabelLeave();
                }
                else if (controle.ToString().Contains("Controle Clientes") || controle.Name == "pBoxCadastroCliente")
                {
                    label10.BackColor = corFundoPanel1();
                    pBoxCadastroCliente.BackColor = corFundoPanel1();
                    label10.ForeColor = corDasLabelLeave();
                }
                else if (controle.ToString().Contains("Todos Clientes") || controle.Name == "pBoxAbrirCliente")
                {
                    label9.BackColor = corFundoPanel1();
                    pBoxAbrirCliente.BackColor = corFundoPanel1();
                    label9.ForeColor = corDasLabelLeave();
                }
                else if (controle.ToString().Contains("Cliente Devedor") || controle.Name == "pBoxDevedor")
                {
                    label13.BackColor = corFundoPanel1();
                    pBoxDevedor.BackColor = corFundoPanel1();
                    label13.ForeColor = corDasLabelLeave();
                }
                else if (controle.ToString().Contains("Vendas por Período") || controle.Name == "pBoxPeriodo")
                {
                    label14.BackColor = corFundoPanel1();
                    pBoxPeriodo.BackColor = corFundoPanel1();
                    label14.ForeColor = corDasLabelLeave();
                }
                else if (controle.ToString().Contains("Acesso Vendas") || controle.Name == "pBoxAcesso")
                {
                    label30.BackColor = corFundoPanel1();
                    pBoxAcesso.BackColor = corFundoPanel1();
                    label30.ForeColor = corDasLabelLeave();
                }
            }
        }

        public Color corDasLabelEnter() { return Color.DarkGray; }
        public Color corDoFundo() { return Color.White; }
        public Color corDasLabelLeave() { return Color.White; }
        private Color corFundoPanel1() { return panel1.BackColor; }

        public void eventosClickMenu(Control control)
        {
            if (control is Label || control is PictureBox)
            {
                control.DoubleClick += new System.EventHandler(menuClick);
            }
            else
            {
                foreach (Control ctrl in control.Controls)
                {
                    eventosClickMenu(ctrl);
                }
            }
        }

        public void eventosMouseEntreSai(Control control)
        {
            if (control is Label || control is PictureBox)
            {
                control.MouseEnter += new System.EventHandler(lbl_MouseEnter);
                control.MouseLeave += new System.EventHandler(lbl_MouseLeave);

            }
            else
            {
                foreach (Control ctrl in control.Controls)
                {
                    eventosMouseEntreSai(ctrl);
                }
            }
        }

        public void esconderTodosItems()
        {


            alabel7.Enabled = false;
            alabel7.Visible = false;
            label8.Enabled = false;
            label8.Visible = false;
            apBoxAbrirServ.Enabled = false;
            apBoxAbrirServ.Visible = false;
            apBoxCadastroServ.Enabled = false;
            apBoxCadastroServ.Visible = false;

            label9.Enabled = false;
            label9.Visible = false;
            label10.Enabled = false;
            label10.Visible = false;
            pBoxAbrirCliente.Enabled = false;
            pBoxAbrirCliente.Visible = false;
            pBoxCadastroCliente.Enabled = false;
            pBoxCadastroCliente.Visible = false;

            label11.Enabled = false;
            label11.Visible = false;
            label12.Enabled = false;
            label12.Visible = false;
            pBoxEfetuarVenda.Enabled = false;
            pBoxEfetuarVenda.Visible = false;
            pBoxPesquisar.Enabled = false;
            pBoxPesquisar.Visible = false;

            pBoxDevedor.Visible = false;
            pBoxDevedor.Enabled = false;
            label13.Enabled = false;
            label13.Visible = false;
            pBoxPeriodo.Enabled = false;
            pBoxPeriodo.Visible = false;
            label14.Visible = false;
            label14.Enabled = false;

            pBoxAcesso.Enabled = false;
            pBoxAcesso.Visible = false;
            label30.Enabled = false;
            label30.Visible = false;
        }

        private void posicionarLabelEmPicBox()
        {
            foreach (PictureBox pictureBox in this.Controls.OfType<PictureBox>())
            {
                // Verifica se a picturebox tem uma label dentro dela
                if (pictureBox.Controls.Count > 0 && pictureBox.Controls[0] is Label label)
                {
                    // Calcula a posição x e y da label para centralizá-la na picturebox
                    int x = (pictureBox.Width - label.Width) / 2;
                    int y = (pictureBox.Height - label.Height) / 2;

                    // Define a nova posição da label na picturebox
                    label.Location = new Point(x, y);
                }
            }
        }

        public void controleDeItens(List<System.Windows.Forms.Control> listaControles)
        {

        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void pB1_Click(object sender, EventArgs e)
        {

        }

        private void pB4_MouseEnter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(previousControlName + "\n" + atualControleName);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pB3_Click(object sender, EventArgs e)
        {

        }

        private void pB2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pBoxRegistro_Click(object sender, EventArgs e)
        {

        }
    }
}

