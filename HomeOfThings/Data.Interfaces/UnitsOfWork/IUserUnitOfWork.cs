using Date.Models.Models.User.Export;
using Date.Models.Models.User.Import;

namespace Data.Interfaces.UnitsOfWork
{
    public interface IUserUnitOfWork: IDisposable
    {
        Task<UserExportModel?> TrySign(UserLoginModel loginModel);
        Task SignOutAsync();
    }
}
