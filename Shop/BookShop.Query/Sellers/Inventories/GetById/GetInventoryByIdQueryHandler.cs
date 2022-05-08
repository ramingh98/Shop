using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Infrastructure.Persistent.Dapper;
using BookShop.Infrastructure.Persistent.EF;
using BookShop.Query.Sellers.DTOs;
using Common.Query;
using Dapper;

namespace BookShop.Query.Sellers.Inventories.GetById
{
    internal class GetInventoryByIdQueryHandler : IQueryHandler<GetInventoryByIdQuery, InventoryDto>
    {
        private readonly DapperContext _dapperContext;

        public GetInventoryByIdQueryHandler(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<InventoryDto> Handle(GetInventoryByIdQuery request, CancellationToken cancellationToken)
        {
            using var connection = _dapperContext.CreateConnection();
            var sql = @$"SELECT i.Id, i.SellerId, ProductId ,Count , Price,i.CreationDate , DiscountPercentage , s.ShopName,p.Title as ProductTitle,p.ImageName as ProductImage FROM {_dapperContext.Inventories} i inner join {_dapperContext.Sellers} s on i.SellerId=s.Id inner join {_dapperContext.Products} p on i.ProductId=p.Id WHERE i.Id=@id";
            var inventory = await connection.QueryFirstOrDefaultAsync<InventoryDto>(sql, new { id = request.InventoryId });
            if (inventory == null)
            {
                return null;
            }
            return inventory;
        }
    }
}