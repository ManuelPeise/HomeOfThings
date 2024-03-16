using Database.HotContext;
using Date.Models.Models.User.Export;
using Date.Models.Models.User.Import;
using Logic.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Shared;

namespace Service.UserService.Controllers
{
    public class AuthenticationServiceController: ApiControllerBase
    {
        private readonly DatabaseContext _datebaseContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticationServiceController(DatabaseContext context, IHttpContextAccessor httpContextAccessor)
        {
            _datebaseContext = context;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost(Name = "UserLogin")]
        public async Task<UserExportModel> UserLogin([FromBody] UserLoginModel loginModel)
        {
            using(var service = new UserAuthenticationService(_datebaseContext))
            {
                return await service.TryLoginUser(loginModel, _httpContextAccessor);
            }
        }

        [HttpGet(Name ="UserLogout")]
        public async Task UserLogout()
        {
            using (var service = new UserAuthenticationService(_datebaseContext))
            {
                await service.TrySignOut(_httpContextAccessor);
            }
        }
    }
}
