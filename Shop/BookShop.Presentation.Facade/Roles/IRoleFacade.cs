using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Application.Roles.Add;
using BookShop.Application.Roles.Edit;
using BookShop.Query.Roles.DTOs;
using Common.Application;

namespace BookShop.Presentation.Facade.Roles
{
    public interface IRoleFacade
    {
        Task<OperationResult> AddRoleAsync(AddRoleCommand command);
        Task<OperationResult> EditRoleAsync(EditRoleCommand command);
        Task<RoleDto?> GetRoleByIdAsync(long roleId);
        Task<List<RoleDto>> GetRolesAsync();
    }
}