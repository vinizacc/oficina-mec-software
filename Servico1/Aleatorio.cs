using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Servico1
{
    public partial class Aleatorio : Form
    {
        public Aleatorio()
        {
            InitializeComponent();
            p1.Visible = false;
            p2.Visible = false;
            p3.Visible = false;
            p4.Visible = false;
            p5.Visible = false;
            p6.Visible = false;
            p7.Visible = false;
            p8.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;

            int cont = 0;
            Random a = new Random();
            List<int> randomList = new List<int>();
            int MyNumber = 0;

            while (cont < 8)
            {

                MyNumber = a.Next(1, 9);
                if (!randomList.Contains(MyNumber))
                {
                    randomList.Add(MyNumber);
                    cont++;
                }
            }

            randomList2 = randomList;


        }

        public string todos = "";

        public List<int> randomList2 = new List<int>();

        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            funcionalidade();

        }

        private void funcionalidade()
        {
            corConcat(randomList2);

            panel1.Visible = false;
            label9.Visible = false;

            p1.Visible = true;
            p2.Visible = true;
            p3.Visible = true;
            p4.Visible = true;
            p5.Visible = true;
            p6.Visible = true;
            p7.Visible = true;
            p8.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;


            string todos = "";



            List<Control> controles = new List<Control>();

            controles.Add(p1);
            controles.Add(label1);
            controles.Add(p2);
            controles.Add(label2);
            controles.Add(p3);
            controles.Add(label3);
            controles.Add(p4);
            controles.Add(label4);
            controles.Add(p5);
            controles.Add(label5);
            controles.Add(p6);
            controles.Add(label6);
            controles.Add(p7);
            controles.Add(label7);
            controles.Add(p8);
            controles.Add(label8);

            //string verde = "Green";
            //string amarelo = "Yellow";
            //string laranja = "Orange";
            //string azul = "Blue";
            //string violeta = "Violet";
            //string vermelho = "vermelho";
            //string rosa = "Rosa";
            //string branco = "White";

            //controles[0].BackColor = Color.FromName(verde);
            //controles[1].BackColor = Color.FromName(amarelo);
            //controles[2].BackColor = Color.FromName(laranja);
            //controles[3].BackColor = Color.FromName(azul);
            //controles[4].BackColor = Color.FromName(violeta);
            //controles[5].BackColor = Color.FromName(vermelho);
            //controles[6].BackColor = Color.FromName(rosa);
            //controles[7].BackColor = Color.FromName(branco);
            //controles[8].BackColor = Color.FromName(branco);
            //controles[9].BackColor = Color.FromName(branco);
            //controles[10].BackColor = Color.FromName(branco);
            //controles[11].BackColor = Color.FromName(branco);
            //controles[12].BackColor = Color.FromName(branco);
            //controles[13].BackColor = Color.FromName(branco);
            //controles[14].BackColor = Color.FromName(branco);
            //controles[15].BackColor = Color.FromName(branco);

            int cont = 0;

            for (int i = 0; i < 15; i += 2)
            {
                controles[i].BackColor = Color.FromName(cor(randomList2[cont]));
                controles[i + 1].BackColor = Color.FromName(cor(randomList2[cont]));
                cont++;
            }

            todos = "Episódios: ";

            foreach (int item in randomList2)
            {
                todos += item.ToString() + ", ";
            }
        }

        private string corConcat(List<int> listaNumeros)
        {
            string texto = "Episódios: ";


            for (int j = 0; j < 8; j++)
            {
                if (listaNumeros[j] == 1) texto += "Verde ";
                if (listaNumeros[j] == 2) texto += "Amarelo ";
                if (listaNumeros[j] == 3) texto += "Laranja ";
                if (listaNumeros[j] == 4) texto += "Azul ";
                if (listaNumeros[j] == 5) texto += "Violeta ";
                if (listaNumeros[j] == 6) texto += "Vermelho ";
                if (listaNumeros[j] == 7) texto += "Rosa ";
                if (listaNumeros[j] == 8) texto += "Branco ";
            }

            Clipboard.SetText(texto);

            return texto;
        }

        private string cor(int numeroQueRepresentaCor)
        {
            if (numeroQueRepresentaCor == 1) return "Green";
            if (numeroQueRepresentaCor == 2) return "Yellow";
            if (numeroQueRepresentaCor == 3) return "Orange";
            if (numeroQueRepresentaCor == 4) return "Blue";
            if (numeroQueRepresentaCor == 5) return "Violet";
            if (numeroQueRepresentaCor == 6) return "Red";
            if (numeroQueRepresentaCor == 7) return "Pink";
            if (numeroQueRepresentaCor == 8) return "White";
            return "Not a color";
        }

        private void label9_DoubleClick(object sender, EventArgs e)
        {
            funcionalidade();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
