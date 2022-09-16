using MiFare;
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
        public ConfirmationScreen(int btnval,Form form)
        {
            Form = form;
            if (btnval is not 1 or 2 or 3 or 4)
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
                    WriteMessage("Card detected. Do not remove while linking.");
                    txtUID.Text = BitConverter.ToString(uid).Replace("-", string.Empty);
                    List<string> Lines = File.ReadLines("database\\users.dbt").ToList();
                    int rtrn = 0;
                    foreach (string Line in Lines)
                    {
                        string ln = Line.Split(";").First();
                        if (ln == txtUID.Text)
                        {
                            rtrn++;
                            WriteMessage("User found, Performing selected action");
                            if (Btnval == 1)
                            {
                                MessageBox.Show("Finished action, click OK to close down");
                                
                            }
                            else if (Btnval == 2)
                            {

                            }
                            else if (Btnval == 3)
                            {

                            }
                            else if (Btnval == 4)
                            {

                            }

                            Form.Close();
                            Close();
                        }
                    }
                    if(rtrn < 1)
                        MessageBox.Show("Could not find the user, try again");


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
        public void WriteMessage(string message) => BeginInvoke(() => { lblMessage.Text = message; });

        private void Main_Load(object sender, EventArgs e) => GetDevices();

        private void Button1_Click(object sender, EventArgs e) => Close();
    }
}
