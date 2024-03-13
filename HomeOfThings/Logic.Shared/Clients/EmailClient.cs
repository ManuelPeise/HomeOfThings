using Data.Interfaces.Interfaces.Clients;
using Data.Ressources;
using Date.Models.Models.Email;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace Logic.Shared.Clients
{
    public class EmailClient : IEmailClient
    {
        private EmailAccountConfiguration? _accountConfiguration;
        public EmailClient(IConfiguration config)
        {
            _accountConfiguration = LoadConfiguration(config);
        }

        public async Task<string> LoadMailHtmlFromRessources(string name)
        {
            switch (name)
            {
                case RessourceNames.RegistrationMailBody:
                    return await Task.FromResult(Files.Resources.RegistrationMailBody);
                default: return string.Empty;
            }
        }

        public MimeMessage BuilMailMessage(string to, string subject, string body = "", string? htmlBody = null)
        {
            var message = new MimeMessage();
            message.Subject = subject;
            message.From.Add(new MailboxAddress($"from {_accountConfiguration?.Email}", _accountConfiguration?.Email));
            message.To.Add(new MailboxAddress("", to));

            if (htmlBody != null)
            {
                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = htmlBody;

                message.Body = bodyBuilder.ToMessageBody();
            }
            else
            {
                message.Body = new TextPart(MimeKit.Text.TextFormat.Text)
                {
                    Text = body
                };
            }

            return message;
        }

        public async Task SendMail(MimeMessage message)
        {
            if (_accountConfiguration == null) return;

            using (var client = new SmtpClient())
            {
                client.Connect(_accountConfiguration.SmtpServer, _accountConfiguration.SmtpPort, SecureSocketOptions.StartTls);

                client.Authenticate(_accountConfiguration.Email, _accountConfiguration.Password);

                if (client.IsAuthenticated)
                {
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
            }
        }

        #region private

        private EmailAccountConfiguration? LoadConfiguration(IConfiguration config)
        {
            var isValid = false;

            var accountConfig = new EmailAccountConfiguration
            {
                Email = config["mailAccount:mail"] ?? string.Empty,
                Password = config["mailAccount:password"] ?? string.Empty,
                SmtpServer = config["mailAccount:smtpServer"] ?? string.Empty,
                PopServer = config["mailAccount:popServer"] ?? string.Empty,
                PopPort = int.Parse(config["mailAccount:pop"] ?? "-1"),
                SmtpPort = int.Parse(config["mailAccount:smtp"] ?? "-1")
            };

            accountConfig.IsValidConfiguration(out isValid, accountConfig.PopPort, accountConfig.SmtpPort);

            if (isValid)
            {
                return accountConfig;
            }

            return null;
        }
        #endregion

    }
}
