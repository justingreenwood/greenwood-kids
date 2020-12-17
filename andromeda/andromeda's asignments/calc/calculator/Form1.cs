using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        public decimal _lastNumber = 0;
        private string _operator = null;
        private bool _calculation = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void addnumber(int num)
        {
            addnumber(num.ToString());
        }

        private void addnumber(string num)
        {
            if (_calculation)
            {
                libell.Text = "0";
            }
            if (num == "-" && libell.Text == "0") return;
            if (num == "0" && libell.Text == "0") return;
            if (num == "." && libell.Text.Contains(".")) return;

            if (num == "-")
            {
                if (libell.Text.StartsWith("-"))
                {
                    libell.Text = libell.Text.TrimStart('-');
                }
                else
                {
                    libell.Text = "-" + libell.Text;
                }
            }
            else
            {
                libell.Text += num;
            }

            if (libell.Text.StartsWith("."))
            {
                libell.Text = "0" + libell.Text;
            }
            else if (!libell.Text.StartsWith("0."))
            {
                libell.Text = libell.Text.TrimStart('0');
            }
            _calculation = false;
        }
        private void negative_Click(object sender, EventArgs e)
        {
            addnumber("-");
        }

        private void ac_Click(object sender, EventArgs e)
        {
            _operator = null;
            _lastNumber = 0;
            libell.Text = "0";
            _calculation = false;
        }

        private void zero_Click(object sender, EventArgs e)
        {
            addnumber(0);
        }

        private void one_Click(object sender, EventArgs e)
        {
            addnumber(1);
        }

        private void two_Click(object sender, EventArgs e)
        {
            addnumber(2);
        }

        private void three_Click(object sender, EventArgs e)
        {
            addnumber(3);
        }

        private void four_Click(object sender, EventArgs e)
        {
            addnumber(4);
        }

        private void five_Click(object sender, EventArgs e)
        {
            addnumber(5);
        }

        private void six_Click(object sender, EventArgs e)
        {
            addnumber(6);
        }
        private void seven_Click(object sender, EventArgs e)
        {
            addnumber(7);
        }
        private void eight_Click(object sender, EventArgs e)
        {
            addnumber(8);
        }

        private void nine_Click(object sender, EventArgs e)
        {
            addnumber(9);
        }
        private void decimalpoint_Click(object sender, EventArgs e)
        {
            addnumber(".");
        }

        private void equal_Click(object sender, EventArgs e)
        {
            calculating("=");
        }

        private void subtract_Click(object sender, EventArgs e)
        {
            calculating("-");
        }

        private void division_Click(object sender, EventArgs e)
        {
            calculating("/");
        }

        private void multiplication_Click(object sender, EventArgs e)
        {
            calculating("*");
        }

        private void add_Click(object sender, EventArgs e)
        {
            calculating("+");
        }
        private void calculating( string  operate)
        {
            if (_calculation && _operator != null)
            {
                this._operator = operate;
            }
            else
            {
                if (_operator == null)
                {
                    this._lastNumber = Convert.ToDecimal(libell.Text);
                    this._operator = operate;
                }
                else
                {
                    var newOperator = operate;
                    var newNumber = Convert.ToDecimal(libell.Text);

                    decimal result = 0;
                    switch (this._operator)
                    {
                        case "+": result = _lastNumber + newNumber; break;
                        case "-": result = _lastNumber - newNumber; break;
                        case "/": result = _lastNumber / newNumber; break;
                        case "*": result = _lastNumber * newNumber; break;
                    }

                    _lastNumber = result;
                    libell.Text = result.ToString();

                    if (newOperator == "=")
                    {
                        this._operator = null;
                    }
                    else
                    {
                        this._operator = newOperator;
                    }

                }
                _calculation = true;
            } 
        }  
    }
}
