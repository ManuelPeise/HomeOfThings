﻿using Data.Interfaces.Interfaces.Clients;
using Data.Ressources;
using Database.HotContext;
using Date.Models.Entities.Family;
using Date.Models.Entities.Log;
using Date.Models.Models.Family;
using Logic.Shared;
using Logic.Shared.Extensions.Family;
using Logic.Shared.UnitsOfWork;
using Microsoft.AspNetCore.Http;

namespace Logic.Administration
{
    public class FamilyAdministrationService : ALogicBase, IDisposable
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailClient? _emailClient;
        private bool disposedValue;

        public FamilyAdministrationService(DatabaseContext context, IHttpContextAccessor httpContextAccessor, IEmailClient? emailClient) : base(context)
        {
            _databaseContext = context;
            _httpContextAccessor = httpContextAccessor;
            _emailClient = emailClient;
        }

        public async Task<FamilyExportModel?> GetFamilyByGuid(Guid familyGuid)
        {
            try
            {
                using (var familyUnitOfWork = new FamilyUnitOfWork(_databaseContext))
                {
                    var entity = await familyUnitOfWork.FamilyRepository.GetAsync(new QueryOption<FamilyEntity>
                    {
                        AsNoTracking = true,
                        WhereExpression = x => x.FamilyGuid == familyGuid
                    });

                    if(entity == null) 
                    {
                        return null;
                    }

                    return entity.ToExportModel();
                }
            }
            catch (Exception exception)
            {
                await LogRepository.AddMessage(new LogEntity
                {
                    Message = $"Cannot load familie from database [{familyGuid}]!",
                    ExMessage = exception.Message,
                    StackTrace = exception.StackTrace ?? string.Empty,
                    TimeStamp = DateTime.UtcNow,
                    Trigger = nameof(UserAdministrationService),
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = nameof(UserAdministrationService)
                });

                await Save(_httpContextAccessor.HttpContext);

                return null;
            }
        }

        public async Task<List<FamilyExportModel>> GetFamilies()
        {
            try
            {
                using (var familyUnitOfWork = new FamilyUnitOfWork(_databaseContext))
                {
                    var entities = await familyUnitOfWork.FamilyRepository.GetAllAsync(new QueryOption<FamilyEntity>
                    {
                        AsNoTracking = true,
                    });

                    if (entities == null || !entities.Any())
                    {
                        return new List<FamilyExportModel>();
                    }

                    return (from entity in entities
                            select entity.ToExportModel()).ToList();
                }
            }
            catch (Exception exception)
            {
                await LogRepository.AddMessage(new LogEntity
                {
                    Message = "Cannot load families from database!",
                    ExMessage = exception.Message,
                    StackTrace = exception.StackTrace ?? string.Empty,
                    TimeStamp = DateTime.UtcNow,
                    Trigger = nameof(UserAdministrationService),
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = nameof(UserAdministrationService)
                });

                await Save(_httpContextAccessor.HttpContext);

                return new List<FamilyExportModel>();
            }
        }

        public async Task<bool> RegisterNewFamily(FamilyImportModel importModel)
        {
            try
            {
                using (var userAdministration = new UserAdministrationService(_databaseContext, _httpContextAccessor, null))
                using (var familyUnitOfWork = new FamilyUnitOfWork(_databaseContext))
                {
                    var familyGuid = Guid.NewGuid();

                    var familyEntity = importModel.ToEntity(familyGuid);

                    familyUnitOfWork.FamilyRepository.Add(familyEntity);

                    importModel.UserRegistrationModel.FamilyId = familyGuid;

                    var password = Guid.NewGuid().ToString();

                    var success = await userAdministration.RegisterUser(importModel.UserRegistrationModel, password);

                    if(success)
                    {
                        await base.Save(_httpContextAccessor.HttpContext);

                        var body = await _emailClient.LoadMailHtmlFromRessources(RessourceNames.RegistrationMailBody);

                        body = body.Replace("email", importModel.UserRegistrationModel.Email).Replace("passwordValue", password);

                        var message = _emailClient.BuilMailMessage(importModel.UserRegistrationModel.Email, "Your account at MyApp", string.Empty, body);

                        await _emailClient.SendMail(message);
                    }

                    return success;
                }

            }
            catch (Exception exception)
            {
                await LogRepository.AddMessage(new LogEntity
                {
                    Message = "Cannot register new falily!",
                    ExMessage = exception.Message,
                    StackTrace = exception.StackTrace ?? string.Empty,
                    TimeStamp = DateTime.UtcNow,
                    Trigger = nameof(UserAdministrationService),
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = nameof(UserAdministrationService)
                });

                await Save(_httpContextAccessor.HttpContext);

                return false;
            }
        }

        public async Task<bool> UpdateFamily(FamilyImportModel importModel)
        {
            try
            {
                using (var userAdministration = new UserAdministrationService(_databaseContext, _httpContextAccessor, null))
                using (var familyUnitOfWork = new FamilyUnitOfWork(_databaseContext))
                {
                    var familyEntity = await familyUnitOfWork.FamilyRepository.GetAsync(new QueryOption<FamilyEntity>
                    {
                        AsNoTracking = true,
                        WhereExpression = x => x.FamilyId == importModel.FamilyId,
                    });

                    if (familyEntity == null)
                    {
                        return false;
                    }

                    familyEntity.IsActive = importModel.IsActive;

                    var userEntities = await userAdministration.GetFamilyUsers(familyEntity.FamilyGuid);

                    foreach (var userEntity in userEntities)
                    {
                        userEntity.IsActive = importModel.IsActive;

                        await userAdministration.UpdateUser(userEntity, false);
                    }

                    familyUnitOfWork.FamilyRepository.Update(familyEntity);

                    await Save(_httpContextAccessor.HttpContext);

                    return true;
                }


            }
            catch (Exception exception)
            {
                await LogRepository.AddMessage(new LogEntity
                {
                    Message = "Cannot update falily!",
                    ExMessage = exception.Message,
                    StackTrace = exception.StackTrace ?? string.Empty,
                    TimeStamp = DateTime.UtcNow,
                    Trigger = nameof(UserAdministrationService),
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = nameof(UserAdministrationService)
                });

                await Save(_httpContextAccessor.HttpContext);

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
                    _databaseContext.Dispose();
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
