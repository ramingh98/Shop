using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.UserAgg.Enums;
using Common.Query;

namespace BookShop.Query.Users.DTOs
{
    public class UserDto : BaseDto
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AvatarName { get; set; }
        public bool IsActive { get; set; }
        public Gender Gender { get; set; }
        public List<UserRoleDto> Roles { get; set; }
    }
}