﻿using MiFare;
using MiFare.Classic;
using MiFare.Devices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace fcsaas
{
    public partial class ConfirmationScreen : Form
    {
        private SmartCardReader reader;
        private MiFareCard card;
        private readonly int Btnval;
        private readonly Form Form;
        public ConfirmationScreen(int btnval, Form form)
        {
            Form = form;
            if (btnval < 1 || btnval > 4)
                MessageBox.Show("An unknown error occured");
            else
                Btnval = btnval;

            InitializeComponent();
        }

        private void CardRemoved(object sender, EventArgs e)
        {
            card.Dispose();

            var ignored = BeginInvoke(() =>
            {
                WriteMessage("To confirm the current action please place your card on the reader");
                groupBox1.Visible = false;
            });
        }

        private async void CardAdded(object sender, CardEventArgs args)
        {
            try
            {
                card = args.SmartCard.CreateMiFareCard();

                var cardIdentification = await card.GetCardInfo();
                var uid = await card.GetUid();
                var ignored = BeginInvoke(() =>
                {
                    WriteMessage("Reading Card...");
                    txtUID.Text = BitConverter.ToString(uid).Replace("-", string.Empty);
                    List<string> Lines = File.ReadLines("database\\users.dbt").ToList();
                    int rtrn = 0;
                    foreach (string Line in Lines)
                    {
                        string[] ln = Line.Split(";");
                        if (ln[0] == txtUID.Text)
                        {
                            rtrn++;
                            WriteMessage("User found, Performing selected action");
                            if (Btnval == 1)
                            {
                                MessageBox.Show("Finished action, click OK to close down");

                            }
                            else if (Btnval == 2)
                            {
                                Lines = File.ReadLines("database\\users.dbt").ToList();
                                WriteMessage("Reading user data...");
                                bool UserFound = false;
                                Lines.ForEach(x =>
                                {
                                    Dictionary<string, string> valve = new()
                                    {
                                        { "uid", x.Split(";")[0] }
                                    };
                                    if (valve["uid"] == txtUID.Text)
                                    {
                                        UserFound = true;
                                    }
                                });
                                if (UserFound)
                                {
                                    
                                }
                            }
                            else if (Btnval == 3)
                            {

                            }
                            else if (Btnval == 4)
                            {
                                PopupMessage("Spijtig om te zien dat je je abonnement opgezegd hebt, we hopen dat je weer een keer terug komt", "Spijtig om te horen dat je je abonnement op hebt gezegt");
                                List<string> lines = File.ReadLines("database\\users.dbt").ToList();
                                File.Delete("database\\users.dbt");
                                lines.RemoveAll(x => x.StartsWith(txtUID.Text + ";"));
                                File.AppendAllLines("database\\users.dbt", lines);
                                
                            }

                            Form.Close();
                            Close();
                        }
                    }
                    if (rtrn < 1)
                        WriteMessage("Could not find the user, remove the card and try again");


                });
            }
            catch (Exception ex)
            {
                PopupMessage("CardAdded Exception: " + ex.Message);
            }
        }

        private void CboDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDevices.SelectedIndex > -1)
                ConnectToDevice(cboDevices.Text);
        }

        private void GetDevices()
        {
            try
            {
                IReadOnlyList<string> readers = CardReader.GetReaderNames();
                if (readers.Count == 0)
                {
                    PopupMessage("No readers found, Closing down...");
                    card?.Dispose();
                    reader?.Dispose();
                    Environment.Exit(0);
                }
                else
                {
                    cboDevices.Items.AddRange(readers.ToArray());
                    cboDevices.SelectedIndex = 0;
                }
            }
            catch (Exception e)
            {
                PopupMessage("Exception: " + e.Message);
            }
        }

        private async void ConnectToDevice(string name)
        {
            try
            {
                reader = await CardReader.FindAsync(name);
                if (reader == null)
                {
                    PopupMessage("No Readers Found");
                    return;
                }

                reader.CardAdded += CardAdded;
                reader.CardRemoved += CardRemoved;
            }
            catch (Exception e)
            {
                PopupMessage("Exception: " + e.Message);
            }
        }

        public void PopupMessage(string message) => BeginInvoke(() => { MessageBox.Show(message); });
        public void PopupMessage(string message, string title) => BeginInvoke(() => { MessageBox.Show(message, title); });
        public void WriteMessage(string message) => BeginInvoke(() => { lblMessage.Text = message; });
        private void Main_Load(object sender, EventArgs e) => GetDevices();
        private void Button1_Click(object sender, EventArgs e) => Close();
    }
}
