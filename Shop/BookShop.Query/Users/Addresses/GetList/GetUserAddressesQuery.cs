using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Query.Users.DTOs;
using Common.Query;

namespace BookShop.Query.Users.Addresses.GetList
{
    public record GetUserAddressesQuery(long UserId) : IQuery<List<AddressDto>>;
}