using System;
using MailClient.IMAP;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.WriteLine("Hello world!");
            IMAPClient _client = new IMAPClient("mail.stud.vu.lt",143,false);
            _client.Login("s1412220", "1851janonis");
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Startup());*/
        }
    }
}
