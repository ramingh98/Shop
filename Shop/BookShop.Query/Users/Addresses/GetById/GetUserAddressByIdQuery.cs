using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Query.Users.DTOs;
using Common.Query;

namespace BookShop.Query.Users.Addresses.GetById
{
    public record GetUserAddressByIdQuery(long AddressId) : IQuery<AddressDto?>;
}