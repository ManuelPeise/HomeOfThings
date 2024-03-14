using Date.Models.Enums;

namespace Date.Models.Entities.User
{
    public class UserRoleEntity: AEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public UserRoleEnum RoleId { get; set; }
    }
}
