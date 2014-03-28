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
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Calc_Click(object sender, EventArgs e)
        {
            double brutto, steuer, netto;
            brutto = Convert.ToDouble(this.TxtBrutto.Text);
            steuer = Convert.ToDouble(this.TxtSteuer.Text);
            netto = brutto * 100 / (100 + steuer);
            this.TxtNetto.Text = netto.ToString();
        }
    }
}
