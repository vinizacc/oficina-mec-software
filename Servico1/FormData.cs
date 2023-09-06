using Braga;
using System;
using System.Windows.Forms;


namespace Servico1
{
    public partial class FormData : Form
    {
        public FormData()
        {
            GlobalExceptionHandler.Attach(log);
            InitializeComponent();

        }
        private void FormData_Load(object sender, EventArgs e)
        {
            setDataInicial();
            setDataFinal();
            log.caminhoENome = caminhoENomeLog;
            log.registrar(log.barra + "Abrindo Form Seleção de DATA" + log.barra);
        }

        public DateTime dataInicial;
        public DateTime dataFinal;
        Log log = new Log();
        public string caminhoENomeLog;

        public void setDataInicial() { this.dataInicial = DateTime.Now; }
        public void setDataFinal() { this.dataFinal = DateTime.Now; }
        private void FormData_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.BackColor = System.Drawing.Color.White;
            label5.BackColor = System.Drawing.Color.White;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = System.Drawing.Color.Red;
            label5.BackColor = System.Drawing.Color.Red;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePickerInicial_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerInicial.Checked == true)
            {
                dataInicial = dateTimePickerInicial.Value;
                log.registrar("DATA INICIAL: " + dataInicial);
            }
        }

        private void dateTimePickerFinal_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerFinal.Checked == true)
            {
                dataFinal = dateTimePickerFinal.Value;
                log.registrar("DATA FINAL: "+ dataFinal);
            }

        }

        private void FormData_FormClosing(object sender, FormClosingEventArgs e)
        {
            log.registrar(log.barra);
        }
    }
}
