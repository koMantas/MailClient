using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailClient
{
    public partial class SentMessage : Form
    {
        private GmailSMTPClient _client;
        private Startup _startupForm;
        public SentMessage(GmailSMTPClient client, Startup startupForm)
        {
            _client = client;
            _startupForm = startupForm;
            InitializeComponent();
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            string[] recipients = RCPTTextBox.Text.Split(';');
            string message = MessageTextBox.Text;
            List<string> received = new List<string>();
            try
            {
                if (_client.SendMessage(recipients, message, received))
                {
                    string receivers = "\n";
                    foreach (var item in received)
                    {
                        receivers += item + "\n";

                    }
                    MessageBox.Show("Message is sent to:" + receivers);
                    RCPTTextBox.Clear();
                    MessageTextBox.Clear();
                }
                else
                {
                    MessageBox.Show("Cannot send message");
                    RCPTTextBox.Clear();
                    MessageTextBox.Clear();
                }
            }
            catch (SocketException)
            {
                ConnectionLost();
            }
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            try
            {
                _client.LogOut();
            }
            catch (SocketException){}
            finally
            {
                _startupForm.Show();
                this.Close();
            }
        }

        private void MessageTextBox_TextChanged(object sender, EventArgs e)
        {
            if (MessageTextBox.Text.Equals("") && RCPTTextBox.Text.Equals(""))
                SendButton.Enabled = false;
            else
                SendButton.Enabled = true;
        }

        private void SentMessage_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                _client.LogOut();
            }
            catch (SocketException) { }
        }

        private void ConnectionLost()
        {
            MessageBox.Show("Lost connection with SMTP server");
            _startupForm.Show();
            this.Close();
        }
    }
}
