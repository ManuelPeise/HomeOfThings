using Data.Interfaces.Interfaces.Repositories.User;
using Data.Interfaces.UnitsOfWork;
using Database.HotContext;
using Date.Models.Entities.User;
using Date.Models.Models.User.Export;
using Date.Models.Models.User.Import;
using Logic.Shared.Extensions.User;
using Logic.Shared.Helpers;
using Logic.Shared.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Security.Claims;


namespace Logic.Shared.UnitsOfWork
{
    public class UserUnitOfWork : AUnitOfWork, IUserUnitOfWork
    {
        private readonly IUserAdministrationRepository _userAdministartionRepository;
        private readonly IHttpContextAccessor _httpContext;
        private bool disposedValue;

        public UserUnitOfWork(DatabaseContext context, IHttpContextAccessor httpContext) : base(context)
        {
            _httpContext = httpContext;
            _userAdministartionRepository = new UserAdministartionRepository(context);
        }

        public async Task<UserExportModel?> TrySign(UserLoginModel loginModel)
        {
            UserExportModel? exportModel = null;

            var claims = new List<Claim>();
            var user = await _userAdministartionRepository.GetUserByEmailAsync(loginModel.Email);

            if (user == null)
            {
                return null;
            }

            if (PasswordHelper.GetEncodedPassword(loginModel.Password, user.Salt).Equals(user.Password))
            {
                exportModel = user.ToExportModel();

                var userRoleJson = await GetUserRoles(user.UserRolesJson);

                exportModel.UserRolesJson = userRoleJson;

                claims = await GetUserClaims(user, userRoleJson);
            }

            if (claims.Any())
            {
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await _httpContext.HttpContext.SignInAsync(
                  CookieAuthenticationDefaults.AuthenticationScheme, principal, new Microsoft.AspNetCore.Authentication.AuthenticationProperties { IsPersistent = true }
                );
            }

            return exportModel;
        }

        public async Task SignOutAsync()
        {
            await _httpContext.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }


        // GetProfileData
        // UpdateProfileData
        #region private members

        private async Task<string> GetUserRoles(string userRolesJson)
        {
            var defaultRoles = await _userAdministartionRepository.GetUserRoles(new List<int> { 1 });

            return !string.IsNullOrWhiteSpace(userRolesJson) ?
                userRolesJson :
                JsonConvert.SerializeObject(defaultRoles);
        }

        private async Task<List<Claim>> GetUserClaims(UserEntity user, string userRoleJson)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(user)),
                    new Claim("UserRoles", userRoleJson),
                };

            return claims;
        }


        #endregion

        #region dispose

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _userAdministartionRepository.Dispose();

                    disposedValue = true;
                }
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


