using System.ComponentModel.DataAnnotations;

namespace Date.Models.Models.User.Import
{
    public class UserLoginModel
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsAdmin { get; set; }
    }
}
