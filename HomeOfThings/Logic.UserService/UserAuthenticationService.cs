using Data.Interfaces.UnitsOfWork;
using Database.HotContext;
using Date.Models.Entities.Log;
using Date.Models.Models.User.Export;
using Date.Models.Models.User.Import;
using Logic.Shared;
using Microsoft.AspNetCore.Http;

namespace Logic.UserService
{
    public class UserAuthenticationService : ALogicBase, IDisposable
    {
        private readonly IUserUnitOfWork _userUnitOfWork;
        private bool disposedValue;

        public UserAuthenticationService(IUserUnitOfWork userUnitOfWork, DatabaseContext context) : base(context)
        {
            _userUnitOfWork = userUnitOfWork;
        }

        public async Task<UserExportModel?> TryLoginUser(UserLoginModel loginModel)
        {
            try
            {
                return await _userUnitOfWork.TrySign(loginModel);

            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task TrySignOut(IHttpContextAccessor httpContextAccessor)
        {
            try
            {
                await _userUnitOfWork.SignOutAsync();

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

        #region dispose
        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _userUnitOfWork?.Dispose();
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
