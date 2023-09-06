using Servico1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Braga
{
    public partial class Coringa : Form
    {
        public Coringa()
        {
            
            InitializeComponent();
            l.iniciaArquivoLog();
        }

        Log l = new Log();
        

        private void btnCoringa_Click(object sender, EventArgs e)
        {
            rich.Text = l.registrar(txtCoringa.Text);
            //throw new Exception();
        }

    }
}
