using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Infrastructure.Persistent.Dapper;
using BookShop.Query.Users.DTOs;
using Common.Query;
using Dapper;

namespace BookShop.Query.Users.Addresses.GetList
{
    internal class GetUserAddressesQueryHandler : IQueryHandler<GetUserAddressesQuery, List<AddressDto>>
    {
        private readonly DapperContext _dapperContext;

        public GetUserAddressesQueryHandler(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<List<AddressDto>> Handle(GetUserAddressesQuery request, CancellationToken cancellationToken)
        {
            var sql = $"Select * from {_dapperContext.UserAddresses} where UserId=@userId";
            using var context = _dapperContext.CreateConnection();
            var result = await context.QueryAsync<AddressDto>(sql, new { userId = request.UserId });
            return result.ToList();
        }
    }
}