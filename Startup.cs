using System;
using System.Windows.Forms;
using MailClient.SMTP;
using System.Net.Sockets;

namespace MailClient
{
    public partial class Startup : Form
    {
        private GmailSMTPClient _client;
        public Startup()
        {
            InitializeComponent();
        }

        private void SingUpButton_Click(object sender, EventArgs e)
        {
            try {
                _client = new GmailSMTPClient(new Smtp());
                if (Username.Text.Length > 0 && Password.Text.Length > 0)
                {


                    if (_client.Authenticate(Username.Text, Password.Text))
                    {
                        SentMessage messageForm = new SentMessage(_client, this);
                        Username.Clear();
                        Password.Clear();
                        this.Hide();
                        messageForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Cannot log in, try again");
                        Username.Clear();
                        Password.Clear();
                    }
                }
            }
            catch (SocketException)
            {
                MessageBox.Show("Cannot connect to gmail SMTP server");
            }
            catch (Exception)
            {
                MessageBox.Show("Exception accured during communication with server");
            }
        }

        private void Startup_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}