using System;
using System.Windows.Forms;

namespace fcsaas
{
    public partial class Inplannen : Form
    {
        public Inplannen() => InitializeComponent();

        private void button2_Click(object sender, EventArgs e)
        {
            ConfirmationScreen cfscr = new(1, this);
            cfscr.ShowDialog();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
