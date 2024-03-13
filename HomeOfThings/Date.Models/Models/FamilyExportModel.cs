using Date.Models.Models.User.Export;

namespace Date.Models.Models
{
    public class FamilyExportModel
    {
        public int FamilyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid FamilyGuid { get; set; }
        public bool IsActive { get; set; }
        public List<UserExportModel> Users { get; set; } = new List<UserExportModel>();
    }
}
