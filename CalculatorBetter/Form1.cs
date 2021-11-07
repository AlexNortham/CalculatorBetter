using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorBetter
{
    public partial class Form1 : Form
    {
        Methods methods = new Methods();
        public Form1()
        {
            InitializeComponent();
        }

        private void enterCharacter(string symbol)
        {
            string current = Display.Text;
            string next = current + symbol;
            Display.Text = next;
        }

        private void displayCharacter(string symbol)
        {
            string current = userDisplay.Text;
            string next = current + symbol;
            userDisplay.Text = next;
        }

        private void Calculate()
        {
            String equation = Display.Text;
            String result = methods.Sum(equation);
            result = methods.RealForm(result);
            Display.Text = result;
            userDisplay.Text = result;

        }

        private void one_Click(object sender, EventArgs e)
        {
            enterCharacter("1");
            displayCharacter("1");
        }

        private void two_Click(object sender, EventArgs e)
        {
            enterCharacter("2");
            displayCharacter("2");
        }

        private void three_Click(object sender, EventArgs e)
        {
            enterCharacter("3");
            displayCharacter("3");
        }

        private void four_Click(object sender, EventArgs e)
        {
            enterCharacter("4");
            displayCharacter("4");
        }

        private void five_Click(object sender, EventArgs e)
        {
            enterCharacter("5");
            displayCharacter("5");
        }

        private void six_Click(object sender, EventArgs e)
        {
            enterCharacter("6");
            displayCharacter("6");
        }

        private void seven_Click(object sender, EventArgs e)
        {
            enterCharacter("7");
            displayCharacter("7");
        }

        private void eight_Click(object sender, EventArgs e)
        {
            enterCharacter("8");
            displayCharacter("8");
        }

        private void nine_Click(object sender, EventArgs e)
        {
            enterCharacter("9");
            displayCharacter("9");
        }

        private void zero_Click(object sender, EventArgs e)
        {
            enterCharacter("0");
            displayCharacter("0");
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            string current = Display.Text;
            try {
                current = current.Substring(0, current.Length - 1);
                Display.Text = current;
            }catch(Exception error)
            {

            }
            string userCurrent = userDisplay.Text;
            try
            {
                userCurrent = userCurrent.Substring(0, userCurrent.Length - 1);
                userDisplay.Text = userCurrent;
            }
            catch (Exception error)
            {

            }

        }

        private void decimalPoint_Click(object sender, EventArgs e)
        {
            enterCharacter(".");
            displayCharacter(".");
        }

        private void plus_Click(object sender, EventArgs e)
        {
            enterCharacter("+");
            displayCharacter("+");
        }

        private void minus_Click(object sender, EventArgs e)
        {
            enterCharacter("-");
            displayCharacter("-");
        }

        private void slash_Click(object sender, EventArgs e)
        {
            enterCharacter("/");
            displayCharacter("/");
        }

        private void times_Click(object sender, EventArgs e)
        {
            enterCharacter("x");
            displayCharacter("x");
        }

        private void negative_Click(object sender, EventArgs e)
        {
            enterCharacter("n");
            displayCharacter("-");
        }

        private void equals_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        private void leftBracket_Click(object sender, EventArgs e)
        {
            enterCharacter("(");
            displayCharacter("(");
        }

        private void rightBracket_Click(object sender, EventArgs e)
        {
            enterCharacter(")");
            displayCharacter(")");
        }
    }
}
