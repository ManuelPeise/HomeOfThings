using Date.Models.Entities.Family;
using Date.Models.Models;
using Date.Models.Models.Family;
using Date.Models.Models.User.Export;

namespace Logic.Shared.Extensions.Family
{
    public static class FamilyExtensions
    {
        public static FamilyExportModel ToExportModel(this FamilyEntity entity)
        {
            return new FamilyExportModel
            {
                FamilyId = entity.Id,
                FamilyGuid = entity.FamilyGuid,
                Name = entity.Name,
                IsActive = entity.IsActive,
                Users = new List<UserExportModel>()
            };
        }

        public static FamilyEntity ToEntity(this FamilyImportModel model, Guid familyGuid)
        {
            return new FamilyEntity
            {
                FamilyGuid = familyGuid,
                Name = model.Name,
                IsActive = model.IsActive,
            };
        }
    }
}
