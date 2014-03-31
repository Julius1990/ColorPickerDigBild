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
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Blau.Text = this.PointToClient(Cursor.Position).ToString();
            /*int xPos = pictureBox1.Location.ToString;

            int yPos = MousePosition.Y - pictureBox1.Location.Y;

            string coor = xPos.ToString();
            coor += "/";
            coor += yPos.ToString();*/
            this.Blau.Text = pictureBox1.
        }


        private void start_Load(object sender, EventArgs e)
        {
            Bitmap schwarzRot = new Bitmap(256, 90);
            for(int y=0;y<90;y++){
                for(int x=0;x<256;x++){
                    schwarzRot.SetPixel(x,y,Color.FromArgb(x,0,0));
                }
            }
            pictureBox1.Image=schwarzRot;

            Bitmap gruenBlau = new Bitmap(1024, 90);
            for (int a = 0; a < 90; a++)
            {
                for (int eins = 0; eins <=255; eins++)
                {
                    gruenBlau.SetPixel(eins,a,Color.FromArgb(255,eins,0));
                }
                for (int zwei = 0; zwei <= 255; zwei++)
                {
                    gruenBlau.SetPixel(zwei+255,a,Color.FromArgb(255-zwei,255,0));
                }
                for (int drei = 0; drei <= 255; drei++)
                {
                    gruenBlau.SetPixel(drei + 511, a, Color.FromArgb(0, 255, drei));
                }
                for (int vier = 0; vier <= 255; vier++)
                {
                    gruenBlau.SetPixel(vier + 767, a, Color.FromArgb(0, 255 - vier, 255));
                }
            }
            pictureBox2.Image=gruenBlau;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Size = new System.Drawing.Size(255, 90);
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Blau_TextChanged(object sender, EventArgs e)
        {
            
        }

    }
}
