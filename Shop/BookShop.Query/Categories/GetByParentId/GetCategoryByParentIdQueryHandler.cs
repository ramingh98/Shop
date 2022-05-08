using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Infrastructure.Persistent.EF;
using BookShop.Query.Categories.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Query.Categories.GetByParentId
{
    public class GetCategoryByParentIdQueryHandler : IQueryHandler<GetCategoryByParentIdQuery,List<ChildCategoryDto>>
    {
        private readonly ApplicationDbContext _context;

        public GetCategoryByParentIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<ChildCategoryDto>> Handle(GetCategoryByParentIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Categories.Where(q=>q.ParentId == request.ParentId).ToListAsync(cancellationToken: cancellationToken);
            return result.MapChildren();
        }
    }
}