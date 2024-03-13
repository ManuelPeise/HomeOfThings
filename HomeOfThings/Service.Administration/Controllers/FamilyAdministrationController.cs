using Data.Interfaces.Interfaces.Repositories.Administration;
using Data.Interfaces.Interfaces.Repositories.Family;
using Database.HotContext;
using Date.Models.Models;
using Date.Models.Models.Family;
using Logic.Administration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Administration.Controllers
{
    public class FamilyAdministrationController : ApiControllerBase
    {
        private readonly IFamilyAdministrationRepository _familyAdministrationRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DatabaseContext _databaseContext;
        public FamilyAdministrationController(DatabaseContext databaseContext, IFamilyAdministrationRepository familyAdministrationRepo, IHttpContextAccessor httpContextAccessor)
        {
            _familyAdministrationRepo = familyAdministrationRepo;
            _httpContextAccessor = httpContextAccessor;
            _databaseContext = databaseContext;
        }

        [HttpGet( Name = "GetFamilyById")]
        public async Task<FamilyExportModel?> GetFamilyById(int familyId)
        {
            var service = new FamilyAdministrationService(_databaseContext, _familyAdministrationRepo);

            return await service.GetFamily(familyId, _httpContextAccessor);
        }

        [HttpGet("{familyId}", Name = "GetFamilies")]
        public async Task<List<FamilyExportModel>?> GetFamilies()
        {
            var service = new FamilyAdministrationService(_databaseContext, _familyAdministrationRepo);

            return await service.GetFamilies(_httpContextAccessor);
        }

        [HttpPost(Name = "RegisterFamily")]
        public async Task<bool> RegisterFamily([FromBody] FamilyImportModel model)
        {
            var service = new FamilyAdministrationService(_databaseContext, _familyAdministrationRepo);

            return await service.RegisterFamily(model, _httpContextAccessor);
        }
    }
}
