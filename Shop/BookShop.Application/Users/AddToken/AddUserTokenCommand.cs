﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;

namespace BookShop.Application.Users.AddToken
{
    public class AddUserTokenCommand : IBaseCommand
    {
        public AddUserTokenCommand(long userId, string hashJwtToken, string hashRefreshToken, DateTime tokenExpireDate, DateTime refreshTokenExpireDate, string device)
        {
            UserId = userId;
            HashJwtToken = hashJwtToken;
            HashRefreshToken = hashRefreshToken;
            TokenExpireDate = tokenExpireDate;
            RefreshTokenExpireDate = refreshTokenExpireDate;
            Device = device;
        }
        public long UserId { get; }
        public string HashJwtToken { get; }
        public string HashRefreshToken { get; }
        public DateTime TokenExpireDate { get; }
        public DateTime RefreshTokenExpireDate { get; }
        public string Device { get; }
    }
}