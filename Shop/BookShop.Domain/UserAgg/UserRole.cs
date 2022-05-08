using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;

namespace BookShop.Domain.UserAgg
{
    public class UserRole : BaseEntity
    {
        public UserRole(long roleId)
        {
            RoleId = roleId;
        }

        public long UserId { get; internal set; }
        public long RoleId { get; private set; }
    }
}
