using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckInputInForms
{
    public delegate bool CheckInputFunc(string s);

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static bool CheckedInput(CheckInputFunc f, string input)
        {
            return f(input);
        }

        static bool StringLongerThan2(string s)
        {
            return s.Length > 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = ((Button)sender).Text + " akce: ";
            if (CheckedInput(StringLongerThan2, textBox1.Text) == false)
            {
                label1.Visible = true;
                label1.Text += "Vstup musí být delší než 2 znaky";
            }
            else
                label1.Visible = false;
        }
    }
}
