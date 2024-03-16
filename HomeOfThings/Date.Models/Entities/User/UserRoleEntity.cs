using Date.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Date.Models.Entities.User
{
    public class UserRoleEntity: AEntityBase, IEntityBase
    {
        public int Id => UserRoleId;
        [Key]
        public int UserRoleId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public UserRoleEnum RoleKey { get; set; }
    }
}
