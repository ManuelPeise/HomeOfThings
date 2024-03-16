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
        private readonly DatabaseContext _databaseContext;
        
        public FamilyAdministrationController(DatabaseContext databaseContext, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _databaseContext = databaseContext;
        }
        
        // [ApiAuthorization(UserRoleEnum.SystemAdmin)]
        [HttpGet( Name = "GetFamilyById")]
        public async Task<FamilyExportModel?> GetFamilyById(Guid familyId)
        {
            using(var service = new FamilyAdministrationService(_databaseContext, _httpContextAccessor))
            {
                return await service.GetFamilyByGuid(familyId);
            }
        }
        
        // [ApiAuthorization(UserRoleEnum.SystemAdmin)]
        [HttpGet( Name = "GetFamilies")]
        public async Task<List<FamilyExportModel>?> GetFamilies()
        {
            using (var service = new FamilyAdministrationService(_databaseContext, _httpContextAccessor))
            {
                return await service.GetFamilies();
            }
        }

        [HttpPost(Name = "RegisterFamily")]
        public async Task<bool> RegisterFamily([FromBody] FamilyImportModel model)
        {
            using (var service = new FamilyAdministrationService(_databaseContext, _httpContextAccessor))
            {
                return await service.RegisterNewFamily(model);
            }
        }

        [HttpPost(Name = "UpdateFamily")]
        public async Task<bool> UpdateFamily([FromBody] FamilyImportModel model)
        {
            using (var service = new FamilyAdministrationService(_databaseContext, _httpContextAccessor))
            {
                return await service.UpdateFamily(model);
            }
        }
    }
}
