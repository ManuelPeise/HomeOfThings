using System.ComponentModel.DataAnnotations;

namespace Date.Models.Models.Email
{
    public class EmailAccountConfiguration
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string SmtpServer { get; set; } = string.Empty;
        public string PopServer { get; set; } = string.Empty;
        public int SmtpPort { get; set; }
        public int PopPort { get; set; }

        public void IsValidConfiguration(out bool isValid, int pop = -1, int smtp = -1)
        {
            isValid = !string.IsNullOrWhiteSpace(Email) &&
                !string.IsNullOrWhiteSpace(Password) &&
                !string.IsNullOrWhiteSpace(PopServer) &&
                !string.IsNullOrWhiteSpace(SmtpServer) &&
                smtp != -1 &&
                pop != -1;
        }
    }
}
