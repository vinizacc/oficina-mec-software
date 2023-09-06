using Braga;
using Google.Protobuf.WellKnownTypes;
using Syncfusion.Windows.Forms.Collections;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Application = System.Windows.Forms.Application;

namespace Servico1
{
    public partial class FormPeriodo : Form
    {
        public FormPeriodo()
        {
            GlobalExceptionHandler.Attach(log);
            InitializeComponent();
            clickTimer = new Timer();
            clickTimer.Interval = 250; // Intervalo de 1 segundo
            clickTimer.Tick += new EventHandler(clickTimer_Tick);
        }

        private void clickTimer_Tick(object sender, EventArgs e)
        {
            clickTimer.Stop();
        }

        string idServico = "";
        private Timer clickTimer;
        string dataInicial;
        string dataFinal;
        Log log = new Log();
        public string caminhoENomeLog;
        private void FormPeriodo_Load(object sender, EventArgs e)
        {
            log.caminhoENome = caminhoENomeLog;
            log.registrar(log.barra + "O formulário Vendas Por Periodo foi aberto" + log.barra);
            configurarTamanhoEPosicaoControles();
            //configurarEventos(this);
            controles();
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

        //public void configurarEventos(Control control)
        //{
        //    if (control == label1 || control == label2 || control == label3 || control == label4 || control == label5 || control == label6 || control == label8)
        //    {
        //        control.TextChanged += new System.EventHandler(posicaoValores);
        //    }
        //}

        //public void posicaoValores(object sender, System.EventArgs e)
        //{
        //    Control control = (Control)sender;
        //    control.Location = new System.Drawing.Point(groupBox3.Width - control.Width - 40, control.Location.Y);
        //}

        public void configurarTamanhoEPosicaoControles()
        {

            this.Size = new System.Drawing.Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.StartPosition = FormStartPosition.CenterScreen;

            groupBox3.Size = new System.Drawing.Size(this.Size.Width / 5 + 40, this.Size.Height - 62);
            groupBox3.Location = new System.Drawing.Point(10, 10);

            dataGridViewServicos.Size = new System.Drawing.Size(this.Width - (this.Width / 4), this.Height / 3);
            dataGridViewServicos.Location = new System.Drawing.Point(15 + groupBox3.Width, chart1.Location.Y + chart1.Height + 25);
            //dataGridViewServicos.Anchor = anchor

            lblTotalPago.Text = "Total pago: ";
            lblTotal.Text = "Total: ";
            lblNPago.Text = "Não pago: ";
            lblServicoTotal.Text = "Total serviços: ";
            lblServicoPago.Text = "Serviços pagos: ";
            lblN.Text = "Serviços não pagos: ";
            lblNota.Text = "Notas por período: ";
            
            
            int LocationXLetras = groupBox3.Location.X + (groupBox3.Width / 2) - lblTotalPago.Width - 35;
            int LocationYLetras = groupBox3.Location.Y + lblTotalPago.Height;

            lblTotalPago.Location = new System.Drawing.Point(LocationXLetras, LocationYLetras);
            lblTotal.Location = new System.Drawing.Point(LocationXLetras, LocationYLetras + lblTotalPago.Location.Y - 3);
            lblNPago.Location = new System.Drawing.Point(LocationXLetras, LocationYLetras + lblTotal.Location.Y - 3);
            lblServicoTotal.Location = new System.Drawing.Point(LocationXLetras, LocationYLetras + lblNPago.Location.Y - 3);
            lblServicoPago.Location = new System.Drawing.Point(LocationXLetras, LocationYLetras + lblServicoTotal.Location.Y - 3);
            lblN.Location = new System.Drawing.Point(LocationXLetras, LocationYLetras + lblServicoPago.Location.Y - 3);
            lblNota.Location = new Point(LocationXLetras, LocationYLetras + lblN.Location.Y - 3);

            int valorPosicaoX = groupBox3.Width - 150;

            label1.Location = new System.Drawing.Point(valorPosicaoX, lblTotalPago.Location.Y);
            label2.Location = new System.Drawing.Point(valorPosicaoX, lblTotal.Location.Y);
            label3.Location = new System.Drawing.Point(valorPosicaoX, lblNPago.Location.Y);
            label4.Location = new System.Drawing.Point(valorPosicaoX, lblServicoTotal.Location.Y);
            label5.Location = new System.Drawing.Point(valorPosicaoX, lblServicoPago.Location.Y);
            label6.Location = new System.Drawing.Point(valorPosicaoX, lblN.Location.Y);
            label8.Location = new System.Drawing.Point(valorPosicaoX, lblNota.Location.Y);
            

            lblIntervalo.Location = new Point(LocationXLetras, lblN.Location.Y + lblN.Height + 50);
            cBoxIntevalo.Location = new Point(LocationXLetras, lblIntervalo.Location.Y + lblIntervalo.Height + 5);
            cBoxIntevalo.Width = lblIntervalo.Width * 2;

            lblMI.Location = new Point(LocationXLetras, cBoxIntevalo.Location.Y + cBoxIntevalo.Height + 8);
            cBoxMI.Location = new Point(LocationXLetras, lblMI.Location.Y + lblMI.Height + 3);

            lblMF.Location = new Point(LocationXLetras, cBoxMI.Location.Y + cBoxMI.Height + 8);
            cBoxMF.Location = new Point(LocationXLetras, lblMF.Location.Y + lblMF.Height + 3);

            int xAnos = cBoxIntevalo.Width ;

            lblAI.Location = new Point(xAnos, lblMI.Location.Y);
            numI.Location = new Point(xAnos, cBoxMI.Location.Y + 1);
            numI.Value = Convert.ToDecimal(DateTime.Now.ToString("yyyy")) - 1;

            lblAF.Location = new Point(xAnos, lblMF.Location.Y);
            numF.Location = new Point(xAnos, cBoxMF.Location.Y + 1);
            numF.Value = Convert.ToDecimal(DateTime.Now.ToString("yyyy"));

            cBoxIntevalo.Items.Add("Mensal");
            cBoxIntevalo.SelectedIndex = 0;
            cBoxIntevalo.DropDownStyle = ComboBoxStyle.DropDownList;
            cBoxIntevalo.Items.Add("Anual");

            cBoxMI.Items.Add("Não informado");
            cBoxMI.SelectedIndex = 0;
            cBoxMI.DropDownStyle = ComboBoxStyle.DropDownList;

            cBoxMF.Items.Add("Não informado");
            cBoxMF.SelectedIndex = 0;
            cBoxMF.DropDownStyle = ComboBoxStyle.DropDownList;

            List<ComboBox> c = new List<ComboBox>();
            c.Add(cBoxMI);
            c.Add(cBoxMF);

            foreach (ComboBox combo in c)
            {
                combo.Items.Add("Janeiro");
                combo.Items.Add("Fevereiro");
                combo.Items.Add("Março");
                combo.Items.Add("Abril");
                combo.Items.Add("Maio");
                combo.Items.Add("Junho");
                combo.Items.Add("Julho");
                combo.Items.Add("Agosto");
                combo.Items.Add("Setembro");
                combo.Items.Add("Outubro");
                combo.Items.Add("Novembro");
                combo.Items.Add("Dezembro");
            }

            cBoxTipoPag.Items.Add("Qualquer tipo de pagamento");
            cBoxTipoPag.SelectedIndex = 0;
            cBoxTipoPag.DropDownStyle = ComboBoxStyle.DropDownList;
            cBoxTipoPag.Items.Add("Dinheiro");
            cBoxTipoPag.Items.Add("Débito");
            cBoxTipoPag.Items.Add("Crédito");

            cBoxStatus.Items.Add("Qualquer status de pagamento");
            cBoxStatus.SelectedIndex = 0;
            cBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cBoxStatus.Items.Add("Pago");
            cBoxStatus.Items.Add("Não pago");

            cBoxTipoPag.Width = cBoxIntevalo.Width;

            lblTipoPag.Location = new Point(LocationXLetras, numF.Location.Y + numF.Height + 15 + lblTipoPag.Height);
            cBoxTipoPag.Location = new Point(LocationXLetras, lblTipoPag.Location.Y + lblTipoPag.Height + 5);

            lblStatus.Location = new Point(LocationXLetras, cBoxTipoPag.Location.Y + cBoxTipoPag.Height + 12);
            cBoxStatus.Location = new Point(LocationXLetras, lblStatus.Location.Y + lblStatus.Height + 5);
            cBoxStatus.Width = cBoxTipoPag.Width;

            pBoxPesquisar.Height = 75;
            pBoxPesquisar.Width = cBoxTipoPag.Width;
            pBoxPesquisar.Location = new Point(cBoxTipoPag.Location.X, lblStatus.Location.Y + 70);


            int lbly = pBoxPesquisar.Location.Y + (pBoxPesquisar.Height / 2 - lblPesquisar.Height / 2);
            int lblx = pBoxPesquisar.Location.X + (pBoxPesquisar.Width / 2 - lblPesquisar.Width / 2);

            lblPesquisar.Location = new Point(lblx, lbly);

            label7.Location = new Point(pBoxPesquisar.Location.X, lbly + lblPesquisar.Height + cBoxGrafico.Height + 20);
            cBoxGrafico.Location = new Point(pBoxPesquisar.Location.X, label7.Location.Y + cBoxGrafico.Height - 2); ;
            cBoxGrafico.Items.Add("Coluna");
            cBoxGrafico.SelectedIndex = 0;
            cBoxGrafico.DropDownStyle = ComboBoxStyle.DropDownList;
            cBoxGrafico.Items.Add("Coluna 2");
            cBoxGrafico.Items.Add("Linha");
            cBoxGrafico.Items.Add("Circulo");

            chart1.Location = new Point(dataGridViewServicos.Location.X, groupBox3.Location.Y);
            chart1.Size = new Size(dataGridViewServicos.Width, this.Height - dataGridViewServicos.Height - 67);
            log.registrar("Formulário configurou todos controles");
        }

        private void groupBox3_Paint(object sender, PaintEventArgs e)
        {
            // Obtém o objeto Graphics do GroupBox
            Graphics g = e.Graphics;

            // Define a cor e a largura da linha
            Pen pen = new Pen(Color.LightGray, 1);

            // Obtém as coordenadas X e Y da metade da altura do GroupBox
            int x = groupBox3.Width / 2;
            int y = lblNota.Location.Y + lblNota.Height + 10;
            int yy = numF.Location.Y + numF.Height + 15;

            // Desenha a linha
            g.DrawLine(pen, 20, y, groupBox3.Width - 20, y);
            g.DrawLine(pen, 20, yy, groupBox3.Width - 20, yy);
        }

        public DataTable puxarDados()
        {
            ServicosDAO sDAO = new ServicosDAO();

            DataTable dt = new DataTable();
            dt = sDAO.getListaByDates(dataInicial, dataFinal, cBoxTipoPag.Text, cBoxStatus.Text);

            if (dt.Columns.Count > 0)
            {
                ServicosDAO servicosDAO = new ServicosDAO();
                configurarDados(dt);
                servicosBindingSource.DataSource = dt;
                dataGridViewServicos.DataSource = servicosBindingSource.List;
                configurarDGV();
            }
            return dt;
        }

        public void controles()
        {
            string c = "";
            //chart1 
            //datagridview
            //groupBox3
            groupBox3.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            chart1.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            dataGridViewServicos.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;

            foreach (Control item in groupBox3.Controls)
            {
                c += "\nnome: " + item.Name.ToString();
                item.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            }
            //MessageBox.Show(c);
        }

        public void configurarDados(DataTable dt)
        {

            dt.Columns.Add("PAGO_NEW", typeof(string));
            dt.Columns.Add("VT_NEW", typeof(string));
            dt.Columns.Add("VP_NEW", typeof(string));
            dt.Columns.Add("TIPO", typeof(string));
            dt.Columns.Add("DT", typeof(string));
            foreach (DataRow row in dt.Rows)
            {
                row["PAGO_NEW"] = row.Field<int>("PAGO").ToString();
                row["VT_NEW"] = row.Field<double>("VALOR_TOTAL").ToString();
                row["VP_NEW"] = row.Field<double>("VALOR_PAGO").ToString();
                row["TIPO"] = row.Field<int>("TIPO_PAG").ToString();
                row["DT"] = row.Field<DateTime>("DATA").ToString();
            }

            dt.Columns.Remove("VALOR_TOTAL");
            dt.Columns.Remove("VALOR_PAGO");
            dt.Columns.Remove("PAGO");
            dt.Columns.Remove("TIPO_PAG");
            dt.Columns.Remove("DATA");
            dt.Columns["PAGO_NEW"].ColumnName = "PAGO";
            dt.Columns["VT_NEW"].ColumnName = "VALOR_TOTAL";
            dt.Columns["VP_NEW"].ColumnName = "VALOR_PAGO";
            dt.Columns["TIPO"].ColumnName = "TIPO_PAG";
            dt.Columns["DT"].ColumnName = "DATA";
            foreach (DataRow item in dt.Rows)
            {

                string pago = item.Field<string>("PAGO");
                if (pago == "1") { pago = "Pago"; }
                else if (pago == "0") { pago = "Não pago"; }
                item.SetField<string>("PAGO", pago);

                string date = item.Field<string>("DATA");
                string dateC = Convert.ToDateTime(date).ToString("d/M/yyyy");
                item.SetField<string>("DATA", dateC);

                string valorP = item.Field<string>("VALOR_PAGO");
                item.SetField<string>("VALOR_PAGO", "R$" + valorP);

                string valorT = item.Field<string>("VALOR_TOTAL");
                item.SetField<string>("VALOR_TOTAL", "R$" + valorT);

                string tipo = item.Field<string>("TIPO_PAG");
                if (tipo == "0") { tipo = "Dinheiro"; }
                else if (tipo == "1") { tipo = "Débito"; }
                else if (tipo == "2") { tipo = "Crédito"; }
                item.SetField<string>("TIPO_PAG", tipo);
            }
        }
        public void configurarDGV()
        {
            if (dataGridViewServicos.Columns.Count != 0)
            {

                //dataGridViewServicos.Columns.Remove("ID_N_SERVICO");
                dataGridViewServicos.Columns["NOME"].HeaderText = "Nome";
                dataGridViewServicos.Columns["DATA"].HeaderText = "Data de serviço";
                ////dataGridViewServicos.Columns["ID_N_SERVICO"].Visible = false;
                dataGridViewServicos.Columns["VALOR_PAGO"].HeaderText = "Valor pago";
                dataGridViewServicos.Columns["VALOR_TOTAL"].HeaderText = "Valor total";
                dataGridViewServicos.Columns["TIPO_PAG"].HeaderText = "Tipo de pagamento";
                dataGridViewServicos.Columns["PAGO"].HeaderText = "Pago";
                //dataGridViewServicos.Columns["NOME_ARQ"].Visible = false;
                //dataGridViewServicos.Columns["LISTA_DADOS"].Visible = false;
                //dataGridViewServicos.Columns["NUM_NOTA"].Visible = false;
                //dataGridViewServicos.Columns["ID_CLIENTE"].Visible = false;

            }
        }

        public void determinaDatasParaPesquisa()
        {
            string anoInicial = numI.Value.ToString();
            string anoFinal = numF.Value.ToString();
            string mesInicial, mesFinal, diaInicial, diaFinal;

            if (cBoxMI.SelectedIndex == 0)
            {
                mesInicial = "1";
            }
            else
            {
                mesInicial = cBoxMI.SelectedIndex.ToString();
            }

            if (cBoxMF.SelectedIndex == 0)
            {
                mesFinal = "12";
            }
            else
            {
                mesFinal = cBoxMF.SelectedIndex.ToString();
            }

            diaFinal = DateTime.DaysInMonth(Convert.ToInt32(anoFinal), Convert.ToInt32(mesFinal)).ToString();

            dataInicial = anoInicial + "-" + mesInicial + "-1";
            dataFinal = anoFinal + "-" + mesFinal + "-" + diaFinal;
            
        }

        public void pesquisar()
        {
           
            determinaDatasParaPesquisa();
            DataTable dt1 = new DataTable();
            DataTable dtGrafico = new DataTable();
            dt1 = puxarDados();
            dtGrafico = dt1.Copy();

            dtGrafico.Columns.Remove("NOME");
            dtGrafico.Columns.Remove("PAGO");
            dtGrafico.Columns.Remove("TIPO_PAG");

            //Configurar os campos label.
            double valorT = 0;
            double valorP = 0;
            int servPago = 0;
            int servNPago = 0;
            foreach (DataRow item in dt1.Rows)
            {
                item.SetField<string>("VALOR_TOTAL", item.Field<string>("VALOR_TOTAL").Substring(2));
                item.SetField<string>("VALOR_PAGO", item.Field<string>("VALOR_PAGO").Substring(2));
                valorT += Convert.ToDouble(item.Field<string>("VALOR_TOTAL"));
                valorP += Convert.ToDouble(item.Field<string>("VALOR_PAGO"));
                if (item.Field<string>("PAGO") == "Pago") { servPago++; }
                else { servNPago++; }
            }

            double valorN = valorT - valorP;
            int servTotal = servPago + servNPago;
            CalculoValor v = new CalculoValor();
            
            label1.Text = v.calcularpontoflutuante(valorP.ToString());
            label2.Text = v.calcularpontoflutuante(valorT.ToString());
            label3.Text = v.calcularpontoflutuante(valorN.ToString());
            label4.Text = servTotal.ToString();
            label5.Text = servPago.ToString();
            label6.Text = servNPago.ToString();
            label8.Text = servTotal.ToString();
            //DataTable infos = new DataTable();
            //infos.Columns.Add("", typeof(string));
            //infos.Columns.Add("Mes", typeof(string));
            //-------------------------------------
            
            //Remove o R$ dos campos de valores
            foreach (DataRow item in dtGrafico.Rows)
            {
                string valorTS = item.Field<string>("VALOR_TOTAL");
                string valorPagoS = item.Field<string>("VALOR_PAGO");

                item.SetField<string>("VALOR_TOTAL", valorTS.Substring(2));
                item.SetField<string>("VALOR_PAGO", valorPagoS.Substring(2));

            }

            if (cBoxIntevalo.SelectedIndex == 0)
            {
                //Converte o dado para data cursiva.
                foreach (DataRow item in dtGrafico.Rows)
                {
                    string dataString = item.Field<string>("DATA");
                    //DateTime data = DateTime.ParseExact(dataString, "dd/MM/yyyy", null);
                    DateTime d = new DateTime();
                    d = Convert.ToDateTime(dataString);
                    string mesCursivo = d.ToString("MMMM");
                    mesCursivo = mesCursivo.Substring(0, 1).ToUpper() + mesCursivo.Substring(1);
                    item.SetField<string>("DATA", mesCursivo);

                }

                //Soma os dois campos por data
                var vendasPorMes = dtGrafico.AsEnumerable()
                         .GroupBy(row => row.Field<string>("DATA"))
                         .Select(group => new
                         {
                             Mes = group.Key,
                             ValorTotal = group.Sum(row => Convert.ToDouble(row.Field<string>("VALOR_TOTAL"))),
                             ValorPago = group.Sum(row => Convert.ToDouble(row.Field<string>("VALOR_PAGO")))
                         });

                // criar uma nova tabela com as somas das vendas por mês
                DataTable novaTabela = new DataTable();
                novaTabela.Columns.Add("Mes", typeof(string));
                novaTabela.Columns.Add("ValorTotal", typeof(double));
                novaTabela.Columns.Add("ValorPago", typeof(double));
                novaTabela.Columns.Add("NPago", typeof(double));

                // adicionar os dados na nova tabela
                foreach (var vendaPorMes in vendasPorMes)
                {
                    DataRow row = novaTabela.NewRow();
                    row["Mes"] = vendaPorMes.Mes;
                    row["ValorTotal"] = vendaPorMes.ValorTotal;
                    row["ValorPago"] = vendaPorMes.ValorPago;
                    row["NPago"] = vendaPorMes.ValorTotal - vendaPorMes.ValorPago;
                    novaTabela.Rows.Add(row);
                }


                //Cria uma coluna/linha para inserir no gráfico e inseri os dados
                Series series = new Series();
                series.Name = "Vendas - total";
                series.ChartType = SeriesChartType.Column;
                series.Points.DataBind(novaTabela.AsEnumerable(), "Mes", "ValorTotal", "");

                //Cria outra coluna/linha para inserir no gráfico e inseri os dados
                Series series1 = new Series();
                series1.Name = "Vendas - pago";
                series1.ChartType = SeriesChartType.Column;
                series1.Points.DataBind(novaTabela.AsEnumerable(), "Mes", "ValorPago", "");

                //Cria outra coluna/linha para inserir no gráfico e inseri os dados
                Series series2 = new Series();
                series2.Name = "Vendas - não pago";
                series2.ChartType = SeriesChartType.Column;
                series2.Points.DataBind(novaTabela.AsEnumerable(), "Mes", "NPago", "");

                //Cria a área do gráfico e configura o X e Y
                ChartArea chartArea1 = new ChartArea();
                chartArea1.AxisX.Title = "Mes";
                chartArea1.AxisY.Title = "Valores";

                //Definir o tamanho e posição da ChartArea
                chartArea1.Position.Width = 0;
                chartArea1.Position.Height = 100;
                chartArea1.Position.X = 2;
                chartArea1.Position.Y = 2;

                // Adicionar a ChartArea ao Chart
                chart1.ChartAreas.Add(chartArea1);

                //Limpa os gráficos
                chart1.Series.Clear();

                //Adiciona as colunas de dados no gráfico
                chart1.Series.Add(series);
                chart1.Series.Add(series1);
                chart1.Series.Add(series2);

                chart1.Show();

            }
            else
            {
                foreach (DataRow item in dtGrafico.Rows)
                {
                    DateTime a = Convert.ToDateTime(item.Field<string>("DATA"));
                    item.SetField<string>("DATA", a.Year.ToString());

                }

                // agrupar as vendas por ano usando a função GroupBy
                var vendasPorAno = dtGrafico.AsEnumerable()
                                    .GroupBy(row => row.Field<string>("DATA"))
                                    .Select(group => new
                                    {
                                        Ano = group.Key,
                                        ValorTotal = group.Sum(row => Convert.ToDouble(row.Field<string>("VALOR_TOTAL"))),
                                        ValorPago = group.Sum(row => Convert.ToDouble(row.Field<string>("VALOR_PAGO")))
                                    });

                // criar uma nova tabela com as somas das vendas por ano
                DataTable novaTabela = new DataTable();
                novaTabela.Columns.Add("Ano", typeof(int));
                novaTabela.Columns.Add("ValorTotal", typeof(double));
                novaTabela.Columns.Add("ValorPago", typeof(double));
                novaTabela.Columns.Add("NPago", typeof(double));

                // adicionar os dados na nova tabela
                foreach (var vendaPorAno in vendasPorAno)
                {
                    DataRow row = novaTabela.NewRow();
                    row["Ano"] = vendaPorAno.Ano;
                    row["ValorTotal"] = vendaPorAno.ValorTotal;
                    row["ValorPago"] = vendaPorAno.ValorPago;
                    row["NPago"] = vendaPorAno.ValorTotal - vendaPorAno.ValorPago;
                    novaTabela.Rows.Add(row);
                }

                // exibir a nova tabela
                foreach (DataRow row in novaTabela.Rows)
                {
                    //MessageBox.Show(row["Ano"].ToString() + "  " + row["ValorTotal"] + "  " + row["ValorPago"]);
                }


                //Cria uma coluna/linha para inserir no gráfico e inseri os dados
                Series series = new Series();
                series.Name = "Vendas - total";
                series.ChartType = SeriesChartType.Column;
                series.Points.DataBind(novaTabela.AsEnumerable(), "Ano", "ValorTotal", "");

                //Cria outra coluna/linha para inserir no gráfico e inseri os dados
                Series series1 = new Series();
                series1.Name = "Vendas - pago";
                series1.ChartType = SeriesChartType.Column;
                series1.Points.DataBind(novaTabela.AsEnumerable(), "Ano", "ValorPago", "");

                //Cria outra coluna/linha para inserir no gráfico e inseri os dados
                Series series2 = new Series();
                series2.Name = "Vendas - não pago";
                series2.ChartType = SeriesChartType.Column;
                series2.Points.DataBind(novaTabela.AsEnumerable(), "Ano", "NPago", "");

                //Cria a área do gráfico e configura o X e Y
                ChartArea chartArea1 = new ChartArea();
                chartArea1.AxisX.Title = "Anos";
                chartArea1.AxisY.Title = "Valores";

                //Definir o tamanho e posição da ChartArea
                chartArea1.Position.Width = 0;
                chartArea1.Position.Height = 100;
                chartArea1.Position.X = 2;
                chartArea1.Position.Y = 2;

                // Adicionar a ChartArea ao Chart
                chart1.ChartAreas.Add(chartArea1);

                //Limpa os gráficos
                chart1.Series.Clear();

                //Adiciona as colunas de dados no gráfico
                chart1.Series.Add(series);
                chart1.Series.Add(series1);
                chart1.Series.Add(series2);

                chart1.Show();

            }

            //Configura tipos de dados do grafico
            if (cBoxGrafico.Text == "Coluna")
            {
                foreach (Series s in chart1.Series)
                {
                    s.ChartType = SeriesChartType.Column;
                }
            }
            else if (cBoxGrafico.Text == "Linha")
            {
                foreach (Series s in chart1.Series)
                {
                    s.ChartType = SeriesChartType.Line;
                }
            }
            else if (cBoxGrafico.Text == "Circulo")
            {
                foreach (Series s in chart1.Series)
                {
                    s.ChartType = SeriesChartType.Doughnut;
                }
            }
            else if (cBoxGrafico.Text == "Coluna 2")
            {
                foreach (Series s in chart1.Series)
                {
                    s.ChartType = SeriesChartType.RangeColumn;
                }
            }

            foreach (Series s in chart1.Series)
            {
                s.IsValueShownAsLabel = true;
            }

        }

        BindingSource servicosBindingSource = new BindingSource();




        private void btnTodos_Click(object sender, EventArgs e)
        {
            log.registrar("Botão TODOS clicado");
            ServicosDAO servicosDAO = new ServicosDAO();
            servicosBindingSource.DataSource = servicosDAO.getAllServicosNaoPago();
            dataGridViewServicos.DataSource = servicosBindingSource.List;
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

        private bool jaEstaAberto(System.Type formType)
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

        //private void dateTimePicker_MouseDown(object sender, MouseEventArgs e)
        //{
        //    bool estaAberto = jaEstaAberto(typeof(FormData));
        //    if (estaAberto == false)
        //    {
        //        FormData formData = new FormData();
        //        formData.ShowDialog(this);

        //        List<DateTime> listaDatas = new List<DateTime>
        //        {
        //            formData.dataInicial,
        //            formData.dataFinal
        //        };

        //        //string dataResolvida = resolveDate(formData.ToString("");

        //        lblDatas.Text = formData.dataInicial.ToString("dd/MM/yyyy") + " - " + formData.dataFinal.ToString("dd/MM/yyyy");
        //        lblDatas.BackColor = System.Drawing.Color.SpringGreen;

        //        ServicosDAO servicos = new ServicosDAO();
        //        servicosBindingSource.DataSource = servicos.getServicosByDates(listaDatas);
        //        dataGridViewServicos.DataSource = servicosBindingSource;
        //        configuraColunas();

        //    }
        //}
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

        private void dataGridViewServicos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewServicos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }


        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (idServico != "")
            {
                //ServicosDAO servicoDAO = new ServicosDAO();
                //string path = servicoDAO.getPathByIdServico(idServico);
                //FolderControl fc = new FolderControl();
                //string fullpath = fc.absolutePathOfPdf(path);


                //Process printProcess = new Process();
                //printProcess.StartInfo.FileName = "Acrobat.exe";
                //printProcess.StartInfo.Arguments = string.Format("/t \"{0}\"", fullpath);
                //printProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                //printProcess.Start();
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
        private void pBoxPesquisar_Click(object sender, EventArgs e)
        {
            temporizadorBotao(pBoxPesquisar);
            logUsuario();
            pesquisar();
        }

        private void lblPesquisar_Click(object sender, EventArgs e)
        {
            temporizadorBotao(pBoxPesquisar);
            logUsuario();
            pesquisar();
        }

        private void logUsuario()
        {
            log.registrar("---Botão PESQUISAR foi clicado---");
            log.registrar("Tipo de intervalo: " + cBoxIntevalo.Text);
            log.registrar("Datas selecionadas");
            log.registrar("Mês - Ano inicial: " + cBoxMI.Text + "\\" + numI.Value);
            log.registrar("Mês - Ano final: " + cBoxMF.Text + "\\" + numF.Value);
            log.registrar("Tipo pagamento: " + cBoxTipoPag.Text);
            log.registrar("Status pagamento: " + cBoxStatus.Text);
            log.registrar("Estilo gráfico: " + cBoxGrafico.Text);
        }

        private void FormPeriodo_FormClosing(object sender, FormClosingEventArgs e)
        {
            log.registrar(log.barra);
        }
    }
}
