using System;
using System.Windows.Forms;

namespace Lab12
{
    public partial class FormInput : Form
    {
        public FormInput()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Data.radius = Convert.ToDouble(textBox1.Text);
            Data.height = Convert.ToDouble(textBox2.Text);
            Data.pltn = Convert.ToDouble(textBox3.Text);
            Data.calculationVolume = checkBox1.Checked;
            Data.calculationMass = checkBox2.Checked;
            Close();
        }
    }
}
