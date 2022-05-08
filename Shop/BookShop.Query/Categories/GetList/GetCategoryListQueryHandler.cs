using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Infrastructure.Persistent.EF;
using BookShop.Query.Categories.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Query.Categories.GetList
{
    public class GetCategoryListQueryHandler : IQueryHandler<GetCategoryListQuery, List<CategoryDto>>
    {
        private readonly ApplicationDbContext _context;

        public GetCategoryListQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryDto>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Categories.OrderBy(q => q.CreationDate).ToListAsync(cancellationToken);
            return result.Map();
        }
    }
}