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
        // Návratová hodnota bool jenom kvůli kompatibilitě s událostí ValidationFinished,
        // (ta je typu Validations.CheckInputFunc)
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

        // Argument konstruktoru Form1, aby bylo možné dostat se k události ValidationFinished
        // Ta je public v masterForms
        public Form2(Form1 masterForm)
        {
            InitializeComponent();

            // Navěšení vlastního kódu na událost v masterFormu
            masterForm.ValidationFinished += ShowValidation;
        }
    }
}
