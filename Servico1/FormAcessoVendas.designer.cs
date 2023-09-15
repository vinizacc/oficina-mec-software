namespace Servico1
{
    partial class FormAcessoVendas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAcessoVendas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblNomeArq = new System.Windows.Forms.Label();
            this.btnPagou = new System.Windows.Forms.Button();
            this.lblNome = new System.Windows.Forms.Label();
            this.btnTodos = new System.Windows.Forms.Button();
            this.btnProcurar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProcuraNome = new System.Windows.Forms.TextBox();
            this.lblDatas = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.lblTipoPag = new System.Windows.Forms.Label();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.lblData = new System.Windows.Forms.Label();
            this.dataGridViewServicos = new System.Windows.Forms.DataGridView();
            this.axAcroPDF1 = new AxAcroPDFLib.AxAcroPDF();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnArquivo = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServicos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.groupBox3.Controls.Add(this.lblNomeArq);
            this.groupBox3.Controls.Add(this.btnPagou);
            this.groupBox3.Controls.Add(this.lblNome);
            this.groupBox3.Controls.Add(this.btnTodos);
            this.groupBox3.Controls.Add(this.btnProcurar);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtProcuraNome);
            this.groupBox3.Controls.Add(this.lblDatas);
            this.groupBox3.Controls.Add(this.dateTimePicker);
            this.groupBox3.Controls.Add(this.lblTipoPag);
            this.groupBox3.Controls.Add(this.comboBox);
            this.groupBox3.Controls.Add(this.lblData);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // lblNomeArq
            // 
            resources.ApplyResources(this.lblNomeArq, "lblNomeArq");
            this.lblNomeArq.Name = "lblNomeArq";
            // 
            // btnPagou
            // 
            this.btnPagou.BackColor = System.Drawing.SystemColors.Info;
            resources.ApplyResources(this.btnPagou, "btnPagou");
            this.btnPagou.Name = "btnPagou";
            this.btnPagou.UseVisualStyleBackColor = false;
            this.btnPagou.Click += new System.EventHandler(this.btnPagou_Click);
            // 
            // lblNome
            // 
            resources.ApplyResources(this.lblNome, "lblNome");
            this.lblNome.Name = "lblNome";
            // 
            // btnTodos
            // 
            resources.ApplyResources(this.btnTodos, "btnTodos");
            this.btnTodos.Name = "btnTodos";
            this.btnTodos.UseVisualStyleBackColor = true;
            this.btnTodos.Click += new System.EventHandler(this.btnTodos_Click);
            // 
            // btnProcurar
            // 
            resources.ApplyResources(this.btnProcurar, "btnProcurar");
            this.btnProcurar.Name = "btnProcurar";
            this.btnProcurar.UseVisualStyleBackColor = true;
            this.btnProcurar.Click += new System.EventHandler(this.btnProcurar_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txtProcuraNome
            // 
            this.txtProcuraNome.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtProcuraNome.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            resources.ApplyResources(this.txtProcuraNome, "txtProcuraNome");
            this.txtProcuraNome.Name = "txtProcuraNome";
            // 
            // lblDatas
            // 
            resources.ApplyResources(this.lblDatas, "lblDatas");
            this.lblDatas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDatas.Name = "lblDatas";
            // 
            // dateTimePicker
            // 
            resources.ApplyResources(this.dateTimePicker, "dateTimePicker");
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dateTimePicker_MouseDown);
            // 
            // lblTipoPag
            // 
            resources.ApplyResources(this.lblTipoPag, "lblTipoPag");
            this.lblTipoPag.Name = "lblTipoPag";
            // 
            // comboBox
            // 
            resources.ApplyResources(this.comboBox, "comboBox");
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Name = "comboBox";
            // 
            // lblData
            // 
            resources.ApplyResources(this.lblData, "lblData");
            this.lblData.Name = "lblData";
            // 
            // dataGridViewServicos
            // 
            this.dataGridViewServicos.AllowUserToAddRows = false;
            this.dataGridViewServicos.AllowUserToDeleteRows = false;
            this.dataGridViewServicos.AllowUserToOrderColumns = true;
            this.dataGridViewServicos.AllowUserToResizeRows = false;
            resources.ApplyResources(this.dataGridViewServicos, "dataGridViewServicos");
            this.dataGridViewServicos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewServicos.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridViewServicos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewServicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewServicos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewServicos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewServicos.Name = "dataGridViewServicos";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewServicos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewServicos.RowHeadersVisible = false;
            this.dataGridViewServicos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewServicos.RowTemplate.Height = 24;
            this.dataGridViewServicos.RowTemplate.ReadOnly = true;
            this.dataGridViewServicos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewServicos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewServicos_CellEnter);
            this.dataGridViewServicos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewServicos_CellFormatting);
            this.dataGridViewServicos.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewServicos_CellMouseClick);
            this.dataGridViewServicos.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewServicos_CellMouseDoubleClick);
            this.dataGridViewServicos.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewServicos_RowEnter);
            this.dataGridViewServicos.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewServicos_RowLeave);
            // 
            // axAcroPDF1
            // 
            resources.ApplyResources(this.axAcroPDF1, "axAcroPDF1");
            this.axAcroPDF1.Name = "axAcroPDF1";
            this.axAcroPDF1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF1.OcxState")));
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Azure;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // btnAbrir
            // 
            this.btnAbrir.BackColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this.btnAbrir, "btnAbrir");
            this.btnAbrir.ForeColor = System.Drawing.Color.White;
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.UseVisualStyleBackColor = false;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this.btnImprimir, "btnImprimir");
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnArquivo
            // 
            this.btnArquivo.BackColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this.btnArquivo, "btnArquivo");
            this.btnArquivo.ForeColor = System.Drawing.Color.White;
            this.btnArquivo.Name = "btnArquivo";
            this.btnArquivo.UseVisualStyleBackColor = false;
            this.btnArquivo.Click += new System.EventHandler(this.btnArquivo_Click);
            // 
            // FormAcessoVendas
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Controls.Add(this.btnArquivo);
            this.Controls.Add(this.btnAbrir);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.axAcroPDF1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridViewServicos);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAcessoVendas";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAcessoVendas_FormClosing);
            this.Load += new System.EventHandler(this.FormAcessoVendas_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServicos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label lblTipoPag;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Button btnProcurar;
        private System.Windows.Forms.TextBox txtProcuraNome;
        private System.Windows.Forms.Button btnTodos;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.DataGridView dataGridViewServicos;
        private System.Windows.Forms.Button btnPagou;
        private System.Windows.Forms.Label lblDatas;
        private System.Windows.Forms.Label label5;
        private AxAcroPDFLib.AxAcroPDF axAcroPDF1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Label lblNomeArq;
        private System.Windows.Forms.Button btnArquivo;
    }
}