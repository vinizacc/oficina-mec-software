using System;
using System.Windows.Forms;

namespace Servico1
{
    public partial class FormAlteraPropriedades : Form
    {
        public FormAlteraPropriedades()
        {
            InitializeComponent();
        }

        Oficina oficina = new Oficina();
        private int id { get; set; }
        public float diagFora { get; set; }
        public float diagOficina { get; set; }
        public float kmRodado { get; set; }

        //Valores em relação a consertos dentro da oficiona e fora, assim como o valor da quilometragem percorrida até o cliente.

        ToolTip toolTip = new ToolTip();

        private void FormAlteraPropriedades_Load(object sender, EventArgs e)
        {
            OficinaDAO ofDAO = new OficinaDAO();

            Oficina of = new Oficina();

            of = ofDAO.getOficinaValues();

            id = of.ID;
            diagOficina = of.VALOR_DIAG_OFICINA;
            diagFora = of.VALOR_DIAG_FORA;
            kmRodado = of.VALOR_KM;

            txtOficina.Text = diagOficina.ToString();
            txtFora.Text = diagFora.ToString();
            txtKm.Text = kmRodado.ToString();

            toolTip.SetToolTip(pictureBox1, "Valores em relação a consertos dentro da oficiona e fora, assim como o valor da quilometragem percorrida até o cliente.");

        }

        private void labelAlterar_Click(object sender, EventArgs e)
        {
            Oficina of = new Oficina();

            of.ID = id;
            of.VALOR_DIAG_OFICINA = float.Parse(txtOficina.Text);
            of.VALOR_DIAG_FORA = float.Parse(txtFora.Text);
            of.VALOR_KM = float.Parse(txtKm.Text);

            OficinaDAO ofDAO = new OficinaDAO();

            if (ofDAO.updateValues(of))
            {
                MessageBox.Show("Atualizado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("NÃO atualizado, ocorreu algum erro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Valores em relação a consertos dentro da oficiona e fora, assim como o valor da quilometragem percorrida até o cliente.", pictureBox1);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            toolTip.Hide(pictureBox1);
        }
    }
}
