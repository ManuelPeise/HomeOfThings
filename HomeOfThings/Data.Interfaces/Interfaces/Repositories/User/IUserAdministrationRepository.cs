using Date.Models.Entities.User;

namespace Data.Interfaces.Interfaces.Repositories.User
{
    public interface IUserAdministrationRepository: IDisposable
    {
        Task<List<UserEntity>> GetAllUsersAsync();
        Task<UserEntity?> GetUserByIdAsync(int id);
        Task<UserEntity?> GetUserByEmailAsync(string email);
        Task<bool> RegisterUserAsync(UserEntity user);
        Task<bool> ChangeUserActiveStateAsync(int id, bool isActive);
        Task<List<UserRoleEntity>> GetUserRoles(List<int> ids);
        void UpdateUser(UserEntity user);
    }
}
