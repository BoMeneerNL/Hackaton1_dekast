﻿using System.Windows.Forms;

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

        private void button4_Click(object sender, System.EventArgs e)
        {
            ConfirmationScreen cfscr = new(2, new Form());
            cfscr.ShowDialog();
        }
    }
}
