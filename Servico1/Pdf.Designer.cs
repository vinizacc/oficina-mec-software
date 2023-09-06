namespace Servico1
{
    partial class Pdf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pdf));
            this.axAcroPDF1 = new AxAcroPDFLib.AxAcroPDF();
            this.btnTabela = new System.Windows.Forms.Button();
            this.btnMais = new System.Windows.Forms.Button();
            this.btnMenos = new System.Windows.Forms.Button();
            this.lblZoom = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.picBoxSalvar = new System.Windows.Forms.PictureBox();
            this.picBoxPrint = new System.Windows.Forms.PictureBox();
            this.lblSalvar = new System.Windows.Forms.Label();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSalvar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPrint)).BeginInit();
            this.SuspendLayout();
            // 
            // axAcroPDF1
            // 
            this.axAcroPDF1.Enabled = true;
            this.axAcroPDF1.Location = new System.Drawing.Point(12, 12);
            this.axAcroPDF1.Name = "axAcroPDF1";
            this.axAcroPDF1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF1.OcxState")));
            this.axAcroPDF1.Size = new System.Drawing.Size(873, 549);
            this.axAcroPDF1.TabIndex = 0;
            // 
            // btnTabela
            // 
            this.btnTabela.Location = new System.Drawing.Point(993, 595);
            this.btnTabela.Name = "btnTabela";
            this.btnTabela.Size = new System.Drawing.Size(241, 87);
            this.btnTabela.TabIndex = 14;
            this.btnTabela.Text = "Pdf Tabela";
            this.btnTabela.UseVisualStyleBackColor = true;
            // 
            // btnMais
            // 
            this.btnMais.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnMais.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMais.ForeColor = System.Drawing.SystemColors.Control;
            this.btnMais.Location = new System.Drawing.Point(1400, 27);
            this.btnMais.Name = "btnMais";
            this.btnMais.Size = new System.Drawing.Size(80, 80);
            this.btnMais.TabIndex = 15;
            this.btnMais.Text = "+";
            this.btnMais.UseVisualStyleBackColor = false;
            this.btnMais.Click += new System.EventHandler(this.btnMais_Click);
            // 
            // btnMenos
            // 
            this.btnMenos.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnMenos.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenos.ForeColor = System.Drawing.SystemColors.Control;
            this.btnMenos.Location = new System.Drawing.Point(1400, 113);
            this.btnMenos.Name = "btnMenos";
            this.btnMenos.Size = new System.Drawing.Size(80, 80);
            this.btnMenos.TabIndex = 16;
            this.btnMenos.Text = "-";
            this.btnMenos.UseVisualStyleBackColor = false;
            this.btnMenos.Click += new System.EventHandler(this.btnMenos_Click);
            // 
            // lblZoom
            // 
            this.lblZoom.AutoSize = true;
            this.lblZoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZoom.ForeColor = System.Drawing.SystemColors.Window;
            this.lblZoom.Location = new System.Drawing.Point(1398, 225);
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(77, 25);
            this.lblZoom.TabIndex = 18;
            this.lblZoom.Text = "ZOOM";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(1367, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 25);
            this.label1.TabIndex = 19;
            this.label1.Text = "IMPRIMIR";
            // 
            // picBoxSalvar
            // 
            this.picBoxSalvar.Image = global::Braga.Properties.Resources.salve_;
            this.picBoxSalvar.Location = new System.Drawing.Point(1395, 394);
            this.picBoxSalvar.Name = "picBoxSalvar";
            this.picBoxSalvar.Size = new System.Drawing.Size(80, 80);
            this.picBoxSalvar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxSalvar.TabIndex = 21;
            this.picBoxSalvar.TabStop = false;
            this.picBoxSalvar.Click += new System.EventHandler(this.picBoxSalvar_Click);
            // 
            // picBoxPrint
            // 
            this.picBoxPrint.BackgroundImage = global::Braga.Properties.Resources.impressora;
            this.picBoxPrint.Image = global::Braga.Properties.Resources.impressora;
            this.picBoxPrint.Location = new System.Drawing.Point(1398, 308);
            this.picBoxPrint.Name = "picBoxPrint";
            this.picBoxPrint.Size = new System.Drawing.Size(80, 80);
            this.picBoxPrint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxPrint.TabIndex = 20;
            this.picBoxPrint.TabStop = false;
            this.picBoxPrint.Click += new System.EventHandler(this.picBoxPrint_Click);
            // 
            // lblSalvar
            // 
            this.lblSalvar.AutoSize = true;
            this.lblSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalvar.ForeColor = System.Drawing.SystemColors.Window;
            this.lblSalvar.Location = new System.Drawing.Point(1380, 477);
            this.lblSalvar.Name = "lblSalvar";
            this.lblSalvar.Size = new System.Drawing.Size(98, 25);
            this.lblSalvar.TabIndex = 22;
            this.lblSalvar.Text = "SALVAR";
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // Pdf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1479, 983);
            this.Controls.Add(this.lblSalvar);
            this.Controls.Add(this.picBoxSalvar);
            this.Controls.Add(this.picBoxPrint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblZoom);
            this.Controls.Add(this.btnMenos);
            this.Controls.Add(this.btnMais);
            this.Controls.Add(this.btnTabela);
            this.Controls.Add(this.axAcroPDF1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Pdf";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pdf";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Pdf_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSalvar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPrint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF axAcroPDF1;
        private System.Windows.Forms.Button btnTabela;
        private System.Windows.Forms.Button btnMais;
        private System.Windows.Forms.Button btnMenos;
        private System.Windows.Forms.Label lblZoom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picBoxPrint;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.PictureBox picBoxSalvar;
        private System.Windows.Forms.Label lblSalvar;
        private System.Windows.Forms.PrintDialog printDialog;
    }
}