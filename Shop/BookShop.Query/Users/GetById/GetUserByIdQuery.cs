using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Query.Users.DTOs;
using Common.Query;

namespace BookShop.Query.Users.GetById
{
    public class GetUserByIdQuery : IQuery<UserDto>
    {
        public GetUserByIdQuery(long userId)
        {
            UserId = userId;
        }
        public long UserId { get; private set; }
    }
}