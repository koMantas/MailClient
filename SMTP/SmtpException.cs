﻿using System;

namespace MailClient.SMTP
{
    public class SmtpException : Exception
    {
        public SmtpException(string message)
            : base(message) {}

        public SmtpException(string message, System.Exception inner) 
            : base(message, inner) { }
    }
}
