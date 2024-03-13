using Data.Interfaces.Interfaces.Repositories;
using Data.Interfaces.Interfaces.Repositories.Family;
using Database.HotContext;
using Date.Models.Entities;
using Date.Models.Entities.Log;
using Date.Models.Entities.User;
using Date.Models.Models;
using Date.Models.Models.Family;
using Logic.Shared;
using Logic.Shared.Extensions.Family;
using Logic.Shared.Extensions.User;
using Microsoft.AspNetCore.Http;

namespace Logic.Administration
{
    public class FamilyAdministrationService : ALogicBase
    {
        private readonly IFamilyAdministrationRepository _familyAdministrationRepository;

        public FamilyAdministrationService(DatabaseContext context, IFamilyAdministrationRepository familyAdministrationRepository) : base(context)
        {
            _familyAdministrationRepository = familyAdministrationRepository;
        }

        public async Task<FamilyExportModel?> GetFamily(int id, IHttpContextAccessor contextAccessor)
        {
            try
            {
                var entity = await _familyAdministrationRepository.GetFamilyById(id);

                if (entity != null)
                {
                    var members = await _familyAdministrationRepository.GetFamilyUsers(entity.FamilyGuid);

                    var exportModel = entity.ToExportModel();
                    exportModel.Users = (from member in members
                                         select member.ToExportModel())
                                         .ToList();

                    return exportModel;
                }

                return null;
            }
            catch (Exception exception)
            {

                await LogRepository.AddMessage(new LogEntity
                {
                    Message = $"Could not load family [{id}] from database",
                    ExMessage = exception.Message,
                    StackTrace = exception.StackTrace,
                    TimeStamp = DateTime.UtcNow,
                    Trigger = nameof(FamilyAdministrationService)
                });

                await Save(contextAccessor.HttpContext);

                return null;
            }
        }

        public async Task<List<FamilyExportModel>> GetFamilies(IHttpContextAccessor contextAccessor)
        {
            try
            {
                var exportModels = new List<FamilyExportModel>();

                var familyEntities = await _familyAdministrationRepository.GetFamilies();

                if (familyEntities != null && familyEntities.Any())
                {
                    foreach (var familyEntity in familyEntities)
                    {
                        var members = await _familyAdministrationRepository.GetFamilyUsers(familyEntity.FamilyGuid);

                        var exportModel = familyEntity.ToExportModel();
                        exportModel.Users = (from member in members
                                             select member.ToExportModel())
                                             .ToList();

                        exportModels.Add(exportModel);
                    }
                }

                return exportModels;

            }
            catch (Exception exception)
            {
                await LogRepository.AddMessage(new LogEntity
                {
                    Message = $"Could not load families from database",
                    ExMessage = exception.Message,
                    StackTrace = exception.StackTrace,
                    TimeStamp = DateTime.UtcNow,
                    Trigger = nameof(FamilyAdministrationService)
                });

                await Save(contextAccessor.HttpContext);

                return new List<FamilyExportModel>();
            }
        }

        public async Task<bool> RegisterFamily(FamilyImportModel importModel, IHttpContextAccessor contextAccessor)
        {
            try
            {
                var familyGuid = Guid.NewGuid();

                var result = await _familyAdministrationRepository.AddFamily(importModel.ToEntity(familyGuid));

                if (result)
                {
                    var userEntity = importModel.UserRegistrationModel.ToEntity();
                    userEntity.UserRolesJson = await _familyAdministrationRepository.GetAdminRoleJson();
                    userEntity.FamilyGuid = familyGuid;

                    var saveResult = await _familyAdministrationRepository.AddFamilyAdmin(userEntity);

                    if (saveResult)
                    {
                        await Save(contextAccessor.HttpContext);

                        return true;
                    }

                }

                return false;

            }
            catch (Exception exception)
            {
                await LogRepository.AddMessage(new LogEntity
                {
                    Message = $"Could not load families from database",
                    ExMessage = exception.Message,
                    StackTrace = exception.StackTrace,
                    TimeStamp = DateTime.UtcNow,
                    Trigger = nameof(FamilyAdministrationService)
                });

                await Save(contextAccessor.HttpContext);

                return false;
            }
        }
    }
}
