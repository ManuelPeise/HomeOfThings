using Date.Models.Entities.Family;
using Date.Models.Entities.User;

namespace Data.Interfaces.Interfaces.Repositories.Family
{
    public interface IFamilyAdministrationRepository : IDisposable
    {
        Task<IEnumerable<FamilyEntity>> GetFamilies();
        Task<FamilyEntity?> GetFamilyById(int id);
        Task<IEnumerable<UserEntity>> GetFamilyUsers(Guid famlilyGuid);
        Task<string> GetAdminRoleJson();
        Task<bool> AddFamily(FamilyEntity entity);
        Task<bool> AddFamilyAdmin(UserEntity entity);
    }
}
