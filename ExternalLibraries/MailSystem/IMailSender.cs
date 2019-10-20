using System;
using System.Collections.Generic;
using System.Text;

namespace ExternalLibraries.MailSystem
{
    public interface IMailSender
    {
        void Send(string sender, List<string> receivers, string subject, string body);
    }
}
