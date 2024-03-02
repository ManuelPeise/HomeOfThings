using System.ComponentModel.DataAnnotations;

namespace Date.Models.Entities.User
{
    public class UserEntity: AEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;
        public string Salt { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string UserRolesJson { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
