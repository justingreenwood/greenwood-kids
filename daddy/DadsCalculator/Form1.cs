using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DadsCalculator
{
    public partial class FormCalculator : Form
    {
        public decimal _accumulator = 0;
        private string _operation = "";
        private bool _justDidStuff = false;

        public FormCalculator()
        {
            InitializeComponent();
        }

        private void AddNumber(int num)
        {
            AddNumber(num.ToString());
        }

        private void AddNumber(string num)
        {
            if (_justDidStuff)
            {
                labelDisplay.Text = "0";
            }
            if (num == "-" && labelDisplay.Text == "0") return;
            if (num == "0" && labelDisplay.Text == "0") return;
            if (num == "." && labelDisplay.Text.Contains(".")) return;

            if (num == "-")
            {
                if (labelDisplay.Text.StartsWith("-"))
                {
                    labelDisplay.Text = labelDisplay.Text.TrimStart('-');
                }
                else
                {
                    labelDisplay.Text = "-" + labelDisplay.Text;
                }
            }
            else
            {
                labelDisplay.Text += num;
            }

            if (labelDisplay.Text.StartsWith("."))
            {
                labelDisplay.Text = "0" + labelDisplay.Text;
            }
            else if (!labelDisplay.Text.StartsWith("0."))
            {
                labelDisplay.Text = labelDisplay.Text.TrimStart('0');
            }
            _justDidStuff = false;
        }

        private void buttonAC_Click(object sender, EventArgs e)
        {
            _operation = "";
            _accumulator = 0;
            labelDisplay.Text = "0";
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '1': AddNumber(1); break;
                case '2': AddNumber(2); break;
                case '3': AddNumber(3); break;
                case '4': AddNumber(4); break;
                case '5': AddNumber(5); break;
                case '6': AddNumber(6); break;
                case '7': AddNumber(7); break;
                case '8': AddNumber(8); break;
                case '9': AddNumber(9); break;
                case '0': AddNumber(0); break;
            }
        }

        #region Number Button Events
        private void buttonOne_Click(object sender, EventArgs e)
        {
            AddNumber(1);
        }

        private void buttonTwo_Click(object sender, EventArgs e)
        {
            AddNumber(2);
        }

        private void buttonThree_Click(object sender, EventArgs e)
        {
            AddNumber(3);
        }

        private void buttonFour_Click(object sender, EventArgs e)
        {
            AddNumber(4);
        }

        private void buttonFive_Click(object sender, EventArgs e)
        {
            AddNumber(5);
        }

        private void buttonSix_Click(object sender, EventArgs e)
        {
            AddNumber(6);
        }

        private void buttonSeven_Click(object sender, EventArgs e)
        {
            AddNumber(7);
        }

        private void buttonEight_Click(object sender, EventArgs e)
        {
            AddNumber(8);
        }

        private void buttonNine_Click(object sender, EventArgs e)
        {
            AddNumber(9);
        }

        private void buttonZero_Click(object sender, EventArgs e)
        {
            AddNumber(0);
        }
        #endregion

        private void buttonDecimal_Click(object sender, EventArgs e)
        {
            AddNumber(".");
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {

            DoOperation("+");
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {

            DoOperation("-");
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            DoOperation("*");
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            DoOperation("/");
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            DoOperation("");
        }

        private void DoOperation(string operation)
        {
            var val = Convert.ToDecimal(labelDisplay.Text);
            if (_operation != "")
            {
                switch (_operation)
                {
                    case "+": _accumulator += val; break;
                    case "-": _accumulator -= val; break;
                    case "/": _accumulator /= val; break;
                    case "*": _accumulator *= val; break;
                }
            }
            else
            {
                _accumulator = val;
            }
            labelDisplay.Text = _accumulator.ToString();
            _justDidStuff = true;
            _operation = operation;
        }

        private void buttonNegative_Click(object sender, EventArgs e)
        {
            AddNumber("-");
        }
    }
}
