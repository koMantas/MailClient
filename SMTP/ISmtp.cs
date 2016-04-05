using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailClient.SMTP
{
    public interface ISmtp
    {
        void ConnectToServer(string serverAddress, int serverPort, bool isSSL = false);
        string HELO();
        string EHLO();
        bool StartTLS();
        void AuthLogin(string username, string password);
        void MailFrom(string mailFrom);
        void RcptTo(string mailTo);
        void Data(string messageData);
        void Reset();
        string Verify(string user);
        string help(string argument = "");
        string Noop();
        void Quit();
    }
}
