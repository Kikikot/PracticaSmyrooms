using ExternalLibraries.LoggSystem;
using System.Collections.Generic;

namespace ExternalLibraries.MailSystem
{
    public class MailSender : IMailSender
    {
        private readonly ILogger _logger;
        private const string log = "MailSender: Mail sended (Sender: {0} / Receivers: {1} / Subject: {2} / Body: {3})";

        public MailSender(ILogger logger)
        {
            _logger = logger;
        }

        public void Send(string sender, List<string> receivers, string subject, string body)
        {
            _logger.Log(string.Format(log, sender, string.Join(" - ", receivers), subject, body));
        }
    }
}
