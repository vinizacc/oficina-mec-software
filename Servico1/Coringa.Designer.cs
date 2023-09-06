namespace Braga
{
    partial class Coringa
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
            this.btnCoringa = new System.Windows.Forms.Button();
            this.txtCoringa = new System.Windows.Forms.TextBox();
            this.rich = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnCoringa
            // 
            this.btnCoringa.Location = new System.Drawing.Point(312, 91);
            this.btnCoringa.Name = "btnCoringa";
            this.btnCoringa.Size = new System.Drawing.Size(100, 42);
            this.btnCoringa.TabIndex = 0;
            this.btnCoringa.Text = "Texto";
            this.btnCoringa.UseVisualStyleBackColor = true;
            this.btnCoringa.Click += new System.EventHandler(this.btnCoringa_Click);
            // 
            // txtCoringa
            // 
            this.txtCoringa.Location = new System.Drawing.Point(49, 46);
            this.txtCoringa.Name = "txtCoringa";
            this.txtCoringa.Size = new System.Drawing.Size(363, 22);
            this.txtCoringa.TabIndex = 1;
            // 
            // rich
            // 
            this.rich.Location = new System.Drawing.Point(61, 154);
            this.rich.Name = "rich";
            this.rich.Size = new System.Drawing.Size(351, 335);
            this.rich.TabIndex = 2;
            this.rich.Text = "";
            // 
            // Coringa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 531);
            this.Controls.Add(this.rich);
            this.Controls.Add(this.txtCoringa);
            this.Controls.Add(this.btnCoringa);
            this.Name = "Coringa";
            this.Text = "Coringa";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCoringa;
        private System.Windows.Forms.TextBox txtCoringa;
        private System.Windows.Forms.RichTextBox rich;
    }
}