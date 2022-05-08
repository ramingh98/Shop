using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Infrastructure.Persistent.Dapper;
using BookShop.Query.Sellers.DTOs;
using Common.Query;
using Dapper;

namespace BookShop.Query.Sellers.Inventories.GetList
{
    internal class GetInventoryListQueryHandler : IQueryHandler<GetInventoryListQuery, List<InventoryDto>>
    {
        private readonly DapperContext _dapperContext;

        public GetInventoryListQueryHandler(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<List<InventoryDto>> Handle(GetInventoryListQuery request, CancellationToken cancellationToken)
        {
            using var connection = _dapperContext.CreateConnection();
            var sql = @$"SELECT i.Id, i.SellerId , i.ProductId ,i.Count , i.Price,i.CreationDate , i.DiscountPercentage , s.ShopName , p.Title as ProductTitle,p.ImageName as ProductImage FROM {_dapperContext.Inventories} i inner join {_dapperContext.Sellers} s on i.SellerId=s.Id inner join {_dapperContext.Products} p on i.ProductId=p.Id WHERE i.SellerId=@sellerId";
            var inventories = await connection.QueryAsync<InventoryDto>(sql, new { sellerId = request.SellerId });
            return inventories.ToList();
        }
    }
}