using Date.Models.Models.User.Export;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Shared;

namespace Service.Administration.Controllers
{
    public class UserAdministrationController : ApiControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserAdministrationController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet(Name = "GetAllUsers")]
        public async Task<List<UserExportModel>> GetAllUsers()
        {
            return new List<UserExportModel>();
        }

        [HttpGet("{userId}", Name = "GetUserById")]
        public async Task<UserExportModel?> GetUserById(int userId)
        {
            return new UserExportModel();
        }

        [HttpGet("{email}", Name = "GetUserByEmail")]
        public async Task<UserExportModel?> GetUserByEmail(string email)
        {
            return new UserExportModel();
        }

      
    }
}
