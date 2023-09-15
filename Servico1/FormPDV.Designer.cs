namespace Servico1
{
    
    partial class FormPDV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPDV));
            this.labelPdv = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblAnuncio = new System.Windows.Forms.Label();
            this.txtBoxEnd = new System.Windows.Forms.TextBox();
            this.txtBoxDoc = new System.Windows.Forms.TextBox();
            this.txtBoxTel = new System.Windows.Forms.TextBox();
            this.txtBoxNome = new System.Windows.Forms.TextBox();
            this.lblDoc = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblTel = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBoxControleItem = new System.Windows.Forms.GroupBox();
            this.btnApagar = new System.Windows.Forms.Button();
            this.btnAlterarNota = new System.Windows.Forms.Button();
            this.lblSelecao = new System.Windows.Forms.Label();
            this.btnSelecionar = new System.Windows.Forms.Button();
            this.numeric = new System.Windows.Forms.NumericUpDown();
            this.groupBoxItem = new System.Windows.Forms.GroupBox();
            this.txtBoxDesc = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBoxValor = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.txtBoxValorPago = new System.Windows.Forms.TextBox();
            this.comboBoxQt = new System.Windows.Forms.ComboBox();
            this.comboBoxTipo = new System.Windows.Forms.ComboBox();
            this.lblQt = new System.Windows.Forms.Label();
            this.lblItem = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtBoxItem = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.checkBoxFora = new System.Windows.Forms.CheckBox();
            this.checkBoxOficina = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.axAcroPDF2 = new AxAcroPDFLib.AxAcroPDF();
            this.btnFantasmaRegistro = new System.Windows.Forms.Button();
            this.picBoxRodape = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRegistro = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.groupBoxCliente = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBoxControleItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric)).BeginInit();
            this.groupBoxItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxRodape)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelPdv
            // 
            this.labelPdv.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelPdv.BackColor = System.Drawing.SystemColors.Highlight;
            this.labelPdv.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPdv.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.labelPdv.Location = new System.Drawing.Point(608, 4);
            this.labelPdv.Name = "labelPdv";
            this.labelPdv.Size = new System.Drawing.Size(584, 66);
            this.labelPdv.TabIndex = 4;
            this.labelPdv.Text = "PONTO DE VENDA";
            this.labelPdv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 126);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(519, 917);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(28, 114);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(458, 641);
            this.tabControl1.TabIndex = 36;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.tabPage1.Controls.Add(this.groupBoxCliente);
            this.tabPage1.Location = new System.Drawing.Point(4, 37);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(450, 600);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cliente";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // lblAnuncio
            // 
            this.lblAnuncio.BackColor = System.Drawing.Color.White;
            this.lblAnuncio.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnuncio.Location = new System.Drawing.Point(15, 217);
            this.lblAnuncio.Name = "lblAnuncio";
            this.lblAnuncio.Size = new System.Drawing.Size(355, 78);
            this.lblAnuncio.TabIndex = 26;
            this.lblAnuncio.Text = "Anuncio:";
            this.lblAnuncio.Click += new System.EventHandler(this.lblAnuncio_Click);
            // 
            // txtBoxEnd
            // 
            this.txtBoxEnd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxEnd.Location = new System.Drawing.Point(145, 155);
            this.txtBoxEnd.Name = "txtBoxEnd";
            this.txtBoxEnd.Size = new System.Drawing.Size(201, 34);
            this.txtBoxEnd.TabIndex = 3;
            this.txtBoxEnd.Click += new System.EventHandler(this.txtBoxEnd_Click);
            // 
            // txtBoxDoc
            // 
            this.txtBoxDoc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxDoc.Location = new System.Drawing.Point(145, 115);
            this.txtBoxDoc.Name = "txtBoxDoc";
            this.txtBoxDoc.Size = new System.Drawing.Size(201, 34);
            this.txtBoxDoc.TabIndex = 2;
            this.txtBoxDoc.Click += new System.EventHandler(this.txtBoxDoc_Click);
            // 
            // txtBoxTel
            // 
            this.txtBoxTel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxTel.Location = new System.Drawing.Point(145, 74);
            this.txtBoxTel.Name = "txtBoxTel";
            this.txtBoxTel.Size = new System.Drawing.Size(201, 34);
            this.txtBoxTel.TabIndex = 1;
            this.txtBoxTel.Click += new System.EventHandler(this.txtBoxTelefone_Click);
            this.txtBoxTel.TextChanged += new System.EventHandler(this.txtBoxTelefone_TextChanged);
            this.txtBoxTel.Leave += new System.EventHandler(this.textBox2_Leave);
            // 
            // txtBoxNome
            // 
            this.txtBoxNome.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtBoxNome.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtBoxNome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxNome.Location = new System.Drawing.Point(145, 31);
            this.txtBoxNome.Margin = new System.Windows.Forms.Padding(5);
            this.txtBoxNome.Name = "txtBoxNome";
            this.txtBoxNome.Size = new System.Drawing.Size(201, 34);
            this.txtBoxNome.TabIndex = 0;
            this.txtBoxNome.Click += new System.EventHandler(this.txtBoxNome_Click);
            this.txtBoxNome.TextChanged += new System.EventHandler(this.txtBoxNome_TextChanged);
            this.txtBoxNome.Enter += new System.EventHandler(this.textBox1_Enter);
            this.txtBoxNome.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.txtBoxNome.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // lblDoc
            // 
            this.lblDoc.AutoSize = true;
            this.lblDoc.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblDoc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoc.Location = new System.Drawing.Point(23, 118);
            this.lblDoc.Name = "lblDoc";
            this.lblDoc.Size = new System.Drawing.Size(119, 28);
            this.lblDoc.TabIndex = 7;
            this.lblDoc.Text = "Documento:";
            this.lblDoc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblEnd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnd.Location = new System.Drawing.Point(42, 158);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(97, 28);
            this.lblEnd.TabIndex = 9;
            this.lblEnd.Text = "Endereço:";
            this.lblEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblTel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTel.Location = new System.Drawing.Point(56, 77);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(88, 28);
            this.lblTel.TabIndex = 6;
            this.lblTel.Text = "Telefone:";
            this.lblTel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblNome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.Location = new System.Drawing.Point(70, 34);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(70, 28);
            this.lblNome.TabIndex = 5;
            this.lblNome.Text = "Nome:";
            this.lblNome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.tabPage2.Controls.Add(this.groupBoxControleItem);
            this.tabPage2.Controls.Add(this.groupBoxItem);
            this.tabPage2.Location = new System.Drawing.Point(4, 37);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(450, 600);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Item";
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // groupBoxControleItem
            // 
            this.groupBoxControleItem.Controls.Add(this.btnApagar);
            this.groupBoxControleItem.Controls.Add(this.btnAlterarNota);
            this.groupBoxControleItem.Controls.Add(this.lblSelecao);
            this.groupBoxControleItem.Controls.Add(this.btnSelecionar);
            this.groupBoxControleItem.Controls.Add(this.numeric);
            this.groupBoxControleItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxControleItem.Location = new System.Drawing.Point(24, 397);
            this.groupBoxControleItem.Name = "groupBoxControleItem";
            this.groupBoxControleItem.Size = new System.Drawing.Size(403, 156);
            this.groupBoxControleItem.TabIndex = 40;
            this.groupBoxControleItem.TabStop = false;
            this.groupBoxControleItem.Text = "Controle de item";
            // 
            // btnApagar
            // 
            this.btnApagar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApagar.Location = new System.Drawing.Point(291, 108);
            this.btnApagar.Name = "btnApagar";
            this.btnApagar.Size = new System.Drawing.Size(97, 37);
            this.btnApagar.TabIndex = 44;
            this.btnApagar.Text = "Apagar";
            this.btnApagar.UseVisualStyleBackColor = true;
            this.btnApagar.Click += new System.EventHandler(this.btnApagar_Click);
            // 
            // btnAlterarNota
            // 
            this.btnAlterarNota.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterarNota.Location = new System.Drawing.Point(125, 108);
            this.btnAlterarNota.Name = "btnAlterarNota";
            this.btnAlterarNota.Size = new System.Drawing.Size(97, 37);
            this.btnAlterarNota.TabIndex = 43;
            this.btnAlterarNota.Text = "Alterar";
            this.btnAlterarNota.UseVisualStyleBackColor = true;
            this.btnAlterarNota.Click += new System.EventHandler(this.btnAlterarNota_Click);
            // 
            // lblSelecao
            // 
            this.lblSelecao.AutoSize = true;
            this.lblSelecao.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelecao.Location = new System.Drawing.Point(3, 26);
            this.lblSelecao.Name = "lblSelecao";
            this.lblSelecao.Size = new System.Drawing.Size(226, 28);
            this.lblSelecao.TabIndex = 42;
            this.lblSelecao.Text = "Seleção de item da nota:";
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecionar.Location = new System.Drawing.Point(22, 108);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(97, 37);
            this.btnSelecionar.TabIndex = 41;
            this.btnSelecionar.Text = "Selecionar";
            this.btnSelecionar.UseVisualStyleBackColor = true;
            this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionar_Click);
            // 
            // numeric
            // 
            this.numeric.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numeric.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeric.Location = new System.Drawing.Point(234, 34);
            this.numeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric.Name = "numeric";
            this.numeric.ReadOnly = true;
            this.numeric.Size = new System.Drawing.Size(44, 30);
            this.numeric.TabIndex = 0;
            this.numeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric.ValueChanged += new System.EventHandler(this.numeric_ValueChanged);
            // 
            // groupBoxItem
            // 
            this.groupBoxItem.Controls.Add(this.txtBoxDesc);
            this.groupBoxItem.Controls.Add(this.label10);
            this.groupBoxItem.Controls.Add(this.txtBoxValor);
            this.groupBoxItem.Controls.Add(this.label8);
            this.groupBoxItem.Controls.Add(this.lblValor);
            this.groupBoxItem.Controls.Add(this.txtBoxValorPago);
            this.groupBoxItem.Controls.Add(this.comboBoxQt);
            this.groupBoxItem.Controls.Add(this.comboBoxTipo);
            this.groupBoxItem.Controls.Add(this.lblQt);
            this.groupBoxItem.Controls.Add(this.lblItem);
            this.groupBoxItem.Controls.Add(this.lblDesc);
            this.groupBoxItem.Controls.Add(this.txtBoxItem);
            this.groupBoxItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxItem.Location = new System.Drawing.Point(24, 6);
            this.groupBoxItem.Name = "groupBoxItem";
            this.groupBoxItem.Size = new System.Drawing.Size(403, 385);
            this.groupBoxItem.TabIndex = 39;
            this.groupBoxItem.TabStop = false;
            this.groupBoxItem.Text = "Adiciona item";
            // 
            // txtBoxDesc
            // 
            this.txtBoxDesc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxDesc.Location = new System.Drawing.Point(29, 180);
            this.txtBoxDesc.Name = "txtBoxDesc";
            this.txtBoxDesc.Size = new System.Drawing.Size(299, 102);
            this.txtBoxDesc.TabIndex = 7;
            this.txtBoxDesc.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(34, 293);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(188, 28);
            this.label10.TabIndex = 38;
            this.label10.Text = "Tipo de pagamento:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBoxValor
            // 
            this.txtBoxValor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtBoxValor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtBoxValor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxValor.Location = new System.Drawing.Point(164, 69);
            this.txtBoxValor.Margin = new System.Windows.Forms.Padding(5);
            this.txtBoxValor.Name = "txtBoxValor";
            this.txtBoxValor.Size = new System.Drawing.Size(102, 34);
            this.txtBoxValor.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(113, 333);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 28);
            this.label8.TabIndex = 37;
            this.label8.Text = "Total pago:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblValor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.Location = new System.Drawing.Point(22, 72);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(134, 28);
            this.lblValor.TabIndex = 18;
            this.lblValor.Text = "Valor do item:";
            this.lblValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBoxValorPago
            // 
            this.txtBoxValorPago.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtBoxValorPago.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtBoxValorPago.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxValorPago.Location = new System.Drawing.Point(234, 333);
            this.txtBoxValorPago.Margin = new System.Windows.Forms.Padding(5);
            this.txtBoxValorPago.Name = "txtBoxValorPago";
            this.txtBoxValorPago.Size = new System.Drawing.Size(105, 34);
            this.txtBoxValorPago.TabIndex = 31;
            this.txtBoxValorPago.Leave += new System.EventHandler(this.txtBoxValorPago_Leave);
            // 
            // comboBoxQt
            // 
            this.comboBoxQt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxQt.FormattingEnabled = true;
            this.comboBoxQt.Location = new System.Drawing.Point(164, 109);
            this.comboBoxQt.Name = "comboBoxQt";
            this.comboBoxQt.Size = new System.Drawing.Size(77, 36);
            this.comboBoxQt.TabIndex = 6;
            this.comboBoxQt.Click += new System.EventHandler(this.comboBoxQt_Click);
            // 
            // comboBoxTipo
            // 
            this.comboBoxTipo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTipo.FormattingEnabled = true;
            this.comboBoxTipo.Location = new System.Drawing.Point(234, 289);
            this.comboBoxTipo.Name = "comboBoxTipo";
            this.comboBoxTipo.Size = new System.Drawing.Size(129, 36);
            this.comboBoxTipo.TabIndex = 32;
            this.comboBoxTipo.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipo_SelectedIndexChanged);
            this.comboBoxTipo.Click += new System.EventHandler(this.comboBoxTipo_Click);
            // 
            // lblQt
            // 
            this.lblQt.AutoSize = true;
            this.lblQt.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblQt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQt.Location = new System.Drawing.Point(37, 112);
            this.lblQt.Margin = new System.Windows.Forms.Padding(0);
            this.lblQt.Name = "lblQt";
            this.lblQt.Size = new System.Drawing.Size(119, 28);
            this.lblQt.TabIndex = 22;
            this.lblQt.Text = "Quantidade:";
            this.lblQt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.Location = new System.Drawing.Point(101, 34);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(55, 28);
            this.lblItem.TabIndex = 16;
            this.lblItem.Text = "Item:";
            this.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblDesc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDesc.Location = new System.Drawing.Point(21, 148);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(100, 28);
            this.lblDesc.TabIndex = 20;
            this.lblDesc.Text = "Descrição:";
            this.lblDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBoxItem
            // 
            this.txtBoxItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtBoxItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtBoxItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxItem.Location = new System.Drawing.Point(164, 31);
            this.txtBoxItem.Margin = new System.Windows.Forms.Padding(5);
            this.txtBoxItem.Name = "txtBoxItem";
            this.txtBoxItem.Size = new System.Drawing.Size(213, 34);
            this.txtBoxItem.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(516, 54);
            this.label7.TabIndex = 13;
            this.label7.Text = "Entrada de dados";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox5
            // 
            this.textBox5.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBox5.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(1041, 630);
            this.textBox5.Margin = new System.Windows.Forms.Padding(5);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(83, 30);
            this.textBox5.TabIndex = 28;
            this.textBox5.Visible = false;
            this.textBox5.Leave += new System.EventHandler(this.textBox5_Leave);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.Info;
            this.label12.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(913, 627);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(120, 36);
            this.label12.TabIndex = 30;
            this.label12.Text = "Km rodado:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label12.Visible = false;
            // 
            // checkBoxFora
            // 
            this.checkBoxFora.AutoSize = true;
            this.checkBoxFora.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxFora.Location = new System.Drawing.Point(1177, 584);
            this.checkBoxFora.Name = "checkBoxFora";
            this.checkBoxFora.Size = new System.Drawing.Size(99, 27);
            this.checkBoxFora.TabIndex = 27;
            this.checkBoxFora.Text = "socorro";
            this.checkBoxFora.UseVisualStyleBackColor = true;
            this.checkBoxFora.Visible = false;
            this.checkBoxFora.CheckedChanged += new System.EventHandler(this.checkBoxFora_CheckedChanged_1);
            // 
            // checkBoxOficina
            // 
            this.checkBoxOficina.AutoSize = true;
            this.checkBoxOficina.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxOficina.Location = new System.Drawing.Point(1054, 584);
            this.checkBoxOficina.Name = "checkBoxOficina";
            this.checkBoxOficina.Size = new System.Drawing.Size(115, 27);
            this.checkBoxOficina.TabIndex = 26;
            this.checkBoxOficina.Text = "na oficina";
            this.checkBoxOficina.UseVisualStyleBackColor = true;
            this.checkBoxOficina.Visible = false;
            this.checkBoxOficina.CheckedChanged += new System.EventHandler(this.checkBoxOficina_CheckedChanged_1);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.Info;
            this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(914, 579);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(120, 34);
            this.label11.TabIndex = 29;
            this.label11.Text = "Diagnóstico:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label11.Visible = false;
            // 
            // axAcroPDF2
            // 
            this.axAcroPDF2.Enabled = true;
            this.axAcroPDF2.Location = new System.Drawing.Point(722, 126);
            this.axAcroPDF2.Name = "axAcroPDF2";
            this.axAcroPDF2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF2.OcxState")));
            this.axAcroPDF2.Size = new System.Drawing.Size(240, 240);
            this.axAcroPDF2.TabIndex = 31;
            // 
            // btnFantasmaRegistro
            // 
            this.btnFantasmaRegistro.Location = new System.Drawing.Point(614, 41);
            this.btnFantasmaRegistro.Name = "btnFantasmaRegistro";
            this.btnFantasmaRegistro.Size = new System.Drawing.Size(75, 23);
            this.btnFantasmaRegistro.TabIndex = 37;
            this.btnFantasmaRegistro.Text = "button1";
            this.btnFantasmaRegistro.UseVisualStyleBackColor = true;
            this.btnFantasmaRegistro.Click += new System.EventHandler(this.btnFantasmaRegistro_Click);
            // 
            // picBoxRodape
            // 
            this.picBoxRodape.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.picBoxRodape.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picBoxRodape.Location = new System.Drawing.Point(668, 407);
            this.picBoxRodape.Name = "picBoxRodape";
            this.picBoxRodape.Size = new System.Drawing.Size(98, 39);
            this.picBoxRodape.TabIndex = 15;
            this.picBoxRodape.TabStop = false;
            this.picBoxRodape.Paint += new System.Windows.Forms.PaintEventHandler(this.picBoxRodape_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Highlight;
            this.pictureBox1.Location = new System.Drawing.Point(588, 117);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(101, 72);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btnRegistro
            // 
            this.btnRegistro.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistro.Location = new System.Drawing.Point(568, 624);
            this.btnRegistro.Name = "btnRegistro";
            this.btnRegistro.Size = new System.Drawing.Size(109, 43);
            this.btnRegistro.TabIndex = 40;
            this.btnRegistro.Text = "Registrar";
            this.btnRegistro.UseVisualStyleBackColor = true;
            this.btnRegistro.Click += new System.EventHandler(this.btnRegistro_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Location = new System.Drawing.Point(568, 675);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(109, 43);
            this.btnSalvar.TabIndex = 41;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizar.Location = new System.Drawing.Point(568, 731);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(109, 43);
            this.btnFinalizar.TabIndex = 42;
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfig.Location = new System.Drawing.Point(568, 876);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(109, 43);
            this.btnConfig.TabIndex = 44;
            this.btnConfig.Text = "Configurar";
            this.btnConfig.UseVisualStyleBackColor = true;
            // 
            // btnFechar
            // 
            this.btnFechar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.Location = new System.Drawing.Point(568, 925);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(109, 43);
            this.btnFechar.TabIndex = 45;
            this.btnFechar.Text = "Fechar(ESC)";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Location = new System.Drawing.Point(568, 777);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(109, 43);
            this.btnImprimir.TabIndex = 46;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // groupBoxCliente
            // 
            this.groupBoxCliente.Controls.Add(this.txtBoxNome);
            this.groupBoxCliente.Controls.Add(this.lblAnuncio);
            this.groupBoxCliente.Controls.Add(this.lblNome);
            this.groupBoxCliente.Controls.Add(this.txtBoxEnd);
            this.groupBoxCliente.Controls.Add(this.lblTel);
            this.groupBoxCliente.Controls.Add(this.txtBoxDoc);
            this.groupBoxCliente.Controls.Add(this.lblEnd);
            this.groupBoxCliente.Controls.Add(this.txtBoxTel);
            this.groupBoxCliente.Controls.Add(this.lblDoc);
            this.groupBoxCliente.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCliente.Location = new System.Drawing.Point(24, 6);
            this.groupBoxCliente.Name = "groupBoxCliente";
            this.groupBoxCliente.Size = new System.Drawing.Size(402, 588);
            this.groupBoxCliente.TabIndex = 27;
            this.groupBoxCliente.TabStop = false;
            this.groupBoxCliente.Text = "Adiciona cliente";
            // 
            // FormPDV
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnRegistro);
            this.Controls.Add(this.axAcroPDF2);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.checkBoxFora);
            this.Controls.Add(this.checkBoxOficina);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.picBoxRodape);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelPdv);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnFantasmaRegistro);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPDV";
            this.ShowIcon = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPDV_FormClosing);
            this.Load += new System.EventHandler(this.FormPDV_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormPDV_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormPDV_KeyPress);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBoxControleItem.ResumeLayout(false);
            this.groupBoxControleItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric)).EndInit();
            this.groupBoxItem.ResumeLayout(false);
            this.groupBoxItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxRodape)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxCliente.ResumeLayout(false);
            this.groupBoxCliente.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelPdv;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox picBoxRodape;
        private AxAcroPDFLib.AxAcroPDF axAcroPDF2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox checkBoxFora;
        private System.Windows.Forms.CheckBox checkBoxOficina;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnFantasmaRegistro;
        private System.Windows.Forms.Button btnRegistro;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblAnuncio;
        private System.Windows.Forms.TextBox txtBoxEnd;
        private System.Windows.Forms.TextBox txtBoxDoc;
        private System.Windows.Forms.TextBox txtBoxTel;
        private System.Windows.Forms.TextBox txtBoxNome;
        private System.Windows.Forms.Label lblDoc;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBoxControleItem;
        private System.Windows.Forms.Button btnApagar;
        private System.Windows.Forms.Button btnAlterarNota;
        private System.Windows.Forms.Label lblSelecao;
        private System.Windows.Forms.Button btnSelecionar;
        private System.Windows.Forms.NumericUpDown numeric;
        private System.Windows.Forms.GroupBox groupBoxItem;
        private System.Windows.Forms.RichTextBox txtBoxDesc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBoxValor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.TextBox txtBoxValorPago;
        private System.Windows.Forms.ComboBox comboBoxQt;
        private System.Windows.Forms.ComboBox comboBoxTipo;
        private System.Windows.Forms.Label lblQt;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtBoxItem;
        private System.Windows.Forms.GroupBox groupBoxCliente;
    }
}