using BookShop.Domain.RoleAgg.Enums;
using BookShop.Presentation.Facade.Roles;
using BookShop.Presentation.Facade.Users;
using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookShop.API.Infrastructures.Security
{
    public class CheckPermission : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        private IUserFacade _userFacade;
        private IRoleFacade _roleFacade;
        private readonly Permission _permission;

        public CheckPermission(Permission permission)
        {
            _permission = permission;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (HasAllowAnonymous(context))
            {
                return;
            }

            _userFacade = context.HttpContext.RequestServices.GetRequiredService<IUserFacade>();
            _roleFacade = context.HttpContext.RequestServices.GetRequiredService<IRoleFacade>();

            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                if (await HasPermission(context) == false)
                {
                    context.Result = new ForbidResult();
                }
            }
            else
            {
                context.Result = new UnauthorizedObjectResult("غیر مجاز");
            }
        }

        private bool HasAllowAnonymous(AuthorizationFilterContext context)
        {
            var metaData = context.ActionDescriptor.EndpointMetadata.OfType<dynamic>().ToList();
            bool hasAllowAnonymous = false;
            foreach (var item in metaData)
            {
                try
                {
                    hasAllowAnonymous = item.TypeId.Name == "AllowAnonymousAttribute";
                    if (hasAllowAnonymous)
                        break;
                }
                catch
                {

                }
            }

            return hasAllowAnonymous;
        }

        private async Task<bool> HasPermission(AuthorizationFilterContext context)
        {
            var user = await _userFacade.GetUserByIdAsync(context.HttpContext.User.GetUserId());
            if (user == null)
            {
                return false;
            }

            var roleIds = user.Roles.Select(q => q.RoleId).ToList();
            var roles = await _roleFacade.GetRolesAsync();
            var userRoles = roles.Where(q => roleIds.Contains(q.Id));

            return userRoles.Any(q => q.Permissions.Contains(_permission));
        }
    }
}