namespace RecomendedHotelsNotificatorService.Services
{
    public interface IMailSenderManager
    {
        void SendEmail(string address, string subject, string body);
    }
}
