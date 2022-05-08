using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Common.Domain.Exceptions;

namespace BookShop.Domain.UserAgg
{
    public class UserToken : BaseEntity
    {
        private UserToken()
        {

        }

        public UserToken(string hashJwtToken, string hashRefreshToken, DateTime jwtTokenExpireDate, DateTime refreshTokenExpireDate, string device)
        {
            HashJwtToken = hashJwtToken;
            HashRefreshToken = hashRefreshToken;
            JwtTokenExpireDate = jwtTokenExpireDate;
            RefreshTokenExpireDate = refreshTokenExpireDate;
            Device = device;
            Guard();
        }
        public long UserId { get; internal set; }
        public string HashJwtToken { get; private set; }
        public string HashRefreshToken { get; private set; }
        public DateTime JwtTokenExpireDate { get; private set; }
        public DateTime RefreshTokenExpireDate { get; private set; }
        public string Device { get; private set; }

        public void Guard()
        {
            NullOrEmptyDomainDataException.CheckString(HashJwtToken,nameof(HashJwtToken));
            NullOrEmptyDomainDataException.CheckString(HashRefreshToken, nameof(HashRefreshToken));

            if (JwtTokenExpireDate < DateTime.Now)
            {
                throw new InvalidDomainDataException("تاریخ انقضا نامعتبر است");
            }

            if (RefreshTokenExpireDate < JwtTokenExpireDate)
            {
                throw new InvalidDomainDataException("تاریخ انقضا نامعتبر است");
            }
        }
    }
}