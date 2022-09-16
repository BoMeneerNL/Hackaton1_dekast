using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fcsaas
{
    public partial class Inplannen : Form
    {
        public Inplannen()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConfirmationScreen cfscr = new(1,this);
            cfscr.ShowDialog();
        }
    }
}
