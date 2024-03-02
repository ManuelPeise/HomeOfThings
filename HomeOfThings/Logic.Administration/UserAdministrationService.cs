using Data.Interfaces.Interfaces.Clients;
using Data.Interfaces.Interfaces.Repositories.Administration;
using Data.Interfaces.Interfaces.Repositories.User;
using Data.Ressources;
using Database.HotContext;
using Date.Models.Entities.Log;
using Date.Models.Models.User.Export;
using Date.Models.Models.User.Import;
using Logic.Shared;
using Logic.Shared.Extensions.User;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Logic.Administration
{
    public class UserAdministrationService : ALogicBase, IUserAdministrationService
    {
        private readonly IUserAdministrationRepository _userAdministationRepository;
        private readonly IConfiguration _config;
        private readonly IEmailClient _emailClient;
        private bool disposedValue;

        public UserAdministrationService(
            DatabaseContext context, 
            IUserAdministrationRepository userAdministationRepository, 
            IConfiguration config, 
            IEmailClient emailClient) : base(context)
        {
            _userAdministationRepository = userAdministationRepository;
            _config = config;
            _emailClient = emailClient;
        }

        public async Task<List<UserExportModel>> GetAllUsers(IHttpContextAccessor contextAccessor)
        {
            try
            {
                var users = await _userAdministationRepository.GetAllUsersAsync();

                return (from user in users select user.ToExportModel()).ToList();

            }
            catch (Exception exception)
            {
                await LogRepository.AddMessage(new LogEntity
                {
                    Message = $"Could not get users from database!",
                    ExMessage = exception.Message,
                    StackTrace = exception.StackTrace ?? string.Empty,
                    TimeStamp = DateTime.UtcNow,
                    Trigger = nameof(UserAdministrationService),
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = nameof(UserAdministrationService),
                });

                await Save(contextAccessor.HttpContext);

                return new List<UserExportModel>();
            }
        }

        public async Task<UserExportModel?> GetUserById(int userId, IHttpContextAccessor contextAccessor)
        {
            try
            {
                var user = await _userAdministationRepository.GetUserByIdAsync(userId);

                if(user == null)
                {
                    return null;
                }

                return user.ToExportModel();

            }
            catch (Exception exception)
            {
                await LogRepository.AddMessage(new LogEntity
                {
                    Message = $"Could not get user [{userId}] from database!",
                    ExMessage = exception.Message,
                    StackTrace = exception.StackTrace ?? string.Empty,
                    TimeStamp = DateTime.UtcNow,
                    Trigger = nameof(UserAdministrationService),
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = nameof(UserAdministrationService),
                });

                await Save(contextAccessor.HttpContext);

                return null;
            }
        }

        public async Task<UserExportModel?> GetUserByEmail(string email, IHttpContextAccessor contextAccessor)
        {
            try
            {
                var user = await _userAdministationRepository.GetUserByEmailAsync(email);

                if (user == null)
                {
                    return null;
                }

                return user.ToExportModel();

            }
            catch (Exception exception)
            {
                await LogRepository.AddMessage(new LogEntity
                {
                    Message = $"Could not get user [{email}] from database!",
                    ExMessage = exception.Message,
                    StackTrace = exception.StackTrace ?? string.Empty,
                    TimeStamp = DateTime.UtcNow,
                    Trigger = nameof(UserAdministrationService),
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = nameof(UserAdministrationService),
                });

                await Save(contextAccessor.HttpContext);

                return null;
            }
        }

        public async Task<bool> RegisterUser(UserRegistrationImportModel registrationModel, IHttpContextAccessor contextAccessor)
        {
            try
            {
                var succes = await _userAdministationRepository.RegisterUserAsync(registrationModel.ToEntity());

                var emailHtml = await _emailClient.LoadMailHtmlFromRessources(RessourceNames.RegistrationMailBody);

                if(!string.IsNullOrWhiteSpace(emailHtml))
                {
                    var targetUrl = $"{_config["apiBaseUrl"]}/UserRegistration/ActivateUserPerMail/{registrationModel.Email}";

                    emailHtml = emailHtml.Replace("targetUrl", targetUrl);
                }

                var message = _emailClient.BuilMailMessage(registrationModel.Email, "Confirm your account!", "", emailHtml);

                await _emailClient.SendMail(message);

                return succes;
                
            }
            catch (Exception exception)
            {
                await LogRepository.AddMessage(new LogEntity
                {
                    Message = "Userregistration failed!",
                    ExMessage = exception.Message,
                    StackTrace = exception.StackTrace ?? string.Empty,
                    TimeStamp = DateTime.UtcNow,
                    Trigger = nameof(UserAdministrationService),
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = nameof(UserAdministrationService),
                });

                await Save(contextAccessor.HttpContext);

                return false;
            }
        }

        public async Task ActivateUserPerMail(string email, IHttpContextAccessor contextAccessor)
        {
            try
            {
                var user = await _userAdministationRepository.GetUserByEmailAsync(email);

                if (user == null) return;

                user.EmailConfirmed = true;
                user.IsActive = true;

                _userAdministationRepository.UpdateUser(user);

                await Save(contextAccessor.HttpContext);
            }
            catch (Exception)
            {

            }
        }

        public async Task<bool> ChangeActiveState(int userId, bool isActive, IHttpContextAccessor contextAccessor)
        {
            try
            {
                return await _userAdministationRepository.ChangeUserActiveStateAsync(userId, isActive);

            }
            catch (Exception exception)
            {
                await LogRepository.AddMessage(new LogEntity
                {
                    Message = $"Could not change active state of user [{userId}]!",
                    ExMessage = exception.Message,
                    StackTrace = exception.StackTrace ?? string.Empty,
                    TimeStamp = DateTime.UtcNow,
                    Trigger = nameof(UserAdministrationService),
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = nameof(UserAdministrationService),
                });

                await Save(contextAccessor.HttpContext);

                return false;
            }
        }


        #region dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // _userAdministationRepository.Dispose();
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
