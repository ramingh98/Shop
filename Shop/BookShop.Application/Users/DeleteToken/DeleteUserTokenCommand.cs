﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;

namespace BookShop.Application.Users.DeleteToken
{
    public record DeleteUserTokenCommand(long UserId, long TokenId) : IBaseCommand;
}