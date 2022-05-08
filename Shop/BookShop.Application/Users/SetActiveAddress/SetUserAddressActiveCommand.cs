using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;

namespace BookShop.Application.Users.SetActiveAddress
{
    public record SetUserAddressActiveCommand(long UserId, long AddressId) : IBaseCommand;
}