using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace MailClient.SMTP
{
    public class Smtp : ISmtp
    {
        private TcpClient _client;
        private Stream _stream;
        private NetworkStream _networkStream;
        private SslStream _sslStream;
        private bool _isConnected = false;
        private bool _isSSL = false;

        public Smtp()
        {
        }

        public void ConnectToServer(string serverAddress, int serverPort, bool isSSL = false)
        {
            if (!_isConnected || !_client.Connected)
            {
                _isSSL = isSSL;
                _client = new TcpClient();
                try
                {
                    _client.Connect(serverAddress, serverPort);
                    _networkStream = _client.GetStream();
                    if (isSSL)
                    {
                        _sslStream = new SslStream(_networkStream);
                        _sslStream.AuthenticateAsClient(serverAddress);
                        _stream = _sslStream;
                    }
                    else
                    {
                        _stream = _networkStream;
                    }

                    _isConnected = true;
                    string response = Response();
                    if (!CheckResponse(response, new string[] { "220" }))
                    {
                        _isConnected = false;
                        _client.Close();
                        throw new SmtpException(response);
                    }
                    else
                    {
                        _isConnected = true;
                    }

                }
                catch (SocketException)
                {
                    _client.Dispose();
                    _isConnected = false;
                    throw;
                }
            }
        }

        public string HELO()
        {
            Write("HELO " + Environment.MachineName);
            string response = Response();
            if (!CheckResponse(response, new string[] { "250" }))
                throw new SmtpException(response);
            return response;
        }

        public string EHLO()
        {
            Write("EHLO " + Environment.MachineName);
            string response = Response();
            if (!CheckResponse(response, new string[] { "250" }))
                throw new SmtpException(response);
            return response;
        }

        public bool StartTLS()
        {
            Write("STARTTLS");
            if (!CheckResponse(Response(), new string[] { "220" }))
                return false;
            return true;
        }

        //return bool if authentication was successful
        public void AuthLogin(string username, string password)
        {
            Write("AUTH LOGIN");
            CheckResponseWithExceptionThrow(new string[] { "334" });

            string usernameBase64 = Convert.ToBase64String(Encoding.ASCII.GetBytes(username));
            Write(usernameBase64);
            CheckResponseWithExceptionThrow(new string[] { "334" });

            string passwordBase64 = Convert.ToBase64String(Encoding.ASCII.GetBytes(password));
            Write(passwordBase64);
            CheckResponseWithExceptionThrow(new string[] { "235" });
        }

        public void MailFrom(string mailFrom)
        {
            Write(String.Format("MAIL FROM:<{0}>", mailFrom));
            CheckResponseWithExceptionThrow(new string[] { "250" });
        }

        public void RcptTo(string mailTo)
        {
            Write(String.Format("RCPT TO:<{0}>", mailTo));
            CheckResponseWithExceptionThrow(new string[] { "250", "251" });
        }

        public void Data(string messageData)
        {
            Write("DATA");
            CheckResponseWithExceptionThrow(new string[] { "354" });
            string[] lines = messageData.Split('\n');
            StringBuilder builder = new StringBuilder();
            foreach (var line in lines)
            {
                if (line[0] == '.')
                {
                    builder.Append(".");
                    builder.Append(line);
                    builder.Append("\n");
                }
                else
                {
                    builder.Append(line);
                    builder.Append("\n");
                }

            }



            Write(builder.ToString() + "\r\n.\r\n");
            CheckResponseWithExceptionThrow(new string[] { "250" });
        }

        //the current mail transaction is aborted
        public void Reset()
        {
            Write("RSET");
            CheckResponseWithExceptionThrow(new string[] { "250" });
        }

        //asks the server to confirm that the argument identifies a user or mailbox
        public string Verify(string user)
        {
            Write("VRFY " + user);
            string response = Response();
            if (CheckResponse(response, new string[] { "250", "251", "252" }))
                return response;
            else
                return "";
        }

        public string help(string argument = "")
        {
            Write(String.Format("HELP {0}", argument));
            string response = Response();
            if (!CheckResponse(response, new string[] { "211", "214" }))
            {
                throw new SmtpException(response);
            }
            else
                return response;
        }

        //server send OK reply
        public string Noop()
        {
            Write("NOOP");
            return Response();
        }

        //client quits connection with server. Client MUST wait for OK(211) reply
        public void Quit()
        {
            Write("QUIT");
            if (CheckResponse(Response(), new string[] { "211" }))
            {
                _isConnected = false;
                _client.Dispose();
            }
        }


        private bool CheckResponse(string response, string[] goodResponseNumbers)
        {
            Regex regex = new Regex(@"^\d{3}");
            Match match = regex.Match(response);
            if (match.Success)
            {
                string numberFromServer = match.Value;
                foreach (var number in goodResponseNumbers)
                {
                    if (String.Equals(numberFromServer, number))
                        return true;
                }
            }
            return false;
        }

        private void CheckResponseWithExceptionThrow(string[] goodResponseNumbers)
        {
            string response = Response();
            if (!CheckResponse(response, goodResponseNumbers))
                throw new SmtpException(response);
        }

        private void Write(string Command)
        {
            if (_isConnected)
            {
                if (!Command.EndsWith("\r\n")) Command += "\r\n";
                byte[] bufferBytes = Encoding.UTF8.GetBytes(Command);
                try
                {
                    _stream.Write(bufferBytes, 0, bufferBytes.Length);
                    _stream.Flush();
                }
                catch (SocketException)
                {
                    throw;
                }
            }
            else
            {
                throw new SmtpException("User is not connected to SMTP server, cannot write to server");
            }
        }

        private string Response()
        {
            if (_isConnected)
            {
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] bufferBytes = new byte[2048];
                try {
                    _stream.Read(bufferBytes, 0, bufferBytes.Length);
                    string response = encoding.GetString(bufferBytes);
                    return encoding.GetString(bufferBytes);
                }
                catch (SocketException)
                {
                    throw;
                }
            }
            else
            {
                throw new SmtpException("User is not connected to SMTP server, cannot read from server");
            }
        }
    }
}
