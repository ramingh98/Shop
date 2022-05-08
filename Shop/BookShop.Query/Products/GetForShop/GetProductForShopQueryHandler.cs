using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.SellerAgg.Enums;
using BookShop.Infrastructure.Persistent.Dapper;
using BookShop.Infrastructure.Persistent.EF;
using BookShop.Query.Categories;
using BookShop.Query.Categories.DTOs;
using BookShop.Query.Products.DTOs;
using BookShop.Query.Products.Enums;
using Common.Query;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Query.Products.GetForShop
{
    internal class GetProductForShopQueryHandler : IQueryHandler<GetProductForShopQuery, ProductShopResult>
    {
        private ApplicationDbContext _context;
        private DapperContext _dapperContext;

        public GetProductForShopQueryHandler(ApplicationDbContext context, DapperContext dapperContext)
        {
            _context = context;
            _dapperContext = dapperContext;
        }
        public async Task<ProductShopResult> Handle(GetProductForShopQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;
            string conditions = "";
            string orderBy = "";
            string inventoryOrderBy = "i.Price Asc";
            CategoryDto? selectedCategory = null;
            if (!string.IsNullOrWhiteSpace(@params.CategorySlug))
            {
                var category = await _context.Categories.FirstOrDefaultAsync(f => f.Slug == @params.CategorySlug, cancellationToken);

                if (category != null)
                {
                    conditions += @$" and (A.CategoryId={category.Id} or A.SubCategoryId={category.Id}
                              or A.SecondarySubCategoryId={category.Id})";
                    selectedCategory = category.Map();
                }
            }

            if (!string.IsNullOrWhiteSpace(@params.Search))
            {
                conditions += $" and A.Title Like N'%{@params.Search}%'";
            }

            if (@params.OnlyAvailableProducts)
            {
                conditions += " and A.Count>=1";
            }

            if (@params.JustHasDiscount)
            {
                conditions += " and A.DiscountPercentage>0";
                inventoryOrderBy = "i.DiscountPercentage Desc";
            }
            switch (@params.SearchOrderBy)
            {
                case ProductSearchOrderBy.Cheapest:
                    {
                        orderBy = "A.Price Asc";
                        break;
                    }
                case ProductSearchOrderBy.Expensive:
                    {
                        orderBy = "A.Price Desc";
                        break;
                    }
                case ProductSearchOrderBy.Latest:
                    {
                        orderBy = "A.Id Desc";
                        break;
                    }
                default:
                    orderBy = "p.Id";
                    break;
            }
            using var sqlConnection = _dapperContext.CreateConnection();

            var skip = (@params.PageId - 1) * @params.Take;
            var sql = @$"SELECT Count(A.Title)
            FROM (Select p.Title , i.Price  , i.Id as InventoryId , i.DiscountPercentage , i.Count,
            p.CategoryId,p.SubCategoryId,p.SecondarySubCategoryId, p.Id as Id , s.Status,
            ROW_NUMBER() OVER(PARTITION BY p.Id ORDER BY {inventoryOrderBy} ) AS RN
            From {_dapperContext.Products} p
            left join {_dapperContext.Inventories} i on p.Id=i.ProductId
            left join {_dapperContext.Sellers} s on i.SellerId=s.Id)A
            WHERE  A.RN = 1 and A.Status=@status  {conditions}";


            var resultSql = @$"SELECT A.Slug,A.Id ,A.Title,A.Price,A.InventoryId,A.DiscountPercentage,A.ImageName
            FROM (Select p.Title , i.Price  , i.Id as InventoryId , i.DiscountPercentage,p.ImageName , i.Count,
            p.CategoryId,p.SubCategoryId,p.SecondarySubCategoryId, p.Slug , p.Id as Id , s.Status ,
            ROW_NUMBER() OVER(PARTITION BY p.Id ORDER BY {inventoryOrderBy}) AS RN
            From {_dapperContext.Products} p
            left join {_dapperContext.Inventories} i on p.Id=i.ProductId
            left join {_dapperContext.Sellers} s on i.SellerId=s.Id)A
            WHERE  A.RN = 1 and A.Status=@status  {conditions} order By {orderBy} offset @skip ROWS FETCH NEXT @take ROWS ONLY";

            var count = await sqlConnection.QueryFirstAsync<int>(sql, new { status = SellerStatus.Accepted });
            var result = await sqlConnection.QueryAsync<ProductShopDto>(resultSql,
                new { skip, take = @params.Take, status = SellerStatus.Accepted });
            var model = new ProductShopResult()
            {
                FilterParam = @params,
                Data = result.ToList(),
                CategoryDto = selectedCategory
            };
            model.GeneratePaging(@params.Take, @params.PageId, count);
            return model;
        }
    }
}