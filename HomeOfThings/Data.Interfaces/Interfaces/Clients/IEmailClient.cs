using MimeKit;

namespace Data.Interfaces.Interfaces.Clients
{
    public interface IEmailClient
    {
        Task<string> LoadMailHtmlFromRessources(string name);
        MimeMessage BuilMailMessage(string to, string subject, string body = "", string? htmlBody = null);
        Task SendMail(MimeMessage message);
    }
}
