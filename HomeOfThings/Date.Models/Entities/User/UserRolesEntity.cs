using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Date.Models.Entities.User
{
    public class UserRolesEntity: AEntityBase, IEntityBase
    {
        public int Id => UserRoleId;
        [Key]
        public int UserRolesId { get; set; }
        public int UserId { get; set; }
        public int UserRoleId { get; set; }
       
    }
}
