using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _27._3._2014
{
    public partial class start : Form
    {
        public start()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Wirklich beenden ?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Calc_Click(object sender, EventArgs e)
        {
            double brutto, steuer, netto;
            if (double.TryParse(this.TxtBrutto.Text, out brutto))
            {
                if (double.TryParse(this.TxtSteuer.Text, out steuer))
                {
                    netto = brutto * 100 / (100 + steuer);
                    this.TxtNetto.Text = netto.ToString();
                }
                else
                {
                    // Die Steuer-Eingabe ist nicht OK 
                    this.TxtBrutto.Text = null;
                    MessageBox.Show("Der Steuerwert ist ungültig");
                }
            }
            else
            {
                // Die Brutto-Eingabe ist nicht OK 
                this.TxtBrutto.Text = null;
                MessageBox.Show("Der Bruttobetrag ist ungültig");
            }

        }

    }
}
