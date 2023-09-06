namespace Servico1
{
    partial class FormCadastroCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCadastroCliente));
            this.lblDoc = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtDoc = new System.Windows.Forms.TextBox();
            this.lblTel = new System.Windows.Forms.Label();
            this.lblEndereco = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rTxtBoxDescricao = new System.Windows.Forms.RichTextBox();
            this.lblWarning = new System.Windows.Forms.Label();
            this.labelCadastrar = new System.Windows.Forms.Label();
            this.gBoxCadastroCliente = new System.Windows.Forms.GroupBox();
            this.gBoxCadastroCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDoc
            // 
            resources.ApplyResources(this.lblDoc, "lblDoc");
            this.lblDoc.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDoc.Name = "lblDoc";
            // 
            // txtTel
            // 
            resources.ApplyResources(this.txtTel, "txtTel");
            this.txtTel.Name = "txtTel";
            this.txtTel.Leave += new System.EventHandler(this.txtTel_Leave);
            // 
            // txtDoc
            // 
            resources.ApplyResources(this.txtDoc, "txtDoc");
            this.txtDoc.Name = "txtDoc";
            this.txtDoc.Leave += new System.EventHandler(this.txtDoc_Leave);
            // 
            // lblTel
            // 
            resources.ApplyResources(this.lblTel, "lblTel");
            this.lblTel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTel.Name = "lblTel";
            // 
            // lblEndereco
            // 
            resources.ApplyResources(this.lblEndereco, "lblEndereco");
            this.lblEndereco.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblEndereco.Name = "lblEndereco";
            // 
            // txtNome
            // 
            resources.ApplyResources(this.txtNome, "txtNome");
            this.txtNome.Name = "txtNome";
            this.txtNome.Leave += new System.EventHandler(this.txtNome_Leave);
            // 
            // txtEndereco
            // 
            resources.ApplyResources(this.txtEndereco, "txtEndereco");
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Leave += new System.EventHandler(this.txtEndereco_Leave);
            // 
            // lblNome
            // 
            resources.ApplyResources(this.lblNome, "lblNome");
            this.lblNome.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblNome.Name = "lblNome";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.ForeColor = System.Drawing.SystemColors.Control;
            this.label12.Name = "label12";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Name = "label2";
            // 
            // rTxtBoxDescricao
            // 
            resources.ApplyResources(this.rTxtBoxDescricao, "rTxtBoxDescricao");
            this.rTxtBoxDescricao.Name = "rTxtBoxDescricao";
            this.rTxtBoxDescricao.Leave += new System.EventHandler(this.rTxtBoxDescricao_Leave);
            // 
            // lblWarning
            // 
            resources.ApplyResources(this.lblWarning, "lblWarning");
            this.lblWarning.ForeColor = System.Drawing.Color.Red;
            this.lblWarning.Name = "lblWarning";
            // 
            // labelCadastrar
            // 
            this.labelCadastrar.BackColor = System.Drawing.SystemColors.HotTrack;
            resources.ApplyResources(this.labelCadastrar, "labelCadastrar");
            this.labelCadastrar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelCadastrar.Name = "labelCadastrar";
            this.labelCadastrar.Click += new System.EventHandler(this.labelCadastrar_Click);
            // 
            // gBoxCadastroCliente
            // 
            this.gBoxCadastroCliente.BackColor = System.Drawing.SystemColors.Highlight;
            this.gBoxCadastroCliente.Controls.Add(this.labelCadastrar);
            this.gBoxCadastroCliente.Controls.Add(this.lblWarning);
            this.gBoxCadastroCliente.Controls.Add(this.rTxtBoxDescricao);
            this.gBoxCadastroCliente.Controls.Add(this.label2);
            this.gBoxCadastroCliente.Controls.Add(this.label12);
            this.gBoxCadastroCliente.Controls.Add(this.lblNome);
            this.gBoxCadastroCliente.Controls.Add(this.txtEndereco);
            this.gBoxCadastroCliente.Controls.Add(this.txtNome);
            this.gBoxCadastroCliente.Controls.Add(this.lblEndereco);
            this.gBoxCadastroCliente.Controls.Add(this.lblTel);
            this.gBoxCadastroCliente.Controls.Add(this.txtDoc);
            this.gBoxCadastroCliente.Controls.Add(this.txtTel);
            this.gBoxCadastroCliente.Controls.Add(this.lblDoc);
            this.gBoxCadastroCliente.ForeColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.gBoxCadastroCliente, "gBoxCadastroCliente");
            this.gBoxCadastroCliente.Name = "gBoxCadastroCliente";
            this.gBoxCadastroCliente.TabStop = false;
            // 
            // FormCadastroCliente
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Controls.Add(this.gBoxCadastroCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCadastroCliente";
            this.ShowIcon = false;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCadastroCliente_FormClosing);
            this.Load += new System.EventHandler(this.FormCadastroCliente_Load);
            this.Leave += new System.EventHandler(this.FormCadastroCliente_Leave);
            this.gBoxCadastroCliente.ResumeLayout(false);
            this.gBoxCadastroCliente.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDoc;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtDoc;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.Label lblEndereco;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rTxtBoxDescricao;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Label labelCadastrar;
        private System.Windows.Forms.GroupBox gBoxCadastroCliente;
    }
}