using Data.Interfaces.Interfaces.Clients;
using Database.HotContext;
using Date.Models.Entities.Log;
using Date.Models.Entities.User;
using Date.Models.Enums;
using Date.Models.Models.User.Import;
using Logic.Shared;
using Logic.Shared.Extensions.User;
using Logic.Shared.UnitsOfWork;
using Microsoft.AspNetCore.Http;

namespace Logic.Administration
{
    public class UserAdministrationService : ALogicBase, IDisposable
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IEmailClient? _emailClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private bool disposedValue;

        #region default userModules

        private readonly List<AppModuleEnum> _sytemAdminModules = new List<AppModuleEnum> { AppModuleEnum.FamilyAdministration };
        private readonly List<AppModuleEnum> _adminModules = new List<AppModuleEnum> { AppModuleEnum.FamilyManagement };
        private readonly List<AppModuleEnum> _defaultUserModules = new List<AppModuleEnum>();

        #endregion

        public UserAdministrationService(
            DatabaseContext context,
            IHttpContextAccessor httpContextAccessor,
            IEmailClient? emailClient = null) : base(context)
        {
            _databaseContext = context;
            _emailClient = emailClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<UserEntity>> GetFamilyUsers(Guid familyGuid)
        {
            try
            {
                using (var unitOfWork = new UserUnitOfWork(_databaseContext))
                {
                    return await unitOfWork.UserRepository.GetAllAsync(new QueryOption<UserEntity>
                    {
                        AsNoTracking = true,
                        WhereExpression = x => x.FamilyGuid == familyGuid
                    });
                }
            }
            catch (Exception exception)
            {
                await LogRepository.AddMessage(new LogEntity
                {
                    Message = $"Cannot load users for family [{familyGuid}]!",
                    ExMessage = exception.Message,
                    StackTrace = exception.StackTrace ?? string.Empty,
                    TimeStamp = DateTime.UtcNow,
                    Trigger = nameof(UserAdministrationService),
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = nameof(UserAdministrationService)
                });

                await Save(_httpContextAccessor.HttpContext);

                return new List<UserEntity>();
            }
        }

        public async Task<bool> RegisterUser(UserRegistrationImportModel importModel, string password, bool sendMail = false)
        {
            try
            {
                using (var unitOfWork = new UserUnitOfWork(_databaseContext))
                {
                    var userEntity = importModel.ToEntity(password);

                    if (userEntity == null || string.IsNullOrWhiteSpace(userEntity.Email))
                    {
                        return false;
                    }

                    unitOfWork.UserRepository.Add(userEntity);

                    var userId = await unitOfWork.UserRepository.GetNextIndex();

                    var (accessRightEntities, roleEntities) = await GetUserAccessRightsAndRoles(unitOfWork, importModel.UserRole);

                    var userRights = (from right in accessRightEntities
                                      select new UserAccessRightEntity
                                      {
                                          UserRightId = right.Id,
                                          UserId = userId,
                                          Deny = false,
                                          Write = importModel.UserRole == UserRoleEnum.SystemAdmin || importModel.UserRole == UserRoleEnum.Admin ?
                                          true : false,
                                          Delete = false,
                                          View = true,
                                      }).ToList();

                    var userRoles = (from role in roleEntities
                                     select new UserRolesEntity
                                     {
                                         UserId = userId,
                                         UserRolesId = role.Id,

                                     }).ToList();

                    

                    userRights.ForEach(r =>
                    {
                        unitOfWork.UserAccessRightRepository.Add(r);
                    });

                    userRoles.ForEach(r =>
                    {
                        unitOfWork.UserRolesRepository.Add(r);
                    });

                    return true;
                }
            }
            catch (Exception exception)
            {
                await LogRepository.AddMessage(new LogEntity
                {
                    Message = "Cannot register new user!",
                    ExMessage = exception.Message,
                    StackTrace = exception.StackTrace ?? string.Empty,
                    TimeStamp = DateTime.UtcNow,
                    Trigger = nameof(UserAdministrationService),
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = nameof(UserAdministrationService)
                });

                await Save(_httpContextAccessor.HttpContext);

                return false;
            }
        }

        public async Task UpdateUser(UserEntity entityToUpdate, bool save)
        {
            try
            {
                using (var unitOfWork = new UserUnitOfWork(_databaseContext))
                {
                    unitOfWork.UserRepository.Update(entityToUpdate);

                    if (save)
                    {
                        await unitOfWork.UserRepository.SaveAsync();
                    }
                }
            }
            catch (Exception exception)
            {
                await LogRepository.AddMessage(new LogEntity
                {
                    Message = $"Cannot update user [{entityToUpdate.UserId}]!",
                    ExMessage = exception.Message,
                    StackTrace = exception.StackTrace ?? string.Empty,
                    TimeStamp = DateTime.UtcNow,
                    Trigger = nameof(UserAdministrationService),
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = nameof(UserAdministrationService)
                });

                await Save(_httpContextAccessor.HttpContext);
            }
        }

        #region private members

        private async Task<(List<UserRightEntity>, List<UserRoleEntity>)> GetUserAccessRightsAndRoles(UserUnitOfWork unitOfWork, UserRoleEnum userRole)
        {
            switch (userRole)
            {
                case UserRoleEnum.SystemAdmin:
                    return await GetAccessRightsAndRoles(unitOfWork, _sytemAdminModules, userRole);
                case UserRoleEnum.Admin:
                    return await GetAccessRightsAndRoles(unitOfWork, _adminModules, userRole);
                case UserRoleEnum.User:
                    return await GetAccessRightsAndRoles(unitOfWork, _defaultUserModules, userRole);
                default: throw new ArgumentOutOfRangeException(nameof(userRole));
            }
        }

        private async Task<List<UserRightEntity>> GetUserRights(UserUnitOfWork unitOfWork, List<AppModuleEnum> modules)
        {
            return await unitOfWork.UserRightRepository.GetAllAsync(new QueryOption<UserRightEntity>
            {
                AsNoTracking = true,
                WhereExpression = x => modules.Contains(x.ModuleKey)
            });
        }

        private async Task<List<UserRoleEntity>> GetUserRoles(UserUnitOfWork unitOfWork, UserRoleEnum userRole)
        {
            return await unitOfWork.UserRoleRepository.GetAllAsync(new QueryOption<UserRoleEntity>
            {
                AsNoTracking = true,
                WhereExpression = x => x.RoleKey == userRole
            });
        }

        private async Task<(List<UserRightEntity>, List<UserRoleEntity>)> GetAccessRightsAndRoles(UserUnitOfWork unitOfWork, List<AppModuleEnum> modulesToAdd, UserRoleEnum roleToAdd)
        {
            var userRights = await GetUserRights(unitOfWork, modulesToAdd);
            var userRoles = await GetUserRoles(unitOfWork, roleToAdd);

            return (userRights, userRoles);
        }

        #endregion

        #region dispose

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // _databaseContext.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
