using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearnWindowsForms
{
    public partial class FormCheeks : Form
    {
        public FormCheeks()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void makeSomeNoiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.Beep();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void openThingyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("I'm about to fart! Watch out!", "WARNING!", MessageBoxButtons.OK);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(comboBox1.SelectedItem.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Orange;
        }
    }
}
