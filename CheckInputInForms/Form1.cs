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
    public partial class Form1 : Form
    {
        // Ostatním třídám: Sem si navěšujte váš kód, který se spustí vždy po validaci textBox1
        public event Validations.CheckInputFunc ValidationFinished;

        // Logovací formulář s historií validace textBox1
        public Form2 SlaveForm;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> errors = new List<string>();
            label1.Text = ((Button)sender).Text + " akce: ";

            if (Validations.CheckedInputWithErrors(
                new Validations.CheckInputFunc[] 
                    { Validations.StringLongerThan2, Validations.StringCanBeInt },
                textBox1.Text, 
                errors) == false)
            {
                label1.Text += string.Join(",\n", errors.ToArray());
                label1.Visible = true;
            }
            else
                label1.Visible = false;

            // Signalizuje ostatním formulářům, že byla ukončena validace
            // a spouští metody navěšené na ValidationFinished
            ValidationFinished?.Invoke(textBox1.Text, errors);

            textBox1.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SlaveForm = new Form2(this);
            SlaveForm.Show();
        }
    }
}
