namespace Date.Models.Models.User.Import
{
    public class UserRegistrationImportModel: AUserBase
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
    }
}
