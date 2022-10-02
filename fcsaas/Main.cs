using System.Windows.Forms;

namespace fcsaas
{
    public partial class Main : Form
    {
        public Main() => InitializeComponent();

        private void Button1_Click(object sender, System.EventArgs e)
        {
            Inplannen inplannen = new();
            inplannen.ShowDialog();

        }

        private void Button4_Click(object sender, System.EventArgs e)
        {
            ConfirmationScreen cfscr = new(2, new Inplannen());
            cfscr.ShowDialog();
        }

        private void Button3_Click(object sender, System.EventArgs e)
        {
            ConfirmationScreen cfscr = new(4, new Inplannen());
            cfscr.ShowDialog();
        }
    }
}
