using Date.Models.Models.User.Import;

namespace Date.Models.Models.Family
{
    public class FamilyImportModel
    {
        public int FamilyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public UserRegistrationImportModel UserRegistrationModel { get; set; } = new UserRegistrationImportModel();
    }
}
