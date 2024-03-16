using Database.HotContext;
using Date.Models.Entities.Log;
using Date.Models.Entities.User;
using Date.Models.Models.User.Export;
using Date.Models.Models.User.Import;
using Logic.Shared;
using Logic.Shared.Helpers;
using Logic.Shared.UnitsOfWork;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Data;
using System.Security.Claims;

namespace Logic.UserService
{
    public class UserAuthenticationService : ALogicBase, IDisposable
    {
        private bool disposedValue;
        private readonly DatabaseContext _databaseContext;
        public UserAuthenticationService(DatabaseContext context) : base(context)
        {
            _databaseContext = context;
        }

        public async Task<UserExportModel> TryLoginUser(UserLoginModel loginModel, IHttpContextAccessor httpContextAccessor)
        {
            using (var unitOfWork = new UserUnitOfWork(_databaseContext))
            {
                try
                {
                    var claims = new List<Claim>();

                    var userData = await unitOfWork.UserRepository.GetAsync(new QueryOption<UserEntity>
                    {
                        AsNoTracking = true,
                        WhereExpression = x => x.Email.ToLower().Equals(loginModel.Email.ToLower()),
                    });

                    if (userData == null)
                    {
                        return new UserExportModel();
                    }

                    if (!PasswordHelper.GetEncodedPassword(userData.Password, userData.Salt).ToLower().Equals(loginModel.Password.ToLower()))
                    {
                        return new UserExportModel();
                    }

                    var userRoles = await GetUserRoles(unitOfWork, userData.UserId);

                    var userRights = await GetUserRights(unitOfWork, userData.UserId);

                    var exportModel = new UserExportModel
                    {
                        UserId = userData.UserId,
                        FirstName = userData.FirstName,
                        LastName = userData.LastName,
                        Email = userData.Email,
                        DateOfBirth = userData.DateOfBirth,
                        IsActive = userData.IsActive,
                        UserRoles = (from role in userRoles select role.RoleKey),
                        UserRights = userRights
                    };

                    LoadUserClaims(claims, exportModel, userRoles, userRights);

                    if (claims.Any())
                    {
                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);

                        await httpContextAccessor.HttpContext.SignInAsync(
                          CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = true }
                        );

                        return exportModel;
                    }

                    return new UserExportModel();
                }
                catch (Exception)
                {
                    return new UserExportModel();
                }
            }

        }
        public async Task TrySignOut(IHttpContextAccessor httpContextAccessor)
        {
            try
            {
                await httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            }
            catch (Exception exception)
            {
                await LogRepository.AddMessage(new LogEntity
                {
                    Message = "Sign out user failed!",
                    ExMessage = exception.Message,
                    StackTrace = exception.StackTrace ?? string.Empty,
                    TimeStamp = DateTime.UtcNow,
                    Trigger = nameof(UserAuthenticationService),
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = nameof(UserAuthenticationService)
                });

                await Save(httpContextAccessor.HttpContext);
            }
        }

        #region private members

        private async Task<List<UserRoleEntity>> GetUserRoles(UserUnitOfWork unitOfWork, int userId)
        {
            var userRoles = new List<UserRoleEntity>();

            var roles = await unitOfWork.UserRolesRepository.GetAllAsync(new QueryOption<UserRolesEntity>
            {
                AsNoTracking = true,
                WhereExpression = x => x.UserId == userId
            });

            if (roles == null || !roles.Any())
            {
                return userRoles;
            }

            foreach (var role in roles)
            {
                var currentRole = await unitOfWork.UserRoleRepository.GetAsync(new QueryOption<UserRoleEntity>
                {
                    AsNoTracking = true,
                    WhereExpression = x => x.UserRoleId == role.UserRoleId
                });

                if (currentRole != null)
                {
                    userRoles.Add(currentRole);
                }
            }

            return userRoles;
        }

        private async Task<List<UserRight>> GetUserRights(UserUnitOfWork unitOfWork, int userId)
        {
            var userRights = new List<UserRight>();

            var accessRights = await unitOfWork.UserAccessRightRepository.GetAllAsync(new QueryOption<UserAccessRightEntity>
            {
                AsNoTracking = true,
                WhereExpression = x => x.UserId == userId
            });

            if (accessRights == null)
            {
                return userRights;
            }

            foreach (var right in accessRights)
            {
                var currentRight = await unitOfWork.UserRightRepository.GetAsync(new QueryOption<UserRightEntity>
                {
                    AsNoTracking = true,
                    WhereExpression = x => x.UserRightId == right.UserRightId
                });

                if (currentRight != null)
                {
                    userRights.Add(new UserRight
                    {
                        Id = currentRight.Id,
                        Name = currentRight.Name,
                        ModuleKey = currentRight.ModuleKey,
                        Deny = right.Deny,
                        View = right.View,
                        Write = right.Write,
                        Delete = right.Delete,
                    });
                }
            }

            return userRights;

        }

        private void LoadUserClaims(List<Claim> claims, UserExportModel user, List<UserRoleEntity> userRoles, List<UserRight> userRights)
        {
            claims.AddRange(new List<Claim>
            {
                    new Claim(ClaimTypes.NameIdentifier, user.Email),
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(user)),
                    new Claim("roles", JsonConvert.SerializeObject(userRoles)),
                    new Claim("accessRights", JsonConvert.SerializeObject(userRights))
            });
        }

        #endregion

        #region dispose

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _databaseContext.Dispose();
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
