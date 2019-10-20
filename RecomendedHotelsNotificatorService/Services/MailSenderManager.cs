using ExternalLibraries.ConfigSystem;
using ExternalLibraries.MailSystem;
using System.Collections.Generic;

namespace RecomendedHotelsNotificatorService.Services
{
    public class MailSenderManager : IMailSenderManager
    {
        private readonly IMailSender _sender;
        private readonly IConfig _config;

        private readonly string _origin;

        private const string MAIL_SENDER_KEY = "NotifierService:MailSender";

        public MailSenderManager(
            IMailSender sender,
            IConfig config
        ) {
            _sender = sender;
            _config = config;

            _origin = _config.Get(MAIL_SENDER_KEY);
        }

        public void SendEmail(string address, string subject, string body)
        {
            if (string.IsNullOrEmpty(_origin))
                throw new System.Exception($"Imposible to find key '{ MAIL_SENDER_KEY }' in IConfig");

            _sender.Send(_origin, new List<string> { address }, subject, body);
        }
    }
}
