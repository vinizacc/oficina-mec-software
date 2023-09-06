namespace Servico1
{
    partial class FormUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUsuarios));
            this.groupBoxUsuario = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnTodos = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnProcura = new System.Windows.Forms.Button();
            this.txtProcura = new System.Windows.Forms.TextBox();
            this.dataGridViewUsuarios = new System.Windows.Forms.DataGridView();
            this.gBoxAlterar = new System.Windows.Forms.GroupBox();
            this.lblWarning = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtConf = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pBoxFechado = new System.Windows.Forms.PictureBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.pBoxAberto = new System.Windows.Forms.PictureBox();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.groupBoxUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).BeginInit();
            this.gBoxAlterar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxFechado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxAberto)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxUsuario
            // 
            this.groupBoxUsuario.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxUsuario.Controls.Add(this.label1);
            this.groupBoxUsuario.Controls.Add(this.btnExcluir);
            this.groupBoxUsuario.Controls.Add(this.btnTodos);
            this.groupBoxUsuario.Controls.Add(this.btnNovo);
            this.groupBoxUsuario.Controls.Add(this.label7);
            this.groupBoxUsuario.Controls.Add(this.btnProcura);
            this.groupBoxUsuario.Controls.Add(this.txtProcura);
            this.groupBoxUsuario.Controls.Add(this.dataGridViewUsuarios);
            resources.ApplyResources(this.groupBoxUsuario, "groupBoxUsuario");
            this.groupBoxUsuario.Name = "groupBoxUsuario";
            this.groupBoxUsuario.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btnExcluir
            // 
            resources.ApplyResources(this.btnExcluir, "btnExcluir");
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnTodos
            // 
            resources.ApplyResources(this.btnTodos, "btnTodos");
            this.btnTodos.Name = "btnTodos";
            this.btnTodos.UseVisualStyleBackColor = true;
            this.btnTodos.Click += new System.EventHandler(this.btnTodos_Click);
            // 
            // btnNovo
            // 
            resources.ApplyResources(this.btnNovo, "btnNovo");
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // btnProcura
            // 
            resources.ApplyResources(this.btnProcura, "btnProcura");
            this.btnProcura.Name = "btnProcura";
            this.btnProcura.UseVisualStyleBackColor = true;
            this.btnProcura.Click += new System.EventHandler(this.btnProcura_Click);
            // 
            // txtProcura
            // 
            resources.ApplyResources(this.txtProcura, "txtProcura");
            this.txtProcura.Name = "txtProcura";
            // 
            // dataGridViewUsuarios
            // 
            this.dataGridViewUsuarios.AllowUserToAddRows = false;
            this.dataGridViewUsuarios.AllowUserToDeleteRows = false;
            this.dataGridViewUsuarios.AllowUserToOrderColumns = true;
            this.dataGridViewUsuarios.AllowUserToResizeRows = false;
            resources.ApplyResources(this.dataGridViewUsuarios, "dataGridViewUsuarios");
            this.dataGridViewUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewUsuarios.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewUsuarios.Name = "dataGridViewUsuarios";
            this.dataGridViewUsuarios.RowHeadersVisible = false;
            this.dataGridViewUsuarios.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewUsuarios.RowTemplate.Height = 24;
            this.dataGridViewUsuarios.RowTemplate.ReadOnly = true;
            this.dataGridViewUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUsuarios_CellClick);
            this.dataGridViewUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUsuarios_CellContentClick);
            this.dataGridViewUsuarios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUsuarios_CellDoubleClick);
            this.dataGridViewUsuarios.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUsuarios_CellEnter);
            this.dataGridViewUsuarios.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUsuarios_RowEnter);
            this.dataGridViewUsuarios.SelectionChanged += new System.EventHandler(this.dataGridViewUsuarios_SelectionChanged);
            // 
            // gBoxAlterar
            // 
            this.gBoxAlterar.BackColor = System.Drawing.SystemColors.Control;
            this.gBoxAlterar.Controls.Add(this.lblWarning);
            this.gBoxAlterar.Controls.Add(this.label11);
            this.gBoxAlterar.Controls.Add(this.txtSenha);
            this.gBoxAlterar.Controls.Add(this.label10);
            this.gBoxAlterar.Controls.Add(this.label9);
            this.gBoxAlterar.Controls.Add(this.txtConf);
            this.gBoxAlterar.Controls.Add(this.label8);
            this.gBoxAlterar.Controls.Add(this.pBoxFechado);
            this.gBoxAlterar.Controls.Add(this.txtUsuario);
            this.gBoxAlterar.Controls.Add(this.pBoxAberto);
            this.gBoxAlterar.Controls.Add(this.btnAlterar);
            resources.ApplyResources(this.gBoxAlterar, "gBoxAlterar");
            this.gBoxAlterar.Name = "gBoxAlterar";
            this.gBoxAlterar.TabStop = false;
            // 
            // lblWarning
            // 
            resources.ApplyResources(this.lblWarning, "lblWarning");
            this.lblWarning.ForeColor = System.Drawing.Color.Red;
            this.lblWarning.Name = "lblWarning";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // txtSenha
            // 
            resources.ApplyResources(this.txtSenha, "txtSenha");
            this.txtSenha.Name = "txtSenha";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // txtConf
            // 
            resources.ApplyResources(this.txtConf, "txtConf");
            this.txtConf.Name = "txtConf";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // pBoxFechado
            // 
            this.pBoxFechado.BackgroundImage = global::Braga.Properties.Resources._private;
            resources.ApplyResources(this.pBoxFechado, "pBoxFechado");
            this.pBoxFechado.Name = "pBoxFechado";
            this.pBoxFechado.TabStop = false;
            this.pBoxFechado.Click += new System.EventHandler(this.pBoxFechado_Click);
            // 
            // txtUsuario
            // 
            resources.ApplyResources(this.txtUsuario, "txtUsuario");
            this.txtUsuario.Name = "txtUsuario";
            // 
            // pBoxAberto
            // 
            this.pBoxAberto.BackgroundImage = global::Braga.Properties.Resources.view;
            resources.ApplyResources(this.pBoxAberto, "pBoxAberto");
            this.pBoxAberto.Name = "pBoxAberto";
            this.pBoxAberto.TabStop = false;
            this.pBoxAberto.Click += new System.EventHandler(this.pBoxAberto_Click);
            // 
            // btnAlterar
            // 
            resources.ApplyResources(this.btnAlterar, "btnAlterar");
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // FormUsuarios
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Controls.Add(this.gBoxAlterar);
            this.Controls.Add(this.groupBoxUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUsuarios";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.FormUsuarios_Load);
            this.groupBoxUsuario.ResumeLayout(false);
            this.groupBoxUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).EndInit();
            this.gBoxAlterar.ResumeLayout(false);
            this.gBoxAlterar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxFechado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxAberto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxUsuario;
        private System.Windows.Forms.GroupBox gBoxAlterar;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtConf;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pBoxFechado;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.PictureBox pBoxAberto;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnProcura;
        private System.Windows.Forms.TextBox txtProcura;
        private System.Windows.Forms.DataGridView dataGridViewUsuarios;
        private System.Windows.Forms.Button btnTodos;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Label label1;
    }
}