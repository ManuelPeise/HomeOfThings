using Data.Interfaces.Interfaces.Repositories;
using Data.Interfaces.Interfaces.Repositories.User;
using Database.HotContext;
using Date.Models.Entities.User;

namespace Logic.Shared.Repositories
{
    public class UserAdministartionRepository : IUserAdministrationRepository
    {
        private readonly IRepositoryBase<UserEntity> _userRepositoryBase;
        private readonly IRepositoryBase<UserRoleEntity> _userRoleRepositoryBase;
        private bool disposedValue1;

        public UserAdministartionRepository(DatabaseContext context)
        {
            _userRepositoryBase = new RepositoryBase<UserEntity>(context);
            _userRoleRepositoryBase = new RepositoryBase<UserRoleEntity>(context);
        }

        public async Task<List<UserEntity>> GetAllUsersAsync()
        {
            var users = await _userRepositoryBase.GetAllAsync();
            return users.ToList();
        }

        public async Task<UserEntity?> GetUserByEmailAsync(string email)
        {
            return await _userRepositoryBase.GetFirstOrDefaultAsync(x => x.Email.ToLower().Equals(email.ToLower()));
        }

        public async Task<UserEntity?> GetUserByIdAsync(int id)
        {
            return await _userRepositoryBase.GetFirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> RegisterUserAsync(UserEntity user)
        {
            return await _userRepositoryBase.InsertIfNotExists(user, x => x.Email.ToLower().Equals(user.Email.ToLower()));
        }
        
        public void UpdateUser(UserEntity user)
        {
            if (user != null)
            {
                _userRepositoryBase.Update(user);
            }
        }

        public async Task<bool> ChangeUserActiveStateAsync(int id, bool isActive)
        {
            var user = await _userRepositoryBase.GetFirstOrDefaultAsync(x => x.Id == id);

            if(user != null)
            {
                user.IsActive = isActive;
                _userRepositoryBase.Update(user);

                return true;
            }

            return false;
        }

        public async Task<List<UserRoleEntity>> GetUserRoles(List<int> ids)
        {
            var roles = await _userRoleRepositoryBase.GetAllAsync();

            return roles.Where(role => ids.Contains(role.Id)).ToList();  
        }

        #region dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue1)
            {
                if (disposing)
                {
                    _userRepositoryBase.Dispose();
                    _userRoleRepositoryBase.Dispose();
                }

                disposedValue1 = true;
            }
        }

        public void Dispose()
        {
            // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in der Methode "Dispose(bool disposing)" ein.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
