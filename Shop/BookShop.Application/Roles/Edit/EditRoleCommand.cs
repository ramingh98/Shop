using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.RoleAgg.Enums;
using Common.Application;

namespace BookShop.Application.Roles.Edit
{
    public record EditRoleCommand(long Id, string Title, List<Permission> Permissions) : IBaseCommand;
}
