using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Creativity_At_It_s_Worst
{
    public partial class FaceFull : Form
    {
        private static Random random = new Random();

        public FaceFull()
        {
            InitializeComponent();
        }

        private void RightEye_Button_Click(object sender, EventArgs e)
        {
            RightEye_Button.BackColor = Color.Linen;
            MessageBox.Show("OW! Don't poke my eye out!");
            RightEye_Button.BackColor = Color.Honeydew;
        }

        private void LeftEye_Button_Click(object sender, EventArgs e)
        {
            LeftEye_Button.BackColor = Color.Linen;
            MessageBox.Show(" Buy me an eye patch before you go touching my eyes!");
            LeftEye_Button.BackColor = Color.Honeydew;
        }

        private void Nose_Button_Click(object sender, EventArgs e)
        {
            Nose_Button.BackColor = Color.DarkSalmon;
            Console.Beep();
            if (!Nose_Timer.Enabled) Nose_Timer.Start();

        }

        private void Mouth_Button_Click(object sender, EventArgs e)
        {
            Mouth_Button.BackColor = Color.Linen;
            MessageBox.Show(" Tastes like chicken!");
            Mouth_Button.BackColor = Color.Maroon;
        }

        private void Nose_Timer_Tick(object sender, EventArgs e)
        {
            Nose_Button.BackColor = Color.MistyRose;
            // turn off the timer
            Nose_Timer.Enabled = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aren't my eyebrows FAAAAAAAAAAAABULOUS!");
        }

        private void Eyebrow1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("IWin32Window");
        }
    }
}
