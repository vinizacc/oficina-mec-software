using Braga;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Servico1
{
    public partial class FormDevedorCliente : Form
    {
        public FormDevedorCliente()
        {
            GlobalExceptionHandler.Attach(log);
            InitializeComponent();

            clickTimer = new Timer();
            clickTimer.Interval = 250;
            clickTimer.Tick += new EventHandler(clickTimer_Tick);
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

        private void clickTimer_Tick(object sender, EventArgs e)
        {
            btnAbrir.PerformClick();
            clickTimer.Stop();
        }

        public int privilegioAtual { get; set; }
        string idServico = "";
        private Timer clickTimer;
        bool paraTimer = true;
        string caminhoArqSelecionadoNoGrid = "";
        string dataHojeS;
        string dataSubtraida;
        Log log = new Log();
        public string caminhoENomeLog;

        private void FormDevedorCliente_Load(object sender, EventArgs e)
        {
            configurarTamanhoEPosicaoControles();
            ClientesDAO c = new ClientesDAO();
            txtProcuraNome.AutoCompleteCustomSource = c.autoCompleteSource(txtProcuraNome.Text);

            dataGridViewServicos.AutoGenerateColumns = true;
            btnPagou.Enabled = false;
            //comboBox.Text = "Dinheiro";
            comboBox.Items.Add("Dinheiro");
            comboBox.Items.Add("Débito");
            comboBox.Items.Add("Crédito");
            dataHojeS = DateTime.Today.ToString("dd/MM/yyyy");
            dataSubtraida = Convert.ToDateTime(dataHojeS).AddMonths(-1).ToString("dd/MM/yyyy");
            log.caminhoENome = caminhoENomeLog;
            log.registrar(log.barra + "Abrindo o formulário Cliente devedor" + log.barra);
            if(privilegioAtual == 1) 
            {
                log.registrar("Privilégio adm");
            }
            else
            {
                log.registrar("Privilégio comum");
            }
        }

        public void configurarTamanhoEPosicaoControles()
        {

            this.Size = new System.Drawing.Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.StartPosition = FormStartPosition.CenterScreen;

            dataGridViewServicos.Size = new System.Drawing.Size(this.Width / 2, this.Height - groupBox3.Height - 75);
            dataGridViewServicos.Location = new System.Drawing.Point(10, groupBox3.Height + 30);

            groupBox3.Width = dataGridViewServicos.Size.Width;
            groupBox3.Height = dataGridViewServicos.Location.Y - 15;

            groupBox3.Location = new System.Drawing.Point(10, 10);

            //foreach (Control control in groupBox3.Controls)
            //{
            //    if(control.Name != "label1")
            //    {
            //        int x = (groupBox3.Width - control.Width) / 2;
            //        int y = (groupBox3.Height - control.Height) / 2;
            //        control.Location = new System.Drawing.Point(x, y);
            //    }
            //}

            axAcroPDF1.Location = new System.Drawing.Point(this.Width - dataGridViewServicos.Width + 20, 10);
            axAcroPDF1.Size = new System.Drawing.Size(this.Width - dataGridViewServicos.Width - 45, dataGridViewServicos.Height + groupBox3.Height - 90);

            pictureBox1.BackColor = System.Drawing.Color.Azure;

            pictureBox1.Location = new System.Drawing.Point(axAcroPDF1.Location.X, axAcroPDF1.Height + 15);
            pictureBox1.Size = new System.Drawing.Size(axAcroPDF1.Width, 90);

            btnAbrir.Text = "Abrir";
            btnImprimir.Text = "Imprimir";

            btnAbrir.Size = new System.Drawing.Size(100, 35);
            btnAbrir.Location = new System.Drawing.Point(pictureBox1.Location.X + 15, pictureBox1.Location.Y + ((pictureBox1.Height / 2) - (btnAbrir.Height / 2)));
            btnImprimir.Size = new System.Drawing.Size(100, 35);
            btnImprimir.Location = new System.Drawing.Point(btnAbrir.Location.X + btnAbrir.Width + 10, btnAbrir.Location.Y);
            btnArquivo.Size = new System.Drawing.Size(100, 35);
            btnArquivo.Location = new System.Drawing.Point(btnImprimir.Location.X + 10 + btnImprimir.Width, btnAbrir.Location.Y);

            int afastador = 20;
            lblNome.Location = new System.Drawing.Point(15, lblNome.Height + lblNome.Height / 2);
            txtProcuraNome.Location = new System.Drawing.Point(lblNome.Location.X + lblNome.Width, lblNome.Location.Y);
            
            lblTipoPag.Location = new System.Drawing.Point(lblNome.Location.X, lblNome.Location.Y + lblNome.Height + afastador);
            comboBox.Location = new System.Drawing.Point(lblTipoPag.Location.X + lblTipoPag.Width, lblTipoPag.Location.Y);
            lblData.Location = new System.Drawing.Point(lblTipoPag.Location.X, lblTipoPag.Location.Y + lblTipoPag.Height + afastador);
            dateTimePicker.Location = new System.Drawing.Point(lblData.Location.X + lblData.Width, lblData.Location.Y);
            label5.Location = new System.Drawing.Point(lblData.Location.X, lblData.Location.Y + lblData.Height + afastador);
            lblDatas.Location = new System.Drawing.Point(label5.Location.X + label5.Width, label5.Location.Y);
            lblNomeArq.Location = new System.Drawing.Point(label5.Location.X, label5.Location.Y + label5.Height + 10);
            lblNomeArq.Text = "Arquivo da nota:";

            
            int btnPagouY = lblNomeArq.Location.Y;
            int btnPagouX = groupBox3.Width - btnPagou.Width - 15;
            int btnTodosX = btnPagouX - btnPagou.Width - 15;
            int btnProcurarX = btnTodosX - btnPagou.Width - 15;

            btnPagou.Location = new System.Drawing.Point(btnPagouX, btnPagouY);
            btnTodos.Location = new System.Drawing.Point(btnTodosX , btnPagouY);
            btnProcurar.Location = new System.Drawing.Point(btnProcurarX, btnPagouY);
        }

        BindingSource servicosBindingSource = new BindingSource();

        private int id_linha = -1;
        private void btnProcurar_Click(object sender, EventArgs e)
        {
            
            log.registrar("Botão PROCURAR foi clicado.");
            if (txtProcuraNome.Text != "" && comboBox.SelectedIndex < 0)
            {
                if (Regex.IsMatch(txtProcuraNome.Text, @"^[a-zA-Z\s]+$"))
                {
                    //MessageBox.Show("V-F");
                    List<JObject> listaSemFiltro = new List<JObject>();
                    ServicosDAO servicosDAO = new ServicosDAO();
                    listaSemFiltro = servicosDAO.getServicoByNameNaoPago(txtProcuraNome.Text);
                    log.registrar("Pesquisa pelo nome: " + txtProcuraNome.Text);

                    if (privilegioAtual == 1)
                    {
                        servicosBindingSource.DataSource = listaSemFiltro;
                        dataGridViewServicos.DataSource = servicosBindingSource.List;
                        
                        
                    }
                    else if (privilegioAtual == 0)
                    {
                        
                        List<JObject> listaFiltrada = new List<JObject>();
                        foreach (JObject item in listaSemFiltro)
                        {
                            if ((string)item["DATA"] == dataHojeS || (string)item["DATA"] == dataSubtraida)
                            {
                                listaFiltrada.Add(item);
                            }
                        }
                        servicosBindingSource.DataSource = listaFiltrada;
                        dataGridViewServicos.DataSource = servicosBindingSource.List;
                        
                    }
                    configuraColunas();
                }
                else
                {
                    MessageBox.Show("Só pode letras ao procurar por NOME.", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    log.registrar("Foi pesquisado errado: "+ txtProcuraNome.Text);
                }
            }
            else if (txtProcuraNome.Text == "" && comboBox.SelectedIndex >= 0)
            {
                //MessageBox.Show("F-V");
                ServicosDAO servicosDAO = new ServicosDAO();
                
                List<JObject> listaSemFiltro = new List<JObject>();
                listaSemFiltro = servicosDAO.getServicosByPaymentTypeNaoPago(comboBox.SelectedIndex);
                log.registrar("Busca por tipo de pagamento. Tipo: " + comboBox.SelectedText);
                if (privilegioAtual == 1)
                {
                    servicosBindingSource.DataSource = listaSemFiltro;
                    dataGridViewServicos.DataSource = servicosBindingSource.List;
                    
                    
                }
                else if (privilegioAtual == 0)
                {
                    log.registrar("Privilégio atual comum.");
                    List<JObject> listaFiltrada = new List<JObject>();
                    foreach (JObject item in listaSemFiltro)
                    {
                        if ((string)item["DATA"] == dataHojeS || (string)item["DATA"] == dataSubtraida)
                        {
                            listaFiltrada.Add(item);
                        }
                    }
                    servicosBindingSource.DataSource = listaFiltrada;
                    dataGridViewServicos.DataSource = servicosBindingSource.List;
                    
                }
                configuraColunas();

            }
            else if (txtProcuraNome.Text != "" && comboBox.SelectedIndex >= 0)
            {

                if (Regex.IsMatch(txtProcuraNome.Text, @"^[a-zA-Z\s]+$"))
                {
                    //MessageBox.Show("V-V");

                    ServicosDAO servicosDAO = new ServicosDAO();
                    ;

                    List<JObject> listaSemFiltro = new List<JObject>();
                    listaSemFiltro = servicosDAO.getServicosByNameAndPaymentTypeNaoPago(txtProcuraNome.Text, comboBox.SelectedIndex);
                    log.registrar("Busca por nome e tipo de pagamento. Nome: " + txtProcuraNome.Text + " Tipo: " + comboBox.SelectedText);
                    if (privilegioAtual == 1)
                    {
                        
                        servicosBindingSource.DataSource = listaSemFiltro;
                        dataGridViewServicos.DataSource = servicosBindingSource.List;
                        
                    }
                    else if (privilegioAtual == 0)
                    {
                        
                        List<JObject> listaFiltrada = new List<JObject>();
                        foreach (JObject item in listaSemFiltro)
                        {
                            if ((string)item["DATA"] == dataHojeS || (string)item["DATA"] == dataSubtraida)
                            {
                                listaFiltrada.Add(item);
                            }
                        }
                        servicosBindingSource.DataSource = listaFiltrada;
                        dataGridViewServicos.DataSource = servicosBindingSource.List;
                        
                    }
                    configuraColunas();
                }
                else
                {
                    MessageBox.Show("Só pode letras ao procurar por NOME.", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                }
            }
            else
            {
                //MessageBox.Show("F-F");
            }

            comboBox.Text = "";
            comboBox.SelectedIndex = -1;
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            log.registrar("Botão TODOS foi clicado.");
            ServicosDAO servicosDAO = new ServicosDAO();

            if(privilegioAtual == 1)
            {
                
                servicosBindingSource.DataSource = servicosDAO.getAllServicosNaoPago();
                dataGridViewServicos.DataSource = servicosBindingSource.List;
                
            }
            else if(privilegioAtual == 0)
            {
                
                try
                {
                    List<JObject> listaJObject = new List<JObject>();

                    listaJObject = servicosDAO.getServicosByExactDatesNaoPago(Convert.ToDateTime(dataSubtraida), Convert.ToDateTime(dataHojeS));
                    servicosBindingSource.DataSource = listaJObject;
                    dataGridViewServicos.DataSource = servicosBindingSource.List;
                    
                }
                catch (Exception)
                {

                    throw;
                }
                
            }

            configuraColunas();
        }

        public void configuraColunas()
        {
            if (dataGridViewServicos.Columns.Count != 0)
            {
                //dataGridViewServicos.Columns.Remove("ID_N_SERVICO");
                dataGridViewServicos.Columns["ID_N_SERVICO"].Visible = false;
                dataGridViewServicos.Columns["NOME"].HeaderText = "Nome";
                dataGridViewServicos.Columns["TIPO_PAG"].HeaderText = "Tipo de pagamento";
                dataGridViewServicos.Columns["VALOR_PAGO"].HeaderText = "Valor pago";
                dataGridViewServicos.Columns["VALOR_TOTAL"].HeaderText = "Valor total";
                dataGridViewServicos.Columns["DATA"].HeaderText = "Data de serviço";
                dataGridViewServicos.Columns["NUM_NOTA"].HeaderText = "Núm da nota";
                ModifyCellValueMoney();
            }
        }
        public string dataHoje()
        {
            string hoje = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss");
            return hoje;
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

        private void dateTimePicker_MouseDown(object sender, MouseEventArgs e)
        {
            log.registrar("Botão SELEÇÃO POR DATA clicado.");
            bool estaAberto = jaEstaAberto(typeof(FormData));
            if (estaAberto == false)
            {
                FormData formData = new FormData();
                log.registrar("O formulário por datas será aberto.");
                formData.caminhoENomeLog = caminhoENomeLog;
                formData.ShowDialog(this);

                List<DateTime> listaDatas = new List<DateTime>
                {
                    formData.dataInicial,
                    formData.dataFinal
                };

                //string dataResolvida = resolveDate(formData.ToString("");

                lblDatas.Text = formData.dataInicial.ToString("dd/MM/yyyy") + " - " + formData.dataFinal.ToString("dd/MM/yyyy");
                lblDatas.BackColor = System.Drawing.Color.SpringGreen;
                
                ServicosDAO servicosDAO = new ServicosDAO();

                List<JObject> listaSemFiltro = new List<JObject>();
                listaSemFiltro = servicosDAO.getServicosByDatesNaoPago(listaDatas);

                if (privilegioAtual == 1)
                {
                    servicosBindingSource.DataSource = listaSemFiltro;
                    dataGridViewServicos.DataSource = servicosBindingSource.List;
                    
                }
                else if (privilegioAtual == 0)
                {
                    List<JObject> listaFiltrada = new List<JObject>();
                    foreach (JObject item in listaSemFiltro)
                    {
                        if ((string)item["DATA"] == dataHojeS || (string)item["DATA"] == dataSubtraida)
                        {
                            listaFiltrada.Add(item);
                        }
                    }
                    servicosBindingSource.DataSource = listaFiltrada;
                    dataGridViewServicos.DataSource = servicosBindingSource.List;
                    
                }
                configuraColunas();

            }
        }
        private void dataGridViewServicos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 2)
            {
                string valor = Convert.ToString(dataGridViewServicos.Rows[e.RowIndex].Cells[2].Value);
                if (valor == "Dinheiro")
                {
                    dataGridViewServicos.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                }
                else if (valor == "Débito")
                {
                    dataGridViewServicos.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.SkyBlue;
                }
                else
                {
                    dataGridViewServicos.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                }
            }
        }

        private void ModifyCellValueMoney()
        {
            for (int i = 0; i < dataGridViewServicos.Rows.Count; i++)
            {
                string valor = Convert.ToString(dataGridViewServicos.Rows[i].Cells[3].Value);
                dataGridViewServicos.Rows[i].Cells[3].Value = "R$" + valor;
            }

            for (int i = 0; i < dataGridViewServicos.Rows.Count; i++)
            {
                string valor = Convert.ToString(dataGridViewServicos.Rows[i].Cells[4].Value);
                dataGridViewServicos.Rows[i].Cells[4].Value = "R$" + valor;
            }
            dataGridViewServicos.Refresh();
        }

        private void btnPagou_Click(object sender, EventArgs e)
        {
            log.registrar("Botão PAGOU foi clicado.");
            if (id_linha != -1)
            {
                log.registrar("O registro de venda com ID " + id_linha + " foi dado como pago.");

                ServicosDAO servicos = new ServicosDAO();
                servicosBindingSource.DataSource = servicos.changeStatusPagou(id_linha);
                dataGridViewServicos.DataSource = servicosBindingSource;

                configuraColunas();
                btnPagou.Enabled = false;
                idServico = "";

            }
            else
            {
                btnPagou.Enabled = false;
            }
        }

        private void dataGridViewServicos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            id_linha = Convert.ToInt32(dataGridViewServicos.Rows[e.RowIndex].Cells[0].Value);
            ServicosDAO servicosDAO = new ServicosDAO();
            FolderControl f = new FolderControl();
            caminhoArqSelecionadoNoGrid = f.absolutePathOfPdf(servicosDAO.getPathByIdServico(id_linha.ToString()));

            lblNomeArq.Text = "Arquivo da nota: " + f.fileName(caminhoArqSelecionadoNoGrid);
            log.registrar("Uma celula da lista foi clicada. ID SERVIÇO: " + id_linha.ToString() + " ARQ: "+ lblNomeArq.Text);
            btnPagou.Enabled = true;
        }

        private void dataGridViewServicos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            log.registrar("Botão ABRIR clicado.");
            if (paraTimer)
            {
                clickTimer.Start();
                paraTimer = false;
            }

            if (idServico != "")
            {
                ServicosDAO servicoDAO = new ServicosDAO();
                string path = servicoDAO.getPathByIdServico(idServico);
                FolderControl fc = new FolderControl();
                log.registrar("O caminho para o arquivo da venda: "+ path);
                axAcroPDF1.src = fc.absolutePathOfPdf(path);
                axAcroPDF1.setZoom(80);
                axAcroPDF1.setShowScrollbars(true);
            }

        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            log.registrar("Botão IMPRIMIR clicado.");
            if (idServico != "")
            {
                DialogResult dialogResult = MessageBox.Show("Deseja imprimir?", "Deletar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    //axAcroPDF1.printWithDialog();
                    try
                    {
                        axAcroPDF1.printAll();
                        log.registrar("Imprimiu.");
                    }
                    catch (Exception ex)
                    {
                        log.registrar("Impressão deu erro. Mensagem do erro: " + ex.Message);
                        MessageBox.Show(ex.Message,"Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
                else
                {
                    log.registrar("Cancelou a impressão.");
                }
            }
        }

        private void dataGridViewServicos_RowLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewServicos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewServicos.Rows[e.RowIndex];

                idServico = row.Cells[0].Value.ToString();
            }
        }

        private void dataGridViewServicos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            log.registrar("Foi clicado duas vezes em uma célula da lista.");
            btnAbrir.PerformClick();
        }

        private void btnArquivo_Click(object sender, EventArgs e)
        {
            log.registrar("Botão CAMINHO (btnArquivo) clicado.");
            string caminhoSemNomeArq = "";

            if (caminhoArqSelecionadoNoGrid != "")
            {
                FolderControl f = new FolderControl();
                caminhoSemNomeArq = f.filePath(caminhoArqSelecionadoNoGrid);
                log.registrar("Caminho da venda: " + caminhoArqSelecionadoNoGrid);
            }
            else
            {
                log.registrar("Não foi selecionado nenhuma venda.");
            }
            if (System.IO.Directory.Exists(caminhoSemNomeArq))
            {
                // Abre a pasta no Explorer
                Process.Start("explorer.exe", caminhoSemNomeArq);
                log.registrar("Caminho da pasta da venda: " + caminhoSemNomeArq);
            }
            else
            {
                log.registrar("Pasta inexistente.");
                MessageBox.Show("A pasta não existe.");
            }
        }

        private void txtProcuraNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormDevedorCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            log.registrar(log.barra);
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
