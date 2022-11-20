using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace fcsaas
{
    public partial class Inplannen : Form
    {
        public static readonly List<string> Pilates = new();
        public static readonly List<string> Paaldansen = new();
        public static readonly List<string> Yoga = new();
        public Inplannen()
        {
            InitializeComponent();
            List<string> lines = File.ReadLines("database\\courses.dbt").ToList();
            foreach (string line in lines)
            {
                string[] ln = line.Split(";");
                if (ln[0] == "pilates")
                    Pilates.Add(ln[1]);
                else if (ln[0] == "paaldansen")
                    Paaldansen.Add(ln[1]);
                else if (ln[0] == "yoga")
                    Yoga.Add(ln[1]);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ConfirmationScreen cfscr = new(1, this);
            cfscr.ShowDialog();
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(Pilates.ToArray());
            }
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(Paaldansen.ToArray());
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(Yoga.ToArray());
        }
    }
}
