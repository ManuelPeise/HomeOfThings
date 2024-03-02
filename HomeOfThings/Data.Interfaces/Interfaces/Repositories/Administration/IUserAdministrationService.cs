using Date.Models.Models.User.Export;
using Date.Models.Models.User.Import;
using Microsoft.AspNetCore.Http;

namespace Data.Interfaces.Interfaces.Repositories.Administration
{
    public interface IUserAdministrationService: IDisposable
    {
        Task<UserExportModel?> GetUserByEmail(string email, IHttpContextAccessor contextAccessor);
        Task<List<UserExportModel>> GetAllUsers(IHttpContextAccessor contextAccessor);
        Task<UserExportModel?> GetUserById(int userId, IHttpContextAccessor contextAccessor);
        Task<bool> RegisterUser(UserRegistrationImportModel registrationModel, IHttpContextAccessor contextAccessor);
        Task<bool> ChangeActiveState(int userId, bool isActive, IHttpContextAccessor contextAccessor);
    }
}
