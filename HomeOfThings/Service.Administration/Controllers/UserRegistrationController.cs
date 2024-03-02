using Data.Interfaces.Interfaces.Repositories.Administration;
using Date.Models.Models.User.Import;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Service.Administration.Controllers
{
    public class UserRegistrationController
    {
        private IUserAdministrationService _userAdministration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserRegistrationController(IUserAdministrationService userAdministration, IHttpContextAccessor httpContextAccessor)
        {
            _userAdministration = userAdministration;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost(Name = "RegisterUser")]
        public async Task<bool> RegisterUser([FromBody] UserRegistrationImportModel model)
        {
            return await _userAdministration.RegisterUser(model, _httpContextAccessor);
        }

        [HttpGet("{userId}", Name = "ActivateUser")]
        public async Task<bool> ActivateUser(int userId)
        {
            return await _userAdministration.ChangeActiveState(userId, true, _httpContextAccessor);
        }
    }
}
