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
            inplannen.Dispose();

        }
    }
}
