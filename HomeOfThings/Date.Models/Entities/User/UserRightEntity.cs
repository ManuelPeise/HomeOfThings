using Date.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Date.Models.Entities.User
{
    public class UserRightEntity: AEntityBase, IEntityBase
    {
        public int Id => UserRightId;
        [Key]
        public int UserRightId { get; set; }
        public string Name { get; set; } = string.Empty;
        public AppModuleEnum ModuleKey { get; set; }
    }
}
