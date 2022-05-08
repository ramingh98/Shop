using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Infrastructure.Persistent.EF;
using BookShop.Query.Products.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Query.Products.GetByFilter
{
    internal class GetProductsByFilterQueryHandler : IQueryHandler<GetProductsByFilterQuery, ProductFilterResult>
    {
        private readonly ApplicationDbContext _context;

        public GetProductsByFilterQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductFilterResult> Handle(GetProductsByFilterQuery request, CancellationToken cancellationToken)
        {
            var @param = request.FilterParams;
            var result = _context.Products.OrderByDescending(q => q.Id).AsQueryable();

            if (!string.IsNullOrWhiteSpace(@param.Slug))
                result = result.Where(r => r.Slug == @param.Slug);

            if (!string.IsNullOrWhiteSpace(@param.Title))
                result = result.Where(r => r.Title.Contains(@param.Title));

            if (@param.Id != null)
                result = result.Where(r => r.Id == @param.Id);

            var skip = (@param.PageId - 1) * @param.Take;

            var model = new ProductFilterResult()
            {
                Data = await result.Skip(skip).Take(@param.Take).Select(q => q.MapListData()).ToListAsync(cancellationToken),
                FilterParam = @param
            };

            model.GeneratePaging(result, @param.Take, @param.PageId);
            return model;
        }
    }
}