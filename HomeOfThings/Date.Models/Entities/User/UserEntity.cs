using System.ComponentModel.DataAnnotations;

namespace Date.Models.Entities.User
{
    public class UserEntity: AEntityBase, IEntityBase
    {
        public int Id => UserId;
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public Guid? FamilyGuid { get; set; }
        public DateTime DateOfBirth { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;
        public bool EmailConfirmed { get; set; }
        public string Salt { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
