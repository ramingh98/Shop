using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;

namespace BookShop.Application.Users.DeleteAddress
{
    public record DeleteUserAddressCommand(long UserId, long AddressId) : IBaseCommand;
}
