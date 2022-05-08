using BookShop.API.Infrastructures.Security;
using BookShop.Application.Roles.Add;
using BookShop.Application.Roles.Edit;
using BookShop.Domain.RoleAgg.Enums;
using BookShop.Presentation.Facade.Roles;
using BookShop.Query.Roles.DTOs;
using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.API.Controllers
{
    [CheckPermission(Permission.RoleManagement)]
    public class RoleController : ApiController
    {
        private readonly IRoleFacade _roleFacade;

        public RoleController(IRoleFacade roleFacade)
        {
            _roleFacade = roleFacade;
        }

        [HttpGet]
        public async Task<ApiResult<List<RoleDto>>> GetRoles()
        {
            var result = await _roleFacade.GetRolesAsync();
            return QueryResult(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<RoleDto?>> GetRoleById(long id)
        {
            var result = await _roleFacade.GetRoleByIdAsync(id);
            return QueryResult(result);
        }

        [HttpPost]
        public async Task<ApiResult> AddRole(AddRoleCommand command)
        {
            var result = await _roleFacade.AddRoleAsync(command);
            return CommandResult(result);
        }

        [HttpPut]
        public async Task<ApiResult> EditRole(EditRoleCommand command)
        {
            var result = await _roleFacade.EditRoleAsync(command);
            return CommandResult(result);
        }
    }
}