using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorCrap
{
    public partial class AnotherCrappyCalculator : Form
    {
        public AnotherCrappyCalculator()
        {
            InitializeComponent();
        }

        public bool ClearScreen = false;

        public int LastNum = 0;

        public string operation_taco = null;

        private void AnotherCrappyCalculator_Load(object sender, EventArgs e)
        { 
        }

        private void AddNumber(string s)
        {
            this.label1.Text += s;
            if (label1.Text.StartsWith("0"))
            {
                label1.Text = label1.Text.TrimStart('0');
            }

            if (label1.Text == "")
            {
                this.label1.Text = "0";
            }
        }

        private void OPERATIONS(string taco)
        {
            ClearScreen = true;

            int PotatoPants = 

            if (operation_taco == "+")
            {
                label1.Text = LastNum + taco;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddNumber("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddNumber("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddNumber("3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddNumber("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddNumber("5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddNumber("6");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AddNumber("7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddNumber("8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AddNumber("9");
        }


        private void button0_Click(object sender, EventArgs e)
        {
            AddNumber("0");
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            OPERATIONS("+");
        }

        private void buttonTimes_Click(object sender, EventArgs e)
        {

        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {

        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {

        }

        private void ClearFlowers_Click(object sender, EventArgs e)
        {
        
            label1.Text = "0";
            LastNum = 0;
        }
    }
}
