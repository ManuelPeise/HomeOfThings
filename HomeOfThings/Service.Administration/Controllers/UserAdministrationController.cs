using Data.Interfaces.Interfaces.Repositories.Administration;
using Date.Models.Models.User.Export;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Shared;

namespace Service.Administration.Controllers
{
    public class UserAdministrationController : ApiControllerBase
    {
        private IUserAdministrationService _userAdministration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserAdministrationController(IUserAdministrationService userAdministration, IHttpContextAccessor httpContextAccessor)
        {
            _userAdministration = userAdministration;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet(Name = "GetAllUsers")]
        public async Task<List<UserExportModel>> GetAllUsers()
        {
            return await _userAdministration.GetAllUsers(_httpContextAccessor);
        }

        [HttpGet("{userId}", Name = "GetUserById")]
        public async Task<UserExportModel?> GetUserById(int userId)
        {
            return await _userAdministration.GetUserById(userId, _httpContextAccessor);
        }

        [HttpGet("{email}", Name = "GetUserByEmail")]
        public async Task<UserExportModel?> GetUserByEmail(string email)
        {
            return await _userAdministration.GetUserByEmail(email, _httpContextAccessor);
        }

        //[HttpGet("{userId}", Name = "ActivateUser")]
        //public async Task<bool> ActivateUser(int userId)
        //{
        //    return await _userAdministration.ChangeActiveState(userId, true, _httpContextAccessor);
        //}

        //[HttpGet("{userId}", Name = "DeActivateUser")]
        //public async Task<bool> DeActivateUser(int userId)
        //{
        //    return await _userAdministration.ChangeActiveState(userId, false, _httpContextAccessor);
        //}
    }
}
