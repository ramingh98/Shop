using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Infrastructure.Persistent.Dapper;
using BookShop.Query.Users.DTOs;
using Common.Query;
using Dapper;

namespace BookShop.Query.Users.UserToken.GetByJwt
{
    internal class GetUserTokenByJwtTokenQueryHandler : IQueryHandler<GetUserTokenByJwtTokenQuery, UserTokenDto>
    {
        private readonly DapperContext _dapperContext;

        public GetUserTokenByJwtTokenQueryHandler(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<UserTokenDto> Handle(GetUserTokenByJwtTokenQuery request, CancellationToken cancellationToken)
        {
            using var connection = _dapperContext.CreateConnection();
            var sql = $"SELECT TOP(1) * FROM {_dapperContext.UserTokens} Where HashJwtToken=@hashJwtToken";
            return await connection.QueryFirstOrDefaultAsync<UserTokenDto>(sql, new { hashJwtToken = request.HashJwtToken });
        }
    }
}