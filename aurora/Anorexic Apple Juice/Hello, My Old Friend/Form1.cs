using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hello__My_Old_Friend
{
    public partial class EveAndZach : Form
    {
        public EveAndZach()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Console.Beep();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Resize += Button4_Resize;
        }

        private void Button4_Resize(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.Beep();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.AccessibleDescription.TrimEnd();
        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            
        }
    }
}
