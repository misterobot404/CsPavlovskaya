using System;
using System.Windows.Forms;

namespace Lab12
{
    public partial class FormWork : Form
    {
        public FormWork()
        {
            InitializeComponent();
            textBox1.Text = Data.height.ToString();
            textBox2.Text = Data.radius.ToString();
            textBox3.Text = Data.pltn.ToString();

            if (Data.calculationVolume)
            {
                textBox4.Text = (Data.height / 3* Math.PI * (Data.radius * Data.radius)).ToString();
            }
            else textBox4.Text = " ";

            if (Data.calculationMass)
            {
                double S = Math.PI * (Data.radius * Data.radius);
                double V = 1.0 / 3.0 * S * Data.height;
                textBox5.Text = (Data.pltn * V).ToString();
            }
            else textBox5.Text = " ";

        }
    }
}
