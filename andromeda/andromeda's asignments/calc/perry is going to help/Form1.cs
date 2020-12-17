using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace perry_is_going_to_help
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                youragedifrence.Text=("you can marry a woman "+(wrench)+" or younger.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            youragedifrence.Text = ("you can marry a man " + (wrench) + " or older.");
        }
    }
}
