using MailClient.SMTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailClient
{
    public class GmailSMTPClient
    {
        private ISmtp _smtp;
        private string _username;
        public GmailSMTPClient(ISmtp smtp)
        {
            _smtp = smtp;
            _smtp.ConnectToServer("smtp.gmail.com", 465, true);
            _smtp.EHLO();
        }

        public bool Authenticate(string username, string password)
        {
            try
            {
                _smtp.AuthLogin(username, password);
                _username = username;
                return true;
            }
            catch (SmtpException)
            {
                return false;
            }
        }

        public bool SendMessage(string[] receivers, string message, List<string> isSent)
        {
            isSent.Clear();
            try
            {
                _smtp.MailFrom(_username + "@gmail.com");
                foreach (var receiver in receivers)
                {
                    try
                    {
                        _smtp.RcptTo(receiver.Trim());
                        isSent.Add(receiver);
                    }
                    catch (SmtpException)
                    { }
                }
                _smtp.Data(message);
                return true;
            }
            catch (SmtpException)
            {
                _smtp.Reset();
                return false;
            }
        }

        public void LogOut()
        {
            _smtp.Quit();
        }
    }
}
