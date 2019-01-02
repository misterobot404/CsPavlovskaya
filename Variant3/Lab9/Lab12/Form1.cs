using System;
using System.Windows.Forms;

namespace Lab12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormInput formInput = new FormInput();
            formInput.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormWork formWork = new FormWork();
            formWork.ShowDialog();
        }
    }
}
