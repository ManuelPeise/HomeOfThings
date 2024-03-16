using Date.Models.Enums;

namespace Date.Models.Models.User.Export
{
    public class UserExportModel : AUserExportBase
    {
        public IEnumerable<UserRoleEnum> UserRoles { get; set; } = new List<UserRoleEnum>();
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public List<UserRight> UserRights { get; set; } = new List<UserRight>();
    }

    public class UserRight
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public AppModuleEnum ModuleKey { get; set; }
        public bool Deny { get; set; }
        public bool View { get; set; }
        public bool Write { get; set; }
        public bool Delete { get; set; }
    }
}
