using System.ComponentModel.DataAnnotations;

namespace Date.Models.Entities.User
{

    public class UserAccessRightEntity: AEntityBase, IEntityBase
    {
        public int Id => UserAccessRightId;
        [Key]
        public int UserAccessRightId { get; set; }
        public int UserId { get; set; }
        public int UserRightId { get; set; }
        public bool Deny { get; set; }
        public bool View { get; set; }
        public bool Write { get; set; }
        public bool Delete { get; set; }
    }
}
