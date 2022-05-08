using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.RoleAgg.Enums;
using Common.Domain;

namespace BookShop.Domain.RoleAgg
{
    public class RolePermission : BaseEntity
    {
        public RolePermission(Permission permission)
        {
            Permission = permission;
        }
        public long RoleId { get; set; }
        public Permission Permission { get; set; }
    }
}
