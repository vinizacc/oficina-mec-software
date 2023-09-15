namespace Servico1
{
    partial class Servico
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Servico));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pDVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controleDeClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatóriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteDevedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendaPorPeríodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acessoÀVendasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuáriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pBoxLogo = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pDVToolStripMenuItem,
            this.clienteToolStripMenuItem,
            this.relatóriosToolStripMenuItem,
            this.contaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1037, 36);
            this.menuStrip1.TabIndex = 25;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pDVToolStripMenuItem
            // 
            this.pDVToolStripMenuItem.Name = "pDVToolStripMenuItem";
            this.pDVToolStripMenuItem.Size = new System.Drawing.Size(63, 32);
            this.pDVToolStripMenuItem.Text = "PDV";
            this.pDVToolStripMenuItem.Click += new System.EventHandler(this.pDVToolStripMenuItem_Click);
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroToolStripMenuItem,
            this.controleDeClientesToolStripMenuItem});
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(86, 32);
            this.clienteToolStripMenuItem.Text = "Cliente";
            // 
            // cadastroToolStripMenuItem
            // 
            this.cadastroToolStripMenuItem.Name = "cadastroToolStripMenuItem";
            this.cadastroToolStripMenuItem.Size = new System.Drawing.Size(271, 32);
            this.cadastroToolStripMenuItem.Text = "Cadastro";
            this.cadastroToolStripMenuItem.Click += new System.EventHandler(this.cadastroToolStripMenuItem_Click);
            // 
            // controleDeClientesToolStripMenuItem
            // 
            this.controleDeClientesToolStripMenuItem.Name = "controleDeClientesToolStripMenuItem";
            this.controleDeClientesToolStripMenuItem.Size = new System.Drawing.Size(271, 32);
            this.controleDeClientesToolStripMenuItem.Text = "Controle de clientes";
            this.controleDeClientesToolStripMenuItem.Click += new System.EventHandler(this.controleDeClientesToolStripMenuItem_Click);
            // 
            // relatóriosToolStripMenuItem
            // 
            this.relatóriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clienteDevedorToolStripMenuItem,
            this.vendaPorPeríodoToolStripMenuItem,
            this.acessoÀVendasToolStripMenuItem,
            this.notasToolStripMenuItem});
            this.relatóriosToolStripMenuItem.Name = "relatóriosToolStripMenuItem";
            this.relatóriosToolStripMenuItem.Size = new System.Drawing.Size(113, 32);
            this.relatóriosToolStripMenuItem.Text = "Relatórios";
            // 
            // clienteDevedorToolStripMenuItem
            // 
            this.clienteDevedorToolStripMenuItem.Name = "clienteDevedorToolStripMenuItem";
            this.clienteDevedorToolStripMenuItem.Size = new System.Drawing.Size(263, 32);
            this.clienteDevedorToolStripMenuItem.Text = "Cliente devedor";
            this.clienteDevedorToolStripMenuItem.Click += new System.EventHandler(this.clienteDevedorToolStripMenuItem_Click);
            // 
            // vendaPorPeríodoToolStripMenuItem
            // 
            this.vendaPorPeríodoToolStripMenuItem.Name = "vendaPorPeríodoToolStripMenuItem";
            this.vendaPorPeríodoToolStripMenuItem.Size = new System.Drawing.Size(263, 32);
            this.vendaPorPeríodoToolStripMenuItem.Text = "Venda por período";
            this.vendaPorPeríodoToolStripMenuItem.Click += new System.EventHandler(this.vendaPorPeríodoToolStripMenuItem_Click);
            // 
            // acessoÀVendasToolStripMenuItem
            // 
            this.acessoÀVendasToolStripMenuItem.Name = "acessoÀVendasToolStripMenuItem";
            this.acessoÀVendasToolStripMenuItem.Size = new System.Drawing.Size(263, 32);
            this.acessoÀVendasToolStripMenuItem.Text = "Acesso à notas";
            this.acessoÀVendasToolStripMenuItem.Click += new System.EventHandler(this.acessoÀVendasToolStripMenuItem_Click);
            // 
            // notasToolStripMenuItem
            // 
            this.notasToolStripMenuItem.Name = "notasToolStripMenuItem";
            this.notasToolStripMenuItem.Size = new System.Drawing.Size(263, 32);
            this.notasToolStripMenuItem.Text = "Controle de notas";
            this.notasToolStripMenuItem.Click += new System.EventHandler(this.notasToolStripMenuItem_Click);
            // 
            // contaToolStripMenuItem
            // 
            this.contaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registroToolStripMenuItem,
            this.usuáriosToolStripMenuItem});
            this.contaToolStripMenuItem.Name = "contaToolStripMenuItem";
            this.contaToolStripMenuItem.Size = new System.Drawing.Size(78, 32);
            this.contaToolStripMenuItem.Text = "Conta";
            // 
            // registroToolStripMenuItem
            // 
            this.registroToolStripMenuItem.Name = "registroToolStripMenuItem";
            this.registroToolStripMenuItem.Size = new System.Drawing.Size(173, 32);
            this.registroToolStripMenuItem.Text = "Registro";
            this.registroToolStripMenuItem.Click += new System.EventHandler(this.registroToolStripMenuItem_Click);
            // 
            // usuáriosToolStripMenuItem
            // 
            this.usuáriosToolStripMenuItem.Name = "usuáriosToolStripMenuItem";
            this.usuáriosToolStripMenuItem.Size = new System.Drawing.Size(173, 32);
            this.usuáriosToolStripMenuItem.Text = "Usuários";
            this.usuáriosToolStripMenuItem.Click += new System.EventHandler(this.usuáriosToolStripMenuItem_Click);
            // 
            // pBoxLogo
            // 
            this.pBoxLogo.BackColor = System.Drawing.Color.White;
            this.pBoxLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pBoxLogo.Image")));
            this.pBoxLogo.Location = new System.Drawing.Point(0, 36);
            this.pBoxLogo.Margin = new System.Windows.Forms.Padding(0);
            this.pBoxLogo.Name = "pBoxLogo";
            this.pBoxLogo.Size = new System.Drawing.Size(1037, 698);
            this.pBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxLogo.TabIndex = 23;
            this.pBoxLogo.TabStop = false;
            // 
            // Servico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1037, 734);
            this.Controls.Add(this.pBoxLogo);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Servico";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Servico_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pBoxLogo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pDVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatóriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuáriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controleDeClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clienteDevedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendaPorPeríodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acessoÀVendasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notasToolStripMenuItem;
    }
}

