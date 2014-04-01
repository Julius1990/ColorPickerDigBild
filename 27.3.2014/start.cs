﻿using System;
using System.IO;
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


        private void start_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;   //Windows Form Größe automatisch anpassen
            //this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.Cursor = Cursors.Default;

            schwarz_rot();
            regenbogen();
            pictureBox5.Enabled = false;
            //pictureBox5.MaximumSize = new System.Drawing.Size(1280, 768);
            pictureBox5.SizeMode = PictureBoxSizeMode.AutoSize;

        }

        //-----------------------------------------------------------------------------------------------------------------------------
        //Text Boxes


        private void Blau_TextChanged(object sender, EventArgs e)
        {

        }

        private void Rot_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void GruenP2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        //-----------------------------------------------------------------------------------------------------------------------------
        //Labels

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        //-----------------------------------------------------------------------------------------------------------------------------
        //Picture Box Click Events

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        //--------------------------------------------------------------------------------------------------------------------------------
        //eigene Funktionen

        private void schwarz_rot()
        {
            Bitmap schwarzRot = new Bitmap(256, 40);
            for (int y = 0; y < 40; y++)
            {
                for (int x = 0; x < 256; x++)
                {
                    schwarzRot.SetPixel(x, y, Color.FromArgb(x, 0, 0));
                }
            }

            pictureBox1.Image = schwarzRot;
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void regenbogen()
        {
            Bitmap gruenBlau = new Bitmap(1024, 40);
            for (int a = 0; a < 40; a++)
            {
                int teiler = 4;
                for (int eins = 0; eins <= 255; eins++)
                {
                    gruenBlau.SetPixel(eins / teiler, a, Color.FromArgb(255, eins, 0));
                }
                for (int zwei = 0; zwei <= 255; zwei++)
                {
                    gruenBlau.SetPixel((zwei + 255) / teiler, a, Color.FromArgb(255 - zwei, 255, 0));
                }
                for (int drei = 0; drei <= 255; drei++)
                {
                    gruenBlau.SetPixel((drei + 511) / teiler, a, Color.FromArgb(0, 255, drei));
                }
                for (int vier = 0; vier <= 255; vier++)
                {
                    gruenBlau.SetPixel((vier + 767) / teiler, a, Color.FromArgb(0, 255 - vier, 255));
                }
            }
            pictureBox2.Image = gruenBlau;
            pictureBox2.Size = new System.Drawing.Size(255, 40);
        }

        private void einzelfarbe(Color c)
        {
            Bitmap filler = new Bitmap(50, 100);
            for (int a = 0; a < 50; a++)
            {
                for (int b = 0; b < 100; b++)
                {
                    filler.SetPixel(a, b, c);
                }
            }
            pictureBox3.Image = filler;
        }

        private void pictureBox5_open_picture()
        {
            Bitmap myBit = (Bitmap)Image.FromFile(openFileDialog1.FileName);

            pictureBox5.Image = myBit;

            this.pictureBox5.Size = new System.Drawing.Size(myBit.Size.Width, myBit.Size.Height);
        }

        private void change_to_greymap()
        {
            Bitmap greyBitmap = new Bitmap(pictureBox5.Image.Width, pictureBox5.Image.Height);
            Bitmap origBitmap = (Bitmap) pictureBox5.Image;

            for (int x = 0; x < pictureBox5.Image.Width; x++)
            {
                for (int y = 0; y < pictureBox5.Image.Height; y++)
                {
                    Color orig = origBitmap.GetPixel(x, y);

                    int grey = (int)((orig.R * 0.3) + (orig.G * 0.59) + (orig.B * 0.11));

                    Color neueFarbe = Color.FromArgb(grey,grey,grey);

                    greyBitmap.SetPixel(x, y, neueFarbe);
                }
            }

            pictureBox5.Image = greyBitmap;
        }


        //---------------------------------------------------------------------------------------------------------------------------------
        //PictureBoxes MouseOver


        private void pictureBox1_mouseOver(object sender, System.Windows.Forms.MouseEventArgs e)    //PictureBox 1
        {
            this.pictureBox1.Cursor = Cursors.Cross;

            Bitmap myBit = (Bitmap)pictureBox1.Image;
            Color myColor = myBit.GetPixel(e.X, e.Y);

            this.RotP2.Text = myColor.R.ToString();
            this.GruenP2.Text = myColor.G.ToString();
            this.BlauP2.Text = myColor.B.ToString();

            this.hue.Text = myColor.GetHue().ToString();
            this.sat.Text = myColor.GetSaturation().ToString();
            this.bright.Text = myColor.GetBrightness().ToString();

            einzelfarbe(myColor);
        }

        private void pictureBox2_mouseOver(object sender, System.Windows.Forms.MouseEventArgs e)        //PictureBox 2
        {
            this.pictureBox2.Cursor = Cursors.Cross;
            
            Bitmap myBit = (Bitmap)pictureBox2.Image;
            Color myColor = myBit.GetPixel(e.X, e.Y);

            this.RotP2.Text = myColor.R.ToString();
            this.GruenP2.Text = myColor.G.ToString();
            this.BlauP2.Text = myColor.B.ToString();

            this.hue.Text = myColor.GetHue().ToString();
            this.sat.Text = myColor.GetSaturation().ToString();
            this.bright.Text = myColor.GetBrightness().ToString();

            einzelfarbe(myColor);
        }


        private void pictureBox5_mouseOver(object sender, System.Windows.Forms.MouseEventArgs e)        //PictureBox 4
        {
            Cursor = Cursors.Cross;

            Bitmap myBit=(Bitmap)pictureBox5.Image;
            Color myColor = myBit.GetPixel(e.X, e.Y);

            this.RotP2.Text = myColor.R.ToString();
            this.GruenP2.Text = myColor.G.ToString();
            this.BlauP2.Text = myColor.B.ToString();

            this.hue.Text = myColor.GetHue().ToString();
            this.sat.Text = myColor.GetSaturation().ToString();
            this.bright.Text = myColor.GetBrightness().ToString();

            einzelfarbe(myColor);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {                
                string file = openFileDialog1.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    size = text.Length;
                    pictureBox5.Enabled = true;
                    pictureBox5_open_picture();
                }
                catch (IOException)
                {
                }
            }
            Console.WriteLine(size); // <-- Shows file size in debugging mode.
            Console.WriteLine(result); // <-- For debugging use.
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Farbe->Greymap")
            {
                change_to_greymap();
            }
            else if (comboBox1.Text == "Greymap->Farbe")
            {
                MessageBox.Show("erstes");
            }
            
            
        }
    }
}


