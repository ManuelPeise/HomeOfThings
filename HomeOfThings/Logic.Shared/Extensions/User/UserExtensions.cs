using Date.Models.Entities.User;
using Date.Models.Enums;
using Date.Models.Models.User.Export;
using Date.Models.Models.User.Import;
using Logic.Shared.Helpers;
using Newtonsoft.Json;

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
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = (DateTime)model.DateOfBirth,
                Email = model.Email,
                EmailConfirmed = false,
                Password = PasswordHelper.GetEncodedPassword("P@ssword", salt),
                Salt = salt,
                IsActive = model.IsActive,
            };
        }

        public static UserExportModel ToExportModel(this UserEntity entity)
        {
            var roles = new List<int>();

            try
            {
                if (entity.UserRolesJson.Length > 0)
                {
                    roles = JsonConvert.DeserializeObject<List<int>>(entity.UserRolesJson);
                }

            }catch (Exception)
            {
                roles = new List<int>();
            }

            return new UserExportModel
            {
                UserId = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                EmailConfirmed = entity.EmailConfirmed,
                IsActive = entity.IsActive,
                DateOfBirth = entity.DateOfBirth,
                UserRoles = roles.Select(x => (UserRoleEnum)Enum.Parse(typeof(UserRoleEnum), x.ToString())),
                CreatedAt = entity.CreatedAt?? DateTime.MinValue,
                CreatedBy = entity.CreatedBy?? string.Empty
            };
        }
    }
}
