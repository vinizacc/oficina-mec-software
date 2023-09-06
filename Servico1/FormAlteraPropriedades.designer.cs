namespace Servico1
{
    partial class FormAlteraPropriedades
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAlteraPropriedades));
            this.lblEndereco = new System.Windows.Forms.Label();
            this.txtOficina = new System.Windows.Forms.TextBox();
            this.txtFora = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblWarning = new System.Windows.Forms.Label();
            this.lblAlternar = new System.Windows.Forms.Label();
            this.gBoxCadastroCliente = new System.Windows.Forms.GroupBox();
            this.txtKm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gBoxCadastroCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEndereco
            // 
            resources.ApplyResources(this.lblEndereco, "lblEndereco");
            this.lblEndereco.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblEndereco.Name = "lblEndereco";
            // 
            // txtOficina
            // 
            resources.ApplyResources(this.txtOficina, "txtOficina");
            this.txtOficina.Name = "txtOficina";
            // 
            // txtFora
            // 
            resources.ApplyResources(this.txtFora, "txtFora");
            this.txtFora.Name = "txtFora";
            // 
            // lblNome
            // 
            resources.ApplyResources(this.lblNome, "lblNome");
            this.lblNome.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblNome.Name = "lblNome";
            // 
            // lblWarning
            // 
            resources.ApplyResources(this.lblWarning, "lblWarning");
            this.lblWarning.ForeColor = System.Drawing.Color.Red;
            this.lblWarning.Name = "lblWarning";
            // 
            // lblAlternar
            // 
            this.lblAlternar.BackColor = System.Drawing.SystemColors.HotTrack;
            resources.ApplyResources(this.lblAlternar, "lblAlternar");
            this.lblAlternar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblAlternar.Name = "lblAlternar";
            this.lblAlternar.Click += new System.EventHandler(this.labelAlterar_Click);
            // 
            // gBoxCadastroCliente
            // 
            this.gBoxCadastroCliente.BackColor = System.Drawing.SystemColors.Highlight;
            this.gBoxCadastroCliente.Controls.Add(this.pictureBox1);
            this.gBoxCadastroCliente.Controls.Add(this.txtKm);
            this.gBoxCadastroCliente.Controls.Add(this.label1);
            this.gBoxCadastroCliente.Controls.Add(this.lblAlternar);
            this.gBoxCadastroCliente.Controls.Add(this.lblWarning);
            this.gBoxCadastroCliente.Controls.Add(this.label12);
            this.gBoxCadastroCliente.Controls.Add(this.lblNome);
            this.gBoxCadastroCliente.Controls.Add(this.txtFora);
            this.gBoxCadastroCliente.Controls.Add(this.txtOficina);
            this.gBoxCadastroCliente.Controls.Add(this.lblEndereco);
            this.gBoxCadastroCliente.ForeColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.gBoxCadastroCliente, "gBoxCadastroCliente");
            this.gBoxCadastroCliente.Name = "gBoxCadastroCliente";
            this.gBoxCadastroCliente.TabStop = false;
            // 
            // txtKm
            // 
            resources.ApplyResources(this.txtKm, "txtKm");
            this.txtKm.Name = "txtKm";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Name = "label1";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.BackColor = System.Drawing.SystemColors.Info;
            this.label12.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label12.Name = "label12";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Highlight;
            this.pictureBox1.Image = global::Braga.Properties.Resources.questionamento;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
            // 
            // FormAlteraPropriedades
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Controls.Add(this.gBoxCadastroCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAlteraPropriedades";
            this.ShowIcon = false;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormAlteraPropriedades_Load);
            this.gBoxCadastroCliente.ResumeLayout(false);
            this.gBoxCadastroCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblEndereco;
        private System.Windows.Forms.TextBox txtOficina;
        private System.Windows.Forms.TextBox txtFora;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Label lblAlternar;
        private System.Windows.Forms.GroupBox gBoxCadastroCliente;
        private System.Windows.Forms.TextBox txtKm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}