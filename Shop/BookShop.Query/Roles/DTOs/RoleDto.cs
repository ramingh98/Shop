using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.RoleAgg.Enums;
using Common.Query;

namespace BookShop.Query.Roles.DTOs
{
    public class RoleDto : BaseDto
    {
        public string Title { get; set; }
        public List<Permission> Permissions { get; set; }
    }
}