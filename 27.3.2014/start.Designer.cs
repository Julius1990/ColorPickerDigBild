namespace _27._3._2014
{
    partial class start
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.TxtBrutto = new System.Windows.Forms.TextBox();
            this.LblBrutto = new System.Windows.Forms.Label();
            this.LblSteuer = new System.Windows.Forms.Label();
            this.TxtSteuer = new System.Windows.Forms.TextBox();
            this.LblNetto = new System.Windows.Forms.Label();
            this.TxtNetto = new System.Windows.Forms.TextBox();
            this.close = new System.Windows.Forms.Button();
            this.Calc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtBrutto
            // 
            this.TxtBrutto.Location = new System.Drawing.Point(107, 29);
            this.TxtBrutto.Name = "TxtBrutto";
            this.TxtBrutto.Size = new System.Drawing.Size(100, 20);
            this.TxtBrutto.TabIndex = 1;
            this.TxtBrutto.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // LblBrutto
            // 
            this.LblBrutto.AutoSize = true;
            this.LblBrutto.Location = new System.Drawing.Point(22, 36);
            this.LblBrutto.Name = "LblBrutto";
            this.LblBrutto.Size = new System.Drawing.Size(35, 13);
            this.LblBrutto.TabIndex = 2;
            this.LblBrutto.Text = "Brutto";
            this.LblBrutto.Click += new System.EventHandler(this.label1_Click);
            // 
            // LblSteuer
            // 
            this.LblSteuer.AutoSize = true;
            this.LblSteuer.Location = new System.Drawing.Point(22, 84);
            this.LblSteuer.Name = "LblSteuer";
            this.LblSteuer.Size = new System.Drawing.Size(38, 13);
            this.LblSteuer.TabIndex = 4;
            this.LblSteuer.Text = "Steuer";
            // 
            // TxtSteuer
            // 
            this.TxtSteuer.Location = new System.Drawing.Point(107, 77);
            this.TxtSteuer.Name = "TxtSteuer";
            this.TxtSteuer.Size = new System.Drawing.Size(100, 20);
            this.TxtSteuer.TabIndex = 3;
            // 
            // LblNetto
            // 
            this.LblNetto.AutoSize = true;
            this.LblNetto.Location = new System.Drawing.Point(22, 133);
            this.LblNetto.Name = "LblNetto";
            this.LblNetto.Size = new System.Drawing.Size(33, 13);
            this.LblNetto.TabIndex = 6;
            this.LblNetto.Text = "Netto";
            this.LblNetto.Click += new System.EventHandler(this.label3_Click);
            // 
            // TxtNetto
            // 
            this.TxtNetto.Location = new System.Drawing.Point(107, 126);
            this.TxtNetto.Name = "TxtNetto";
            this.TxtNetto.ReadOnly = true;
            this.TxtNetto.Size = new System.Drawing.Size(100, 20);
            this.TxtNetto.TabIndex = 5;
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(132, 176);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 7;
            this.close.Text = "Schließen";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.button1_Click);
            // 
            // Calc
            // 
            this.Calc.Location = new System.Drawing.Point(25, 176);
            this.Calc.Name = "Calc";
            this.Calc.Size = new System.Drawing.Size(75, 23);
            this.Calc.TabIndex = 8;
            this.Calc.Text = "Berechnen";
            this.Calc.UseVisualStyleBackColor = true;
            this.Calc.Click += new System.EventHandler(this.Calc_Click);
            // 
            // start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.Calc);
            this.Controls.Add(this.close);
            this.Controls.Add(this.LblNetto);
            this.Controls.Add(this.TxtNetto);
            this.Controls.Add(this.LblSteuer);
            this.Controls.Add(this.TxtSteuer);
            this.Controls.Add(this.LblBrutto);
            this.Controls.Add(this.TxtBrutto);
            this.Name = "start";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtBrutto;
        private System.Windows.Forms.Label LblBrutto;
        private System.Windows.Forms.Label LblSteuer;
        private System.Windows.Forms.TextBox TxtSteuer;
        private System.Windows.Forms.Label LblNetto;
        private System.Windows.Forms.TextBox TxtNetto;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Button Calc;

    }
}

