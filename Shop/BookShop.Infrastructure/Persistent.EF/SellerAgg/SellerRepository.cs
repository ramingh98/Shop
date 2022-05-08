using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.SellerAgg;
using BookShop.Domain.SellerAgg.Repositories;
using BookShop.Infrastructure._Utilities;
using BookShop.Infrastructure.Persistent.Dapper;
using Dapper;

namespace BookShop.Infrastructure.Persistent.EF.SellerAgg
{
    internal class SellerRepository : BaseRepository<Seller>, ISellerRepository
    {
        private readonly DapperContext _dapperContext;
        public SellerRepository(ApplicationDbContext context, DapperContext dapperContext) : base(context)
        {
            _dapperContext = dapperContext;
        }

        public async Task<InventoryResult> GetInventoryById(long id)
        {
            using var connection = _dapperContext.CreateConnection();
            var query = $"select * from {_dapperContext.Inventories} where Id = @InventoryId";
            return await connection.QueryFirstOrDefaultAsync<InventoryResult>(query, new { InventoryId = id });
        }
    }
}