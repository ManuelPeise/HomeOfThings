using Data.Interfaces.Interfaces.Clients;
using Date.Models.Models.Email;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Ressources;

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
            using (var stream = Resources.ResourceManager.GetStream(name))
            {
                if(stream != null)
                {
                    using(var reader = new StreamReader(stream))
                    {
                        var html = await reader.ReadToEndAsync();

                        return html;
                    }
                }
            }

            return string.Empty;
        }

        public MimeMessage BuilMailMessage(string to, string subject, string body = "",  string? htmlBody = null)
        {
            var message = new MimeMessage();
            message.Subject = subject;
            message.From.Add(new MailboxAddress("from", _accountConfiguration?.Email));
            message.To.Add(new MailboxAddress("", to));

            if (htmlBody != null)
            {
                
                message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = htmlBody
                };
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
                await client.ConnectAsync(_accountConfiguration.SmtpServer, _accountConfiguration.SmtpPort, SecureSocketOptions.StartTls);

                await client.AuthenticateAsync(_accountConfiguration.Email, _accountConfiguration.Password);

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
