using System;
using System.Collections.Generic;
using BookShop.Domain.UserAgg.Enums;
using Common.Query;
using Common.Query.Filter;

namespace BookShop.Query.Users.DTOs
{
    public class UserFilterData : BaseDto
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string AvatarName { get; set; }
        public Gender Gender { get; set; }
    }
}