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
    public delegate bool CheckInputFunc(string s, List<string> e);

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool CheckedInputErrors(CheckInputFunc[] f, string input, List<string> errors)
        {
            bool b = true, thisOK = true;
            foreach (var x in f)
            {
                thisOK = x(input, errors);
                b = b && thisOK;
            }
            return b;
        }


        bool StringLongerThan2(string s, List<string> errorList)
        {
            if (s.Length > 2)
            {
                return true;
            }
            else
            {
                errorList.Add("String musí být delší než 2 znaky");
                return false;
            }
        }

        bool StringCanBeInt(string s, List<string> errorList)
        {
            if (int.TryParse(s, out int result))
            {
                return true;
            }
            else
            {
                errorList.Add($"{s} nemůže být celé číslo");
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> errors = new List<string>();
            label1.Text = ((Button)sender).Text + " akce: ";

            if (CheckedInputErrors(new CheckInputFunc[] { StringLongerThan2, StringCanBeInt },
                textBox1.Text, errors) == false)
            {
                label1.Text += string.Join(",\n", errors.ToArray());
                label1.Visible = true;
            }
            else
                label1.Visible = false;
        }
    }
}
