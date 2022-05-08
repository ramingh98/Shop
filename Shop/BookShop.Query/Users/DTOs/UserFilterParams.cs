using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Query.Filter;

namespace BookShop.Query.Users.DTOs
{
    public class UserFilterParams : BaseFilterParam
    {
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public long? Id { get; set; }
    }
}