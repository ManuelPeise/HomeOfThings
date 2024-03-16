using Date.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;



namespace Service.Shared
{
    public class ApiAuthorization : Attribute, IAuthorizationFilter
    {
        private readonly UserRoleEnum? _requiredUserRole;
        public ApiAuthorization(UserRoleEnum requiredRole)
        {
            _requiredUserRole = requiredRole;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var receivedRole = (string)context.HttpContext.Items["UserRole"];

            if (string.IsNullOrWhiteSpace(receivedRole))
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                return;
            }

            var parsedRoleValue = (UserRoleEnum)Enum.Parse(typeof(UserRoleEnum), receivedRole);

            if (parsedRoleValue != _requiredUserRole)
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}

