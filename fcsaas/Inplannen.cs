using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace fcsaas
{
    public partial class Inplannen : Form
    {
        public static List<string> pilates = new();
        public static List<string> paaldansen = new();
        public static List<string> yoga = new();
        public Inplannen()
        {
            InitializeComponent();
            List<string> lines = File.ReadLines("database\\courses.dbt").ToList();
            foreach (string line in lines)
            {
                string[] ln = line.Split(";");

                if (ln[0] == "pilates")
                {
                    pilates.Add(ln[1]);
                }
                else if (ln[0] == "paaldansen")
                {
                    paaldansen.Add(ln[1]);
                }
                else if (ln[0] == "yoga")
                {
                    yoga.Add(ln[1]);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConfirmationScreen cfscr = new(1, this);
            cfscr.ShowDialog();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(pilates.ToArray());
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(paaldansen.ToArray());
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(yoga.ToArray());
        }
    }
}
