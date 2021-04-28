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
    public partial class Form2 : Form
    {
        public bool ShowValidation(string s, List<string> errors)
        {
            if (errors.Count == 0)
            {
                label1.Text += s + "\nOK\n\n";
            }
            else
            {
                label1.Text += s + "\n" + string.Join("\n", errors.ToArray()) + "\n\n";
            }

            return true;
        }

        public Form2(Form1 masterForm)
        {
            InitializeComponent();
            masterForm.ValidationFinished += ShowValidation;
        }
    }
}
