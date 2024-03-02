using Date.Models.Entities.User;
using Date.Models.Models.User.Export;
using Date.Models.Models.User.Import;
using Logic.Shared.Helpers;

namespace Logic.Shared.Extensions.User
{
    public static class UserExtensions
    {
        public static UserEntity ToEntity(this UserRegistrationImportModel model)
        {
            var salt = string.IsNullOrWhiteSpace(model.Salt) ?
                Guid.NewGuid().ToString() :
                model.Salt;


            return new UserEntity
            {
                Email = model.Email,
                Password = PasswordHelper.GetEncodedPassword(model.Password, salt),
                Salt = salt,
                IsActive = model.IsActive,
            };
        }

        public static UserExportModel ToExportModel(this UserEntity entity)
        {
            return new UserExportModel
            {
                UserId = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                IsActive = entity.IsActive,
                DateOfBirth = entity.DateOfBirth,
                UserRolesJson = entity.UserRolesJson,
                CreatedAt = entity.CreatedAt?? DateTime.MinValue,
                CreatedBy = entity.CreatedBy?? string.Empty
            };
        }
    }
}
