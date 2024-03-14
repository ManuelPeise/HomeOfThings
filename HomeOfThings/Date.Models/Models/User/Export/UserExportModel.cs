using Date.Models.Enums;

namespace Date.Models.Models.User.Export
{
    public class UserExportModel: AUserExportBase
    {
        public IEnumerable<UserRoleEnum> UserRoles { get; set; } = new List<UserRoleEnum>();
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
    }
}
