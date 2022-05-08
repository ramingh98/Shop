using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Infrastructure.Persistent.EF;
using BookShop.Query.Products.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace BookShop.Query.Products.GetById
{
    internal class GetProductsByIdQueryHandler : IQueryHandler<GetProductsByIdQuery,ProductDto>
    {
        private readonly ApplicationDbContext _context;

        public GetProductsByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductDto> Handle(GetProductsByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(q => q.Id == request.ProductId, cancellationToken);

            var model = product.Map();

            if (model == null)
                return null;

            await model.SetCategories(_context);

            return model;
        }
    }
}