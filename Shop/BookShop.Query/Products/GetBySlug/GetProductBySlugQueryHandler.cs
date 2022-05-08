using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Infrastructure.Persistent.EF;
using BookShop.Query.Products.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Query.Products.GetBySlug
{
    internal class GetProductBySlugQueryHandler : IQueryHandler<GetProductBySlugQuery, ProductDto?>
    {
        private readonly ApplicationDbContext _context;

        public GetProductBySlugQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductDto?> Handle(GetProductBySlugQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(q => q.Slug == request.Slug, cancellationToken);

            var model = product.Map();

            if (model == null)
                return null;

            await model.SetCategories(_context);
            return model;
        }
    }
}