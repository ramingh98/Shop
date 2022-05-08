using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Query.Users.DTOs;
using Common.Query;

namespace BookShop.Query.Users.GetByFilter
{
    public class GetUserByFilterQuery : QueryFilter<UserFilterResult,UserFilterParams>
    {
        public GetUserByFilterQuery(UserFilterParams filterParams) : base(filterParams)
        {

        }
    }
}