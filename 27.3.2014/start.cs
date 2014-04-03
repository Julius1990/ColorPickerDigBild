using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _27._3._2014
{
    public partial class start : Form
    {
        int greyscale = 0;
        int pseudocol = 0;

        //rückgängig
        Bitmap letzte;
        int last_grey = -1;
        int last_pseudo = -1;

        public start()
        {
            InitializeComponent();

            //main
            schwarz_rot();
            regenbogen();
            
        }
        
        public void start_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;   //Windows Form Größe automatisch anpassen
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.Cursor = Cursors.Default;

            pictureBox5.Enabled = false;
            pictureBox6.Enabled = false;
            //pictureBox5.MaximumSize = new System.Drawing.Size(1280, 768);

            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
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
            reset_save();

            //this.pictureBox5.Size = new System.Drawing.Size(myBit.Size.Width, myBit.Size.Height);
        }

        private void change_to_greymap()
        {
            schritt_speichern((Bitmap)pictureBox5.Image);

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

        private void pseudo_coloring()
        {
            schritt_speichern((Bitmap)pictureBox5.Image);

            Bitmap pseudoMap = new Bitmap(pictureBox5.Image.Width, pictureBox5.Image.Height);
            Bitmap origBitmap = (Bitmap)pictureBox5.Image;

            for (int x = 0; x < pictureBox5.Image.Width; x++)
            {
                for (int y = 0; y < pictureBox5.Image.Height; y++)
                {
                    Color origColor = origBitmap.GetPixel(x, y);
                    double i = origColor.R;

                    // Neue Farbe [-1,1]:
                    double red = Math.Sin(i * 2 * Math.PI / 255d - Math.PI);
                    double green = Math.Sin(i * 2 * Math.PI / 255d - Math.PI / 2);
                    double blue = Math.Sin(i * 2 * Math.PI / 255d);

                    // Neue Farbe [0,255]:
                    red = (red + 1) * 0.5 * 255;
                    green = (green + 1) * 0.5 * 255;
                    blue = (blue + 1) * 0.5 * 255;

                    Color newColor = Color.FromArgb((int)red, (int)green, (int)blue);

                    pseudoMap.SetPixel(x, y, newColor);
                }
            }
            pictureBox5.Image = pseudoMap;
        }

        private void search_lego_colors()
        {
            schritt_speichern((Bitmap)pictureBox5.Image);

            Bitmap greyBitmap = new Bitmap(pictureBox5.Image.Width, pictureBox5.Image.Height);
            Bitmap origBitmap = (Bitmap)pictureBox5.Image;

            for (int x = 0; x < pictureBox5.Image.Width; x++)
            {
                for (int y = 0; y < pictureBox5.Image.Height; y++)
                {
                    Color orig = origBitmap.GetPixel(x, y);
                    Color newColor;

                    if (((orig.GetHue() >= 0 && orig.GetHue()< 15)||(orig.GetHue()>350)) && orig.GetSaturation()>0.2 && orig.GetBrightness()>0.25)
                    {
                        newColor = Color.FromArgb(196, 40, 27);
                    }
                    else if (orig.R > 240 && orig.G > 240 && orig.B > 240 && orig.GetSaturation() > 0.2 && orig.GetBrightness() > 0.25)
                    {
                        newColor = Color.FromArgb(255, 255, 255);
                    }
                    else if ((orig.GetHue() >= 190 && orig.GetHue() < 250) && orig.GetSaturation() > 0.2 && orig.GetBrightness() > 0.25)
                    {
                        newColor = Color.FromArgb(13, 105, 171);
                    }
                    else if (orig.R > 240 && orig.G > 240 && orig.B > 240 && orig.GetSaturation() > 0.2 && orig.GetBrightness() > 0.25)
                    {
                        newColor = Color.FromArgb(255,255,255);
                    }
                    else if ((orig.GetHue() > 50 && orig.GetHue() < 65) && orig.GetSaturation() > 0.4 && orig.GetBrightness() > 0.25)
                    {
                        newColor = Color.FromArgb(245, 205, 47);    //gelb
                    }
                    else if ((orig.GetHue() > 110 && orig.GetHue() < 150) && orig.GetSaturation() > 0.2 && orig.GetBrightness() > 0.1)
                    {
                        newColor = Color.FromArgb(40, 127, 70);
                    }
                    else
                    {
                        int grey = (int)((orig.R * 0.3) + (orig.G * 0.59) + (orig.B * 0.11));

                        newColor = Color.FromArgb(grey, grey, grey);
                    }

                    greyBitmap.SetPixel(x, y, newColor);
                }
            }

            pictureBox5.Image = greyBitmap;
        }

        private void schritt_speichern(Bitmap save)
        {
            letzte = save;
            last_grey = greyscale;
            last_pseudo = pseudocol;
        }

        private void wiederholen()
        {
            pictureBox5.Image = letzte;
            greyscale = last_grey;
            pseudocol = last_pseudo;
        }

        private void reset_save()
        {
            letzte = null;
            greyscale = 0;
            pseudocol = 0;
            last_grey = -1;
            last_pseudo = -1;
        }

        private void ResizeAndDisplayImage(PictureBox pix)
        {
            Color _BackColor = Color.FromArgb(255, 255, 255);

            pix.BackColor = _BackColor;

            Image _OriginalImage = Image.FromFile(openFileDialog1.FileName);

            int sourceWidth = _OriginalImage.Width;
            int sourceHeight = _OriginalImage.Height;
            int targetWidth;
            int targetHeight;
            double ratio;

            // Calculate targetWidth and targetHeight, so that the image will fit into

            // the picImage picturebox without changing the proportions of the image.

            if (sourceWidth > sourceHeight)
            {
                // Set the new width

                targetWidth = pix.Width;
                // Calculate the ratio of the new width against the original width

                ratio = (double)targetWidth / sourceWidth;
                // Calculate a new height that is in proportion with the original image

                targetHeight = (int)(ratio * sourceHeight);
            }
            else if (sourceWidth < sourceHeight)
            {
                // Set the new height

                targetHeight = pictureBox6.Height;
                // Calculate the ratio of the new height against the original height

                ratio = (double)targetHeight / sourceHeight;
                // Calculate a new width that is in proportion with the original image

                targetWidth = (int)(ratio * sourceWidth);
            }
            else
            {
                // In this case, the image is square and resizing is easy

                targetHeight = pix.Height;
                targetWidth = pix.Width;
            }

            // Calculate the targetTop and targetLeft values, to center the image

            // horizontally or vertically if needed

            int targetTop = (pix.Height - targetHeight) / 2;
            int targetLeft = (pix.Width - targetWidth) / 2;

            // Create a new temporary bitmap to resize the original image

            // The size of this bitmap is the size of the picImage picturebox.

            Bitmap tempBitmap = new Bitmap(pix.Width, pix.Height);//,PixelFormat.Format24bppRgb);

            // Set the resolution of the bitmap to match the original resolution.

            tempBitmap.SetResolution(_OriginalImage.HorizontalResolution,
                                     _OriginalImage.VerticalResolution);

            // Create a Graphics object to further edit the temporary bitmap

            Graphics bmGraphics = Graphics.FromImage(tempBitmap);

            // First clear the image with the current backcolor

            bmGraphics.Clear(_BackColor);

            // Set the interpolationmode since we are resizing an image here

            bmGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // Draw the original image on the temporary bitmap, resizing it using

            // the calculated values of targetWidth and targetHeight.

            bmGraphics.DrawImage(_OriginalImage,
                                 new Rectangle(targetLeft, targetTop, targetWidth, targetHeight),
                                 new Rectangle(0, 0, sourceWidth, sourceHeight),
                                 GraphicsUnit.Pixel);

            // Dispose of the bmGraphics object

            bmGraphics.Dispose();

            // Set the image of the picImage picturebox to the temporary bitmap

            pix.Image = tempBitmap;
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

        private void pictureBox5_mouseOver(object sender, System.Windows.Forms.MouseEventArgs e)        //PictureBox 5
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
                    pictureBox6.Enabled = true;
                    ResizeAndDisplayImage(pictureBox5);
                    ResizeAndDisplayImage(pictureBox6);

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
            if (pictureBox5.Enabled)
            {
                if (comboBox1.Text == "Farbe->Greyscale")
                {
                    if (greyscale == 0)
                    {
                        change_to_greymap();
                        greyscale = 1;
                        pseudocol = 0;
                    }
                    else
                        MessageBox.Show("Bild kann nicht in Greyscale konvertiert werden");
                }
                else if (comboBox1.Text == "Greymap->Pseudofarbe")
                {
                    if (greyscale == 1 && pseudocol != 1)
                    {
                        pseudo_coloring();
                        greyscale = 0;
                        pseudocol = 1;
                    }
                    else
                        MessageBox.Show("Bild liegt nicht als Greyscale vor");
                }
                else if (comboBox1.Text == "Nach Lego suchen")
                {
                    search_lego_colors();
                }
            }
            else
                MessageBox.Show("Bitte erst ein Bild öffnen");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (letzte != null)
                wiederholen();
        }

        private void pictureBox6_mouseOver(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            
            Bitmap myBit = (Bitmap)pictureBox6.Image;
            Color myColor = myBit.GetPixel(e.X, e.Y);

            this.RotP2.Text = myColor.R.ToString();
            this.GruenP2.Text = myColor.G.ToString();
            this.BlauP2.Text = myColor.B.ToString();

            this.hue.Text = myColor.GetHue().ToString();
            this.sat.Text = myColor.GetSaturation().ToString();
            this.bright.Text = myColor.GetBrightness().ToString();

            einzelfarbe(myColor);
        }
    }
}


