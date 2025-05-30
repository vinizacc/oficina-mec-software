﻿using Braga;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Color = System.Drawing.Color;

namespace Servico1
{
    public partial class FormPDV : Form
    {
        public FormPDV()
        {
            GlobalExceptionHandler.Attach(log);
            InitializeComponent();

            btnFantasmaRegistro.Click += new EventHandler(RegistroOficialReal);
        }

        private float diagNaOficina { get; set; }
        private float diagForaDaOficina { get; set; }
        private float kmBase { get; set; }

        private List<string[,]> listaDados = new List<string[,]>();

        Pdf pdf = new Pdf();
        ClientesDAO c = new ClientesDAO();
        List<Clientes> cliente = new List<Clientes>();
        FolderControl folder = new FolderControl();

        string filePathAndName;
        bool registrado = false;
        string comboTipoPag;
        bool primeiraVezClickando = true;
        string dataDoArquivo;
        int numeroNota;
        private static int cortador = 0;
        bool bandeiraParaBD = false;

        public Log log = new Log();
        public string caminhoENomeLog;

        int registraUmavez = 1;

        public event EventHandler MudarCorTextBox;
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                log.registrar("Botão ESC foi clicado.");
                return true;
            }
            if (keyData == Keys.F2)
            {
                FormAlteraPropriedades alteraProp = new FormAlteraPropriedades();
                log.registrar("Botão F2 (ALTERAR PROPRIEDADES) foi clicado.");
                alteraProp.Show();
            }
            if (keyData == Keys.F3)
            {
                log.registrar("Botão F3 (FECHAR) foi clicado.");
                this.Close();
            }
            if (keyData == Keys.F8)
            {
                EventArgs e = new EventArgs();
                picBoxSalvar.Invoke(new EventHandler(picBoxSalvar_Click), picBoxSalvar, e);
                log.registrar("Botão F3 (SALVAR) foi clicado.");
            }
            if (keyData == Keys.F12)
            {
                EventArgs e = new EventArgs();
                log.registrar("Botão F12 (FINALIZAR) foi clicado.");
                picBoxFinalizar.Invoke(new EventHandler(picBoxFinalizar_Click), picBoxFinalizar, e);
            }
            return base.ProcessDialogKey(keyData);
        }

        private void FormPDV_Load(object sender, EventArgs e)
        {
            log.caminhoENome = caminhoENomeLog;
            log.registrar(log.barra + "O formulário PDV foi aberto" + log.barra);
            configuraçõesIniciais();
            //iniciandoPdf();
        }

        private void iniciandoPdf()
        {
            filePathAndName = pdf.criarPdfESalva();

            axAcroPDF2.src = folder.absolutePathOfPdf(filePathAndName);
            log.registrar("Iniciando PDF.");
            axAcroPDF2.setShowScrollbars(true);
            axAcroPDF2.setZoom(115);
        }
        private void configuraçõesIniciais()
        {
            OficinaDAO ofDAO = new OficinaDAO();
            Oficina of = new Oficina();

            of = ofDAO.getOficinaValues();

            diagNaOficina = of.VALOR_DIAG_OFICINA;
            diagForaDaOficina = of.VALOR_DIAG_FORA;
            kmBase = of.VALOR_KM;

            primeiraDivisao();
            segundaDivisao();
            controleCheckBox();

            //label1.Location = new System.Drawing.Point(this.Width  ,0) ;
            

            //lblArq.Location = new System.Drawing.Point(picBoxProp.Location.X + picBoxFechar.Size.Width + 100, picBoxProp.Location.Y);

            //picBoxSalvar.Location = new System.Drawing.Point(groupBox2.Location.X + (groupBox2.Width - 145), groupBox2.Location.Y + 190);
            //lblSalvar.Location = new System.Drawing.Point(groupBox2.Location.X + (groupBox2.Width - 120), picBoxSalvar.Location.Y + picBoxSalvar.Height + 10);

            //picBoxFinalizar.Location = new System.Drawing.Point(groupBox2.Location.X + (groupBox2.Width - 175) - picBoxSalvar.Width, groupBox2.Location.Y + 190);
            //lblFinalizar.Location = new System.Drawing.Point(picBoxFinalizar.Location.X + (lblFinalizar.Width / 6), picBoxSalvar.Location.Y + picBoxSalvar.Height + 10);


            ClientesDAO c = new ClientesDAO();
            txtBoxNome.AutoCompleteCustomSource = c.autoCompleteSource(txtBoxNome.Text);
            textBox5.Text = "0";
            txtBoxValorPago.Text = "0";

            comboBoxQt.Text = "1";
            comboBoxQt.Items.Add("1");
            comboBoxQt.Items.Add("2");
            comboBoxQt.Items.Add("3");
            comboBoxQt.Items.Add("4");
            comboBoxQt.Items.Add("5");
            comboBoxQt.Items.Add("6");
            comboBoxQt.Items.Add("7");
            comboBoxQt.Items.Add("8");
            comboBoxQt.Items.Add("9");
            comboBoxQt.Items.Add("10");

            comboBoxTipo.Text = "Dinheiro";
            comboBoxTipo.Items.Add("Dinheiro");
            comboBoxTipo.Items.Add("Débito");
            comboBoxTipo.Items.Add("Crédito");

            axAcroPDF2.setShowScrollbars(true);
            axAcroPDF2.setZoom(115);

            //adicionarRect(0, 0, this.Width, this.Height);
            //roundedSquareControl.BringToFront();

            //foreach (Control item in this.Controls)
            //{
            //    item.Visible = false;
            //}

            iniciandoPdf();
        }

        public void segundaDivisao()
        {
            groupBox1.Height = (this.Height - pictureBox1.Height + 7);
            groupBox1.Width = (this.Width / 3);
            groupBox1.Location = new System.Drawing.Point(0, pictureBox1.Location.Y + pictureBox1.Height + 5);

            label7.Parent = groupBox1;
            label7.Location = new System.Drawing.Point(0, 0);
            label7.Width = groupBox1.Width;

            tabControl1.Parent = groupBox1;
            tabControl1.Location = new System.Drawing.Point((groupBox1.Width / 2) - (tabControl1.Width / 2) , label7.Location.Y + label7.Height + 5);
            tabControl1.Height = groupBox1.Height - label7.Height - picBoxFinalizar.Height - lblFinalizar.Height - 50;

            //------------------------------TABPAGE1
            int alturaLblAnuncio = txtBoxNome.Height + txtBoxTelefone.Height + txtBoxDoc.Height + txtBoxEnd.Height + 55;

            label2.Parent = tabPage1;
            label2.Location = new System.Drawing.Point(lblAnuncio.Location.X ,20);
            txtBoxNome.Parent = tabPage1;
            txtBoxNome.Location = new System.Drawing.Point(label2.Location.X + label2.Width, label2.Location.Y - (label2.Height / 4));

            label3.Parent = tabPage1;
            label3.Location = new System.Drawing.Point(lblAnuncio.Location.X, label2.Location.Y + label2.Height  + 16);
            txtBoxTelefone.Parent = tabPage1;
            txtBoxTelefone.Location = new System.Drawing.Point(label3.Location.X + label3.Width, label3.Location.Y - (label3.Height / 4));

            label4.Parent = tabPage1;
            label4.Location = new System.Drawing.Point(label3.Location.X, label3.Location.Y + label3.Height + 16);
            txtBoxDoc.Parent = tabPage1;
            txtBoxDoc.Location = new System.Drawing.Point(label4.Location.X + label4.Width - 1, label4.Location.Y - (label4.Height / 4));

            label5.Parent = tabPage1;
            label5.Location = new System.Drawing.Point(label4.Location.X, label4.Location.Y + label4.Height + 16);
            txtBoxEnd.Parent = tabPage1;
            txtBoxEnd.Location = new System.Drawing.Point(label5.Location.X + label5.Width, label5.Location.Y - (label5.Height / 4));

            lblAnuncio.Parent = tabPage1;
            lblAnuncio.Location = new System.Drawing.Point((tabPage1.Width / 2) - (lblAnuncio.Width / 2), alturaLblAnuncio);

            picBoxRegistrar.Parent = tabPage1;
            picBoxRegistrar.Location = new System.Drawing.Point(lblAnuncio.Location.X + lblAnuncio.Width - picBoxRegistrar.Width, tabControl1.Height - picBoxRegistrar.Height *2);
            label14.Parent = tabPage1;
            label14.Location = new System.Drawing.Point(picBoxRegistrar.Location.X - 15, tabControl1.Height - picBoxRegistrar.Height + 5);

            //------------------------TABPAGE2

            lblItem.Parent = tabPage2;
            lblItem.Location = label2.Location;
            txtBoxItem.Parent = tabPage2;
            txtBoxItem.Location = new System.Drawing.Point(lblItem.Location.X + lblItem.Width, lblItem.Location.Y);

            lblValor.Parent = tabPage2;
            lblValor.Location = new System.Drawing.Point(lblItem.Location.X, lblItem.Location.Y + lblValor.Height + 16);
            txtBoxValor.Parent = tabPage2;
            txtBoxValor.Location = new System.Drawing.Point(lblItem.Location.X + lblValor.Width, lblValor.Location.Y - (lblValor.Height / 4));

            lblQt.Parent = tabPage2;
            lblQt.Location = new System.Drawing.Point(lblItem.Location.X, lblValor.Location.Y + lblQt.Height + 16);
            comboBoxQt.Parent = tabPage2;
            comboBoxQt.Location = new System.Drawing.Point(lblItem.Location.X + lblQt.Width, lblQt.Location.Y - (lblQt.Height / 4));

            lblDesc.Parent = tabPage2;
            lblDesc.Location = new System.Drawing.Point(lblItem.Location.X, lblQt.Location.Y + lblDesc.Height + 16);
            txtBoxDesc.Parent = tabPage2;
            txtBoxDesc.Location = new System.Drawing.Point(lblItem.Location.X, lblDesc.Location.Y + lblDesc.Height + 8);

            label10.Parent = tabPage2;
            label10.Location = new System.Drawing.Point(lblItem.Location.X, txtBoxDesc.Location.Y + txtBoxDesc.Height + 8);
            comboBoxTipo.Parent = tabPage2;
            comboBoxTipo.Location = new System.Drawing.Point(lblItem.Location.X + label10.Width, label10.Location.Y  - (label10.Height / 4));

            label8.Parent = tabPage2;
            label8.Location = new System.Drawing.Point(lblItem.Location.X, label10.Location.Y + label10.Height + 16);
            txtBoxValorPago.Parent = tabPage2;
            txtBoxValorPago.Location = new System.Drawing.Point(lblItem.Location.X + label8.Width, label8.Location.Y - (label8.Height/4));

            picBoxSalvar.Parent = tabPage2;
            picBoxSalvar.Location = picBoxRegistrar.Location;
            lblSalvar.Parent = tabPage2;
            lblSalvar.Location = new System.Drawing.Point(picBoxSalvar.Location.X - (lblSalvar.Width / 2) + (picBoxSalvar.Width / 2 ), tabControl1.Height - picBoxSalvar.Height + 5);
            
            //--------------------------------GROUPBOX1

            picBoxFinalizar.Parent = groupBox1;
            picBoxFinalizar.Location = new System.Drawing.Point(groupBox1.Location.X + groupBox1.Width - picBoxFinalizar.Width + (tabControl1.Width - groupBox1.Width) - 28, tabControl1.Location.Y + tabControl1.Height + (picBoxFinalizar.Height / 4));
            lblFinalizar.Parent = groupBox1;
            lblFinalizar.Location = new System.Drawing.Point(picBoxFinalizar.Location.X + (lblFinalizar.Width / 2 - picBoxFinalizar.Width/2) - 15, picBoxFinalizar.Location.Y + picBoxFinalizar.Height);

            pictureBox2.Parent = groupBox1;
            pictureBox2.Location = new System.Drawing.Point(picBoxFinalizar.Location.X - pictureBox2.Width - 15, picBoxFinalizar.Location.Y);
            label6.Parent = groupBox1;
            label6.Location = new System.Drawing.Point(pictureBox2.Location.X + (label6.Width / 2 - pictureBox2.Width / 2) - 15, pictureBox2.Location.Y + pictureBox2.Height);

            //-------------------------------AXACRO

            int alturaAx = label7.Height + tabControl1.Height;
            axAcroPDF2.Location = new System.Drawing.Point(groupBox1.Location.X + groupBox1.Width + 5, groupBox1.Location.Y);
            axAcroPDF2.Size = new System.Drawing.Size(this.Width - groupBox1.Width - 30, alturaAx + 3);

            // ------------------------------RODAPE

            picBoxRodape.Size = new System.Drawing.Size(this.Width - groupBox1.Width - 30, this.Height - axAcroPDF2.Height - pictureBox1.Height + 3 );
            picBoxRodape.Location = new System.Drawing.Point(axAcroPDF2.Location.X, axAcroPDF2.Location.Y + axAcroPDF2.Height + 3);

            picBoxProp.Location = new System.Drawing.Point(picBoxRodape.Location.X + 35, picBoxRodape.Location.Y + 41);
            lblProp.Location = new System.Drawing.Point(picBoxProp.Location.X + ((picBoxProp.Width / 2) - (lblProp.Width / 2)), picBoxProp.Location.Y - 25);

            picImpri.Location = new System.Drawing.Point(picBoxProp.Location.X + 30 + picImpri.Width, picBoxProp.Location.Y + 5);
            lblImpri.Location = new System.Drawing.Point(picImpri.Location.X + ((picImpri.Width / 2) - (lblImpri.Width / 2)), lblProp.Location.Y);

            picBoxFechar.Location = new System.Drawing.Point(picImpri.Location.X + 10 + picBoxFechar.Size.Width, picImpri.Location.Y - 7);
            lblFechar.Location = new System.Drawing.Point(picBoxFechar.Location.X + ((picBoxFechar.Width / 2) - (lblFechar.Width / 2)), lblProp.Location.Y);

            

            string nome = "";
            foreach (Control item in groupBox1.Controls)
            {
                nome += item.Name + " - X: " + item.Location.X + ", Y: " + item.Location.Y + "\n";

                //if (item is Label)
                    //item.BackColor = Color.Pink;
            }

            foreach (Control item in tabPage2.Controls)
            {
                //nome += item.Name + " - X: " + item.Location.X + ", Y: " + item.Location.Y + "\n";

                //if(item is Label)
                //item.BackColor = Color.Pink;
            }
            //MessageBox.Show(nome);
        }

        public void primeiraDivisao()
        {
            pictureBox1.Height = this.Height / 10;
            pictureBox1.Width = this.Width;
            pictureBox1.Location = new System.Drawing.Point(0, 0);

            labelPdv.Location = new System.Drawing.Point((this.Width / 2) - (labelPdv.Width / 2), ((pictureBox1.Height / 2) - (labelPdv.Height / 2)));

        }

        private void controleCheckBox()
        {
            checkBoxOficina.Checked = false;
            checkBoxFora.Checked = false;
        }

        private void textBox2_Leave(object sender, EventArgs e) //TextBoxTelefone
        {
            bool verificaSomenteNumeros = Regex.IsMatch(txtBoxTelefone.Text, @"^\d+$");
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                verificaAutoCompleteECompletaCampos();
            }
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            verificaAutoCompleteECompletaCampos();
        }

        private void verificaAutoCompleteECompletaCampos()
        {

            string valorEntrada = txtBoxNome.Text;

            if (txtBoxNome.AutoCompleteCustomSource.Contains(txtBoxNome.Text))
            {
                ClientesDAO c = new ClientesDAO();

                cliente = c.procurarClientePeloNomeRetornLista(txtBoxNome.Text);

                txtBoxTelefone.Text = cliente[0].CELULAR;
                txtBoxDoc.Text = cliente[0].DOC_PESSOAL;
                txtBoxEnd.Text = cliente[0].ENDERECO;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {

        }

        private void picBoxProp_Click(object sender, EventArgs e)
        {
            temporizadorBotao(picBoxProp);
            picBoxProp.Focus();
            log.registrar("Botão PROPRIEDADES foi clicado.");
            FormAlteraPropriedades alteraProp = new FormAlteraPropriedades();
            alteraProp.Show();
        }

        private void picBoxSalvar_Click(object sender, EventArgs e)
        {
            temporizadorBotao(picBoxSalvar);
            log.registrar("Botao SALVAR foi clicado.");

            //-----------------------------------------

            MudarCorTextBox?.Invoke(this, EventArgs.Empty);

            if (txtBoxItem.Text != "" && txtBoxValor.Text != "")
            {
                if (primeiraVezClickando)
                {
                    pdf.criaFolhaEmBranco(filePathAndName);
                    axAcroPDF2.src = folder.absolutePathOfPdf(filePathAndName);
                    log.registrar("Carregando dados no visualizador de PDF. (Pelo picBoxSalvar_Click)");

                    primeiraVezClickando = false;
                }
                if (registrado == false)
                {
                    picBoxRegistrar_Click(sender, e);
                    log.registrar("Tentativa de Registro a partir do botão Salvar.");
                    
                    if (txtBoxNome.Text != "" && txtBoxTelefone.Text != "" && txtBoxDoc.Text != "" && txtBoxEnd.Text != "") 
                    {
                        registrado = true; 
                    }
                    else
                    {
                        log.registrar("Algum campo vazio.");
                    }
                }
                string[,] array = new string[1, 4];

                array[0, 0] = txtBoxItem.Text;

                array[0, 1] = txtBoxDesc.Text;

                array[0, 2] = comboBoxQt.Text;

                array[0, 3] = txtBoxValor.Text;


                listaDados.Add(array);

                //--------------------DIAGNOSTICO
                OficinaDAO ofDAO = new OficinaDAO();
                Oficina of = new Oficina();
                of = ofDAO.getOficinaValues();

                string diagnostico = "";
                if (checkBoxOficina.Checked) { diagnostico = of.VALOR_DIAG_OFICINA.ToString(); }
                else if (checkBoxFora.Checked) { diagnostico = of.VALOR_DIAG_FORA.ToString(); }
                else if (!checkBoxOficina.Checked && !checkBoxFora.Checked) { diagnostico = "0"; }

                //-------------------VALOR KM
                string valorKm = (of.VALOR_KM * Convert.ToDouble(textBox5.Text)).ToString();
                //------------------

                string valorPago = txtBoxValorPago.Text;


                pdf.atualizaTabela(filePathAndName, listaDados, diagnostico, valorKm, valorPago);
                log.registrar("Atualizou o pdf.");
                axAcroPDF2.src = folder.absolutePathOfPdf(filePathAndName);
                

            }
            else
            {
                log.registrar("Campos item e valor vazios.");
            }
        }

        private void picBoxFinalizar_Click(object sender, EventArgs e)
        {
            try
            {
                log.registrar("Botão FINALIZAR clicado.");
                temporizadorBotao(picBoxFinalizar);
                picBoxFinalizar.Focus();
                axAcroPDF2.src = folder.absolutePathOfPdf(filePathAndName);
                

                DialogResult r = MessageBox.Show("Tem certeza que deseja registrar a venda?", "Confirmação", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes) 
                {
                    log.registrar("Tentando finalizar.");
                    finalizacao(); 
                }
                else
                {
                    log.registrar("Cancelou a finalização.");
                }

                bandeiraParaBD = true;
            }
            catch (Exception ex)
            {
                log.registrar("Aconteceu um erro: "+ ex.Message);
                MessageBox.Show("Ocorreu um erro, contacte o desenvolvedor", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void finalizacao()
        {

            double valorFinalParaDB = pdf.valorFinalParaDB;
            double valorPagoPeloCliente = Convert.ToDouble(txtBoxValorPago.Text);

            int pagou = -1;

            if (valorFinalParaDB - valorPagoPeloCliente == 0 && txtBoxValorPago.Text != "")
            {
                pagou = 1;
            }
            else if (valorFinalParaDB - valorPagoPeloCliente > 0)
            {
                pagou = 0;
            }
            else
            {
                pagou = 1;
            }

            if (comboBoxTipo.SelectedIndex == -1 || comboBoxTipo.SelectedIndex == 0) { comboTipoPag = 0.ToString(); }
            else if (comboBoxTipo.SelectedIndex == 1) { comboTipoPag = 1.ToString(); }
            else { comboTipoPag = 2.ToString(); }

            ServicosDAO s = new ServicosDAO();

            if (cortador == 0)
            {
                c.adicionarNumeroNota(cliente[0].ID_PF); // 21
                numeroNota = c.buscaNumeroNota(cliente[0].ID_PF);
                cortador = 1;
            }

            s.insertOrdemServico(cliente[0].ID_PF, listaDados, dataDoArquivo, valorPagoPeloCliente.ToString(), valorFinalParaDB.ToString(), numeroNota, comboTipoPag, pagou, filePathAndName);
            log.registrar("Finalizado.\r\nPerfil ordem de serviço: \r\n - ID Cliente: "+ cliente[0].ID_PF + "\r\n - Data serviço: "+ dataDoArquivo);
        }


        private void btnFantasmaRegistro_Click(object sender, EventArgs e)
        {
            RegistroOficialReal(sender, e);

            //RegistroOficialReal(sender, e);
        }

        private void RegistroOficialReal(object sender, EventArgs e)
        {
            if (registraUmavez == 1) log.registrar("Começando o registro.");
            temporizadorBotao(picBoxRegistrar);

            // validador = 0 significa que tem campo vazio
            // validador = 1 significa que doc já existe
            // validador = 2 significa que nome já existe
            // validador = 3 significa que nome e doc já existem
            // validador = 4 significa que deu tudo certo
            // validador = 5 significa que o programa caiu em excessão.

            dataDoArquivo = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            int validador = c.insertClienteParaPdV(txtBoxNome.Text, txtBoxEnd.Text, txtBoxTelefone.Text, dataDoArquivo, txtBoxDoc.Text, "Descrição cliente", 0);
            cliente = c.procurarClientePeloNomeRetornLista(txtBoxNome.Text);

            if (cliente.Count != 0)
            {
                listaDados.Clear();
                limpezaDeCampos();
                pdf.atualizaTabelaComCliente(filePathAndName, cliente[0].NOME);
                axAcroPDF2.src = folder.absolutePathOfPdf(filePathAndName);
                if (registraUmavez == 1)
                {
                    log.registrar("Carregando dados no visualizador de PDF. (Pela função de registro)");
                }
                axAcroPDF2.ResetText();
                registrado = true;
                lblAnuncio.Text = "";
                if (registraUmavez == 1 && registrado)
                {
                    log.registrar("Não fez o registro. Puxou do banco de dados o perfil. CLIENTE: "+txtBoxNome.Text);

                }
            }
            else
            {
                if (validador == 0) { lblAnuncio.Text = "Anuncio: Existem campos vazios."; if (registraUmavez == 1) log.registrar("Tentativa de Registro: Campos vazios."); }
                else if (validador == 1) { lblAnuncio.Text = "Anuncio: Já existe um cliente com esse DOCUMENTO."; if (registraUmavez == 1) log.registrar("Tentativa de Registro: Já existe o documento."); }
                else if (validador == 2) { lblAnuncio.Text = "Anuncio: Já existe um cliente com esse NOME."; if (registraUmavez == 1) log.registrar("Tentativa de Registro: Já existe o nome."); }
                else if (validador == 3) { lblAnuncio.Text = "Anuncio: Já existe um cliente com esse NOME e DOCUMENTO."; if (registraUmavez == 1) log.registrar("Tentativa de Registro: Já existe o nome e documento."); }
            }
            //groupBox1.Enabled = false;
            txtBoxItem.Focus();
            registraUmavez--;
        }

        private void picBoxRegistrar_Click(object sender, EventArgs e)
        {
            log.registrar("Botão REGISTRAR clicado.");
            btnFantasmaRegistro.PerformClick();

        }

        private void limpezaDeCampos()
        {
            txtBoxItem.Text = "";
            txtBoxValor.Text = "";
            txtBoxDesc.Text = "";
        }

        private void temporizadorBotao(PictureBox pB)
        {
            pB.BorderStyle = BorderStyle.Fixed3D;

            Timer timer = new Timer();
            timer.Interval = 50;

            timer.Tick += (s, ev) =>
            {
                pB.BorderStyle = BorderStyle.None;

                timer.Stop();
            };

            timer.Start();
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //    desligarControles();
            //    ligarServicos();
        }

        private void txtBoxValorPago_TextChanged(object sender, EventArgs e)
        {
            txtBoxValorPago.BackColor = Color.White;
        }

        private void txtBoxValorPago_Click(object sender, EventArgs e)
        {
            //txtBoxValorPago.SelectAll();
        }

        private void txtBoxNome_Click(object sender, EventArgs e)
        {
            //txtBoxNome.SelectAll();
        }

        private void picBoxFechar_DoubleClick(object sender, EventArgs e)
        {
            temporizadorBotao(picBoxFechar);
            log.registrar("Botão FECHAR clicado.");
            this.Close();
        }

        private void picBoxRebot_DoubleClick(object sender, EventArgs e)
        {
            FormPDV f = new FormPDV();
            f.TopMost = true;
            this.Hide();
            this.Close();
            f.Show();

        }

        private void checkBoxFora_CheckedChanged_1(object sender, EventArgs e)
        {

            if (checkBoxFora.Checked)
            {
                checkBoxOficina.Checked = false;
            }

            OficinaDAO ofDAO = new OficinaDAO();
            Oficina of = new Oficina();
            of = ofDAO.getOficinaValues();
            Pdf p = new Pdf();
            string valorKm = (of.VALOR_KM * Convert.ToDouble(textBox5.Text)).ToString();

            string diagnostico = "";
            if (checkBoxOficina.Checked) { diagnostico = of.VALOR_DIAG_OFICINA.ToString(); }
            else if (checkBoxFora.Checked) { diagnostico = of.VALOR_DIAG_FORA.ToString(); }
            else if (!checkBoxOficina.Checked && !checkBoxFora.Checked) { diagnostico = "0"; }

            string valorPago = txtBoxValorPago.Text;
            p.mudaValorDiagnostico(filePathAndName, listaDados, diagnostico, valorKm, cliente[0].NOME, cliente[0].DOC_PESSOAL, cliente[0].ENDERECO, cliente[0].CELULAR, valorPago);

            axAcroPDF2.src = folder.absolutePathOfPdf(filePathAndName);
            log.registrar("Carregando dados no visualizador de PDF. (Pelo checkBoxFora_CheckedChanged_1)");
        }

        private void checkBoxOficina_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBoxOficina.Checked)
            {
                checkBoxFora.Checked = false;
            }

            OficinaDAO ofDAO = new OficinaDAO();
            Oficina of = new Oficina();
            of = ofDAO.getOficinaValues();
            Pdf p = new Pdf();
            string valorKm = (of.VALOR_KM * Convert.ToDouble(textBox5.Text)).ToString();

            string diagnostico = "";
            if (checkBoxOficina.Checked) { diagnostico = of.VALOR_DIAG_OFICINA.ToString(); }
            else if (checkBoxFora.Checked) { diagnostico = of.VALOR_DIAG_FORA.ToString(); }
            else if (!checkBoxOficina.Checked && !checkBoxFora.Checked) { diagnostico = "0"; }

            string valorPago = txtBoxValorPago.Text;
            p.mudaValorDiagnostico(filePathAndName, listaDados, diagnostico, valorKm, cliente[0].NOME, cliente[0].DOC_PESSOAL, cliente[0].ENDERECO, cliente[0].CELULAR, valorPago);

            axAcroPDF2.src = folder.absolutePathOfPdf(filePathAndName);
            log.registrar("Carregando dados no visualizador de PDF. (Pelo checkBoxOficina_CheckedChanged_1)");
        }

        private void pBoxSalvarConfig_Click(object sender, EventArgs e)
        {

        }

        private void picBoxRebot_Click(object sender, EventArgs e)
        {


        }

        private void txtBoxTelefone_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxTelefone_Click(object sender, EventArgs e)
        {
            //txtBoxTelefone.SelectAll();
        }

        private void txtBoxDoc_Click(object sender, EventArgs e)
        {
            //txtBoxDoc.SelectAll();
        }

        private void txtBoxEnd_Click(object sender, EventArgs e)
        {
            //txtBoxEnd.SelectAll();
        }

        private void FormPDV_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void txtBoxValorPago_Leave(object sender, EventArgs e)
        {
            if (checkBoxFora.Checked)
            {
                checkBoxOficina.Checked = false;
            }

            OficinaDAO ofDAO = new OficinaDAO();
            Oficina of = new Oficina();
            of = ofDAO.getOficinaValues();
            Pdf p = new Pdf();
            string valorKm = (of.VALOR_KM * Convert.ToDouble(textBox5.Text)).ToString();

            string diagnostico = "";
            if (checkBoxOficina.Checked) { diagnostico = of.VALOR_DIAG_OFICINA.ToString(); }
            else if (checkBoxFora.Checked) { diagnostico = of.VALOR_DIAG_FORA.ToString(); }
            else if (!checkBoxOficina.Checked && !checkBoxFora.Checked) { diagnostico = "0"; }

            string valorPago = txtBoxValorPago.Text;
            p.mudaValorDiagnostico(filePathAndName, listaDados, diagnostico, valorKm, cliente[0].NOME, cliente[0].DOC_PESSOAL, cliente[0].ENDERECO, cliente[0].CELULAR, valorPago);

            axAcroPDF2.src = folder.absolutePathOfPdf(filePathAndName);
            log.registrar("Valor pago saida, valor total: " + valorPago + " - cliente: "+ cliente[0].NOME);
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (checkBoxFora.Checked)
            {
                checkBoxOficina.Checked = false;
            }

            OficinaDAO ofDAO = new OficinaDAO();
            Oficina of = new Oficina();
            of = ofDAO.getOficinaValues();
            Pdf p = new Pdf();
            string valorKm = (of.VALOR_KM * Convert.ToDouble(textBox5.Text)).ToString();

            string diagnostico = "";
            if (checkBoxOficina.Checked) { diagnostico = of.VALOR_DIAG_OFICINA.ToString(); }
            else if (checkBoxFora.Checked) { diagnostico = of.VALOR_DIAG_FORA.ToString(); }
            else if (!checkBoxOficina.Checked && !checkBoxFora.Checked) { diagnostico = "0"; }

            string valorPago = txtBoxValorPago.Text;
            p.mudaValorDiagnostico(filePathAndName, listaDados, diagnostico, valorKm, cliente[0].NOME, cliente[0].DOC_PESSOAL, cliente[0].ENDERECO, cliente[0].CELULAR, valorPago);

            axAcroPDF2.src = folder.absolutePathOfPdf(filePathAndName);
            
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            temporizadorBotao(pictureBox2);
            pictureBox2.Focus();
            log.registrar("Botão ATUALIZAR clicado.");
        }

        private void picImpri_Click(object sender, EventArgs e)
        {
            log.registrar("O botão IMPRIMIR clicado.");
            temporizadorBotao(picImpri);
            picImpri.Focus();
            try
            {
                axAcroPDF2.src = folder.absolutePathOfPdf(filePathAndName);
                

                DialogResult r = MessageBox.Show("Você deseja imprimir?", "Confirmação", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes) 
                {
                    log.registrar("Impressão do arquivo feita: "+ filePathAndName);
                    axAcroPDF2.printWithDialog(); 
                }
                else
                {
                    log.registrar("Impressão cancelada.");
                }

            }
            catch (Exception ex)
            {
                log.registrar("Erro na impressão: \r\n"+ex.Message);
                MessageBox.Show("Ocorreu um erro, comunique o suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            tabPage2.Focus();
        }

        private void lblAnuncio_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void picBoxRodape_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void comboBoxQt_Click(object sender, EventArgs e)
        {
            log.registrar("Botão comboBox quantidade foi clicado: " + comboBoxQt.Text);
        }

        private void picBoxFechar_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBoxTipo_Click(object sender, EventArgs e)
        {
            log.registrar("Botão comboBox selecionar tipo de pagamento foi clicado: " + comboBoxTipo.Text);
        }
    }
}
