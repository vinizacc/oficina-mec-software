using System.Drawing;
using System.Windows.Forms;

namespace Servico1
{
    partial class FormNotas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNotas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewAltera = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxTel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxProcuraDoc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnProcurarCliente = new System.Windows.Forms.Button();
            this.txtProcuraNome = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBoxDeletado = new System.Windows.Forms.CheckBox();
            this.checkBoxAtivo = new System.Windows.Forms.CheckBox();
            this.btnRecuperar = new System.Windows.Forms.Button();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.lblControle = new System.Windows.Forms.Label();
            this.dataGridViewBusca = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAltera)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBusca)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBox1.Controls.Add(this.dataGridViewAltera);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.dataGridViewBusca);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // dataGridViewAltera
            // 
            this.dataGridViewAltera.AllowUserToAddRows = false;
            this.dataGridViewAltera.AllowUserToDeleteRows = false;
            this.dataGridViewAltera.AllowUserToOrderColumns = true;
            this.dataGridViewAltera.AllowUserToResizeRows = false;
            resources.ApplyResources(this.dataGridViewAltera, "dataGridViewAltera");
            this.dataGridViewAltera.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAltera.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridViewAltera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewAltera.DefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridViewAltera.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewAltera.Name = "dataGridViewAltera";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAltera.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridViewAltera.RowHeadersVisible = false;
            this.dataGridViewAltera.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewAltera.RowTemplate.Height = 24;
            this.dataGridViewAltera.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAltera.SelectionChanged += new System.EventHandler(this.dataGridViewAltera_SelectionChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtBoxTel);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtBoxProcuraDoc);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.btnProcurarCliente);
            this.groupBox3.Controls.Add(this.txtProcuraNome);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // txtBoxTel
            // 
            resources.ApplyResources(this.txtBoxTel, "txtBoxTel");
            this.txtBoxTel.Name = "txtBoxTel";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtBoxProcuraDoc
            // 
            resources.ApplyResources(this.txtBoxProcuraDoc, "txtBoxProcuraDoc");
            this.txtBoxProcuraDoc.Name = "txtBoxProcuraDoc";
            this.txtBoxProcuraDoc.Enter += new System.EventHandler(this.txtBoxProcuraDoc_Enter);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // btnProcurarCliente
            // 
            resources.ApplyResources(this.btnProcurarCliente, "btnProcurarCliente");
            this.btnProcurarCliente.Name = "btnProcurarCliente";
            this.btnProcurarCliente.UseVisualStyleBackColor = true;
            this.btnProcurarCliente.Click += new System.EventHandler(this.btnProcurarCliente_Click);
            // 
            // txtProcuraNome
            // 
            resources.ApplyResources(this.txtProcuraNome, "txtProcuraNome");
            this.txtProcuraNome.Name = "txtProcuraNome";
            this.txtProcuraNome.Enter += new System.EventHandler(this.txtProcuraNome_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.lblControle);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBoxDeletado);
            this.groupBox4.Controls.Add(this.checkBoxAtivo);
            this.groupBox4.Controls.Add(this.btnRecuperar);
            this.groupBox4.Controls.Add(this.btnDeletar);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // checkBoxDeletado
            // 
            resources.ApplyResources(this.checkBoxDeletado, "checkBoxDeletado");
            this.checkBoxDeletado.Name = "checkBoxDeletado";
            this.checkBoxDeletado.UseVisualStyleBackColor = true;
            this.checkBoxDeletado.Click += new System.EventHandler(this.checkBoxAtivo_Click);
            // 
            // checkBoxAtivo
            // 
            resources.ApplyResources(this.checkBoxAtivo, "checkBoxAtivo");
            this.checkBoxAtivo.Name = "checkBoxAtivo";
            this.checkBoxAtivo.UseVisualStyleBackColor = true;
            this.checkBoxAtivo.CheckedChanged += new System.EventHandler(this.checkBoxAtivo_CheckedChanged);
            this.checkBoxAtivo.Click += new System.EventHandler(this.checkBoxAtivo_Click);
            // 
            // btnRecuperar
            // 
            resources.ApplyResources(this.btnRecuperar, "btnRecuperar");
            this.btnRecuperar.Name = "btnRecuperar";
            this.btnRecuperar.UseVisualStyleBackColor = true;
            this.btnRecuperar.Click += new System.EventHandler(this.btnRecuperar_Click);
            // 
            // btnDeletar
            // 
            resources.ApplyResources(this.btnDeletar, "btnDeletar");
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.UseVisualStyleBackColor = true;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // lblControle
            // 
            resources.ApplyResources(this.lblControle, "lblControle");
            this.lblControle.Name = "lblControle";
            // 
            // dataGridViewBusca
            // 
            this.dataGridViewBusca.AllowUserToAddRows = false;
            this.dataGridViewBusca.AllowUserToDeleteRows = false;
            this.dataGridViewBusca.AllowUserToOrderColumns = true;
            this.dataGridViewBusca.AllowUserToResizeRows = false;
            resources.ApplyResources(this.dataGridViewBusca, "dataGridViewBusca");
            this.dataGridViewBusca.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBusca.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBusca.DefaultCellStyle = dataGridViewCellStyle23;
            this.dataGridViewBusca.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewBusca.Name = "dataGridViewBusca";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBusca.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.dataGridViewBusca.RowHeadersVisible = false;
            this.dataGridViewBusca.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewBusca.RowTemplate.Height = 24;
            this.dataGridViewBusca.RowTemplate.ReadOnly = true;
            this.dataGridViewBusca.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBusca.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBusca_CellDoubleClick);
            this.dataGridViewBusca.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewCLientes_CellFormatting);
            this.dataGridViewBusca.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCLientes_RowEnter);
            this.dataGridViewBusca.SelectionChanged += new System.EventHandler(this.dataGridViewBusca_SelectionChanged);
            // 
            // FormNotas
            // 
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNotas";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormNotas_FormClosing);
            this.Load += new System.EventHandler(this.FormNotas_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAltera)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBusca)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtProcuraNome;
        private System.Windows.Forms.Button btnProcurarCliente;
        private System.Windows.Forms.DataGridView dataGridViewBusca;
        private System.Windows.Forms.Label label1;
        private AutoScaleMode AutoScaleMode;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label2;
        private Label label3;
        private TextBox txtBoxProcuraDoc;
        private Label lblControle;
        private DataGridView dataGridViewAltera;
        private Label label4;
        private TextBox txtBoxTel;
        private GroupBox groupBox4;
        private Button btnDeletar;
        private Button btnRecuperar;
        private CheckBox checkBoxDeletado;
        private CheckBox checkBoxAtivo;

        public Color BackColor { get; private set; }
    }
}