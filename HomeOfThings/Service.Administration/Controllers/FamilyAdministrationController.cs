using Data.Interfaces.Interfaces.Clients;
using Database.HotContext;
using Date.Models.Models.Family;
using Logic.Administration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Shared;


namespace Service.Administration.Controllers
{
    public class FamilyAdministrationController : ApiControllerBase
    {
       
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailClient? _emailClient;
        private readonly DatabaseContext _databaseContext;
        
        public FamilyAdministrationController(DatabaseContext databaseContext, IHttpContextAccessor httpContextAccessor, IEmailClient? emailClient)
        {
            _httpContextAccessor = httpContextAccessor;
            _databaseContext = databaseContext;
            _emailClient = emailClient;
        }
        
        // [ApiAuthorization(UserRoleEnum.SystemAdmin)]
        [HttpGet( Name = "GetFamilyById")]
        public async Task<FamilyExportModel?> GetFamilyById(Guid familyId)
        {
            using(var service = new FamilyAdministrationService(_databaseContext, _httpContextAccessor, _emailClient))
            {
                return await service.GetFamilyByGuid(familyId);
            }
        }
        
        // [ApiAuthorization(UserRoleEnum.SystemAdmin)]
        [HttpGet( Name = "GetFamilies")]
        public async Task<List<FamilyExportModel>?> GetFamilies()
        {
            using (var service = new FamilyAdministrationService(_databaseContext, _httpContextAccessor, _emailClient))
            {
                return await service.GetFamilies();
            }
        }

        [HttpPost(Name = "RegisterFamily")]
        public async Task<bool> RegisterFamily([FromBody] FamilyImportModel model)
        {
            using (var service = new FamilyAdministrationService(_databaseContext, _httpContextAccessor, _emailClient))
            {
                return await service.RegisterNewFamily(model);
            }
        }

        [HttpPost(Name = "UpdateFamily")]
        public async Task<bool> UpdateFamily([FromBody] FamilyImportModel model)
        {
            using (var service = new FamilyAdministrationService(_databaseContext, _httpContextAccessor, _emailClient))
            {
                return await service.UpdateFamily(model);
            }
        }
    }
}
