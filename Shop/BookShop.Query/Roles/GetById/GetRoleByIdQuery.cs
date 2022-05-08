using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Query.Roles.DTOs;
using Common.Query;

namespace BookShop.Query.Roles.GetById
{
    public record GetRoleByIdQuery(long RoleId) : IQuery<RoleDto>;
}