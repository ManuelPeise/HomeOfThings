using System.ComponentModel.DataAnnotations;

namespace Date.Models.Models.User
{
    public abstract class AUserBase
    {
        public int UserId { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;
        public bool EmailConfirmed { get; set; }
        public string Salt { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
