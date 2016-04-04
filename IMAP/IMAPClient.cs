using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MailClient.IMAP
{
    public class IMAPClient
    {
        private TcpClient _client;
        private Stream _stream;
        private NetworkStream _networkStream;
        private SslStream _sslStream;
        private int _tag = 0;

        public IMAPClient(string ServerAddress, int ServerPort, bool isSSL)
        {
            _client = new TcpClient(ServerAddress, ServerPort);
            _networkStream = _client.GetStream();
            if (isSSL)
            {
                _sslStream = new SslStream(_networkStream, true);
                _sslStream.AuthenticateAsClient(ServerAddress);
                _stream = _sslStream;
            }
            else
            {
                _stream = _networkStream;
            }
        }

        public void Login(string Username, string Password)
        {
            WriteWithResponse(" LOGIN " + Username + " " + Password);

            //starttls chechup
        }

        public void Logout()
        {
            WriteWithResponse()
        }

        private string GetTag()
        {
            return String.Format("a{0} ", _tag++);
        }

        private void WriteWithResponse(string CommandText)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();

            if (!CommandText.EndsWith("\r\n")) CommandText += "\r\n";

            string sentCommand = GetTag() + CommandText;
            byte[] bufferBytes = encoding.GetBytes(sentCommand);

            _stream.Write(bufferBytes, 0, bufferBytes.Length);

            _stream.Flush();

            string response = Response();

            //TODO check if response is OK BAD NO
        }

        private string Response()
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] bufferBytes = new byte[2048];

            _stream.Read(bufferBytes, 0, bufferBytes.Length);

            return encoding.GetString(bufferBytes);
        }

    }
}
