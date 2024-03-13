using Data.Interfaces.Interfaces.Repositories;
using Data.Interfaces.Interfaces.Repositories.Family;
using Database.HotContext;
using Date.Models.Entities.Family;
using Date.Models.Entities.User;
using Newtonsoft.Json;

namespace Logic.Shared.Repositories
{
    public class FamilyAdministrationRepository : IFamilyAdministrationRepository
    {
        private bool disposedValue;
        private readonly IRepositoryBase<UserEntity> _userRepository;
        private readonly IRepositoryBase<UserRoleEntity> _userRoleRepository;
        private IRepositoryBase<FamilyEntity> _familyRepository;

        public FamilyAdministrationRepository(DatabaseContext context)
        {
            _userRepository = new RepositoryBase<UserEntity>(context);
            _userRoleRepository = new RepositoryBase<UserRoleEntity>(context);
            _familyRepository = new RepositoryBase<FamilyEntity>(context);
        }

        public async Task<IEnumerable<FamilyEntity>> GetFamilies()
        {
            return await _familyRepository.GetAllAsync();
        }

        public async Task<FamilyEntity?> GetFamilyById(int id)
        {
            return await _familyRepository.GetFirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<UserEntity>> GetFamilyUsers(Guid famlilyGuid)
        {
            return await _userRepository.GetAllAsync(x => x.FamilyGuid == famlilyGuid);
        }
        
        public async Task<string> GetAdminRoleJson()
        {
            var entity = await _userRoleRepository.GetFirstOrDefaultAsync(x => x.Name.Equals("Admin"));

            return JsonConvert.SerializeObject(entity, Formatting.Indented);
        }
        
        public async Task<bool> AddFamily(FamilyEntity entity)
        {
            return await _familyRepository.InsertIfNotExists(entity, x => x.FamilyGuid == entity.FamilyGuid);
        }

        public async Task<bool> AddFamilyAdmin(UserEntity entity)
        {
            return await _userRepository.InsertIfNotExists(entity, x => x.Email.Equals(entity.Email));
        }

        public async Task<bool> UpdateFamily(FamilyEntity entity)
        {
            try
            {
                _familyRepository.Update(entity);
            
                return await Task.FromResult(true);

            }catch(Exception) 
            {
                return await Task.FromResult(false);
            }
        }

        public void UpdateFamilyUser(UserEntity entity)
        {
            _userRepository.Update(entity);
        }
        #region dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _familyRepository.Dispose();
                    _userRepository.Dispose();
                    _userRoleRepository.Dispose();
                }

                disposedValue = true;
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
