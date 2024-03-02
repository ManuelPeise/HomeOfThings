namespace Date.Models.Models.User
{
    public class AUser: AUserBase
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string UserRolesJson { get; set; } = string.Empty;
    }
}
