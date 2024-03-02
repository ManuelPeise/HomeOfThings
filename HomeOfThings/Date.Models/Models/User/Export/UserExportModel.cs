namespace Date.Models.Models.User.Export
{
    public class UserExportModel: AUserExportBase
    {
        public string UserRolesJson { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
    }
}
