using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private decimal lastNumber = 0;
        private string operation = null;
        private bool clearScreen = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //private void Addnumber(int number)
        //{
        //    Addnumber(number.ToString());
        //}

        private void Addnumber(string number)
        {
            if (clearScreen)
            {
                Screen.Text = "";
                clearScreen = false;
            }

            if (number == "-" && Screen.Text != "0")
            {
                if (Screen.Text.StartsWith("-"))
                {
                    Screen.Text = Screen.Text.TrimStart('-');
                } else
                {
                    Screen.Text = number + Screen.Text;
                }
            }
            else
            {
                this.Screen.Text += number;
            }

            if (Screen.Text.StartsWith("0") && !Screen.Text.StartsWith("0."))
            {
                Screen.Text = Screen.Text.TrimStart('0');
            }

            if (Screen.Text == "")
            {
                this.Screen.Text = "0";
            }
            else if (Screen.Text == ".")
            {
                this.Screen.Text = "0.";
            }
        }

        private void OperatorPressed(string op)
        {
            var currentNumber = decimal.Parse(this.Screen.Text);

            clearScreen = true;

            if (operation == null)
            {
                lastNumber = currentNumber;
                operation = op;
            }
            else
            {
                decimal result = 0;
                if (operation == "+")
                {
                    result = lastNumber + currentNumber;
                }
                else if (operation == "-")
                {
                    result = lastNumber - currentNumber;
                }
                else if (operation == "*")
                {
                    result = lastNumber * currentNumber;
                }
                else if (operation == "/")
                {
                    result = lastNumber / currentNumber;
                }
                this.Screen.Text = result.ToString();
                this.lastNumber = result;

                if (op == "=")
                {
                    operation = null;
                } 
                else
                {
                    operation = op;
                }
            }
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Fun_Click(object sender, EventArgs e)
        {

        }

        private void Stuff_Click(object sender, EventArgs e)
        {

        }

        private void Negative_Click(object sender, EventArgs e)
        {
            Addnumber("-");            
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            Screen.Text = "0";
            this.lastNumber = 0;
            this.operation = null;
        }

        private void Screen_Click(object sender, EventArgs e)
        {

        }

        private void Zero_Click(object sender, EventArgs e)
        {
            Addnumber("0");
        }

        private void Decimal_Click(object sender, EventArgs e)
        {
            if(!Screen.Text.Contains("."))
            Addnumber(".");
        }

        private void Three_Click(object sender, EventArgs e)
        {
            Addnumber("3");
        }

        private void Two_Click(object sender, EventArgs e)
        {
            Addnumber("2");
        }

        private void One_Click(object sender, EventArgs e)
        {
            Addnumber("1");
        }

        private void Six_Click(object sender, EventArgs e)
        {
            Addnumber("6");
        }

        private void Four_Click(object sender, EventArgs e)
        {
            Addnumber("4");
        }

        private void Five_Click(object sender, EventArgs e)
        {
            Addnumber("5");
        }

        private void Nine_Click(object sender, EventArgs e)
        {
            Addnumber("9");
        }

        private void Eight_Click(object sender, EventArgs e)
        {
            Addnumber("8");
        }

        private void Seven_Click(object sender, EventArgs e)
        {
            Addnumber("7");
        }

        private void Equals_Click(object sender, EventArgs e)
        {
            OperatorPressed("=");
        }

        private void Addition_Click(object sender, EventArgs e)
        {
            OperatorPressed("+");
        }

        private void Subtraction_Click(object sender, EventArgs e)
        {
            OperatorPressed("-");
        }

        private void Multiplication_Click(object sender, EventArgs e)
        {
            OperatorPressed("*");
        }

        private void Division_Click(object sender, EventArgs e)
        {
            OperatorPressed("/");
        }
    }
}
