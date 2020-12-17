using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sad
{
    public partial class sad : Form
    {
       
        protected Graphics myGraphics;
        private int currentImage = 0;
        public sad()
        {
            InitializeComponent();
            this.Panel1.Location = new System.Drawing.Point(472, 213);
            this.Panel1.Size = new System.Drawing.Size(296, 184);

        }

        private void button1_Click(object sender, EventArgs e)
        {
             
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (images.Images.Empty != true)
            {
                if (images.Images.Count - 1 > currentImage)
                {
                    currentImage++;
                }
                else
                {
                    currentImage = 0;
                }
                Panel1.Refresh();
                images.Draw(myGraphics, 10, 10, currentImage);
                PictureBox.Image = images.Images[currentImage];
                
            }

        }
    }
}
