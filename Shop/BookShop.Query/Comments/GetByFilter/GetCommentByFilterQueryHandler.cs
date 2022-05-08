using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Infrastructure.Persistent.EF;
using BookShop.Query.Comments.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Query.Comments.GetByFilter
{
    internal class GetCommentByFilterQueryHandler : IQueryHandler<GetCommentByFilterQuery, CommentFilterResult>
    {
        private ApplicationDbContext _context;

        public GetCommentByFilterQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CommentFilterResult> Handle(GetCommentByFilterQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;
            var result = _context.Comments.OrderByDescending(q => q.CreationDate).AsQueryable();
            if (@params.CommentStatus != null)
            {
                result = result.Where(q => q.Status == @params.CommentStatus);
            }

            if (@params.UserId != null)
            {
                result = result.Where(q => q.UserId == @params.UserId);
            }

            if (@params.StartDate != null)
            {
                result = result.Where(q => q.CreationDate.Date >= @params.StartDate.Value.Date);
            }

            if (@params.EndDate != null)
            {
                result = result.Where(q => q.CreationDate.Date <= @params.EndDate.Value.Date);
            }

            var skip = (@params.PageId - 1) * @params.Take;
            var model = new CommentFilterResult()
            {
                Data = await result.Skip(skip).Take(@params.Take).Select(q => q.Map()).ToListAsync(cancellationToken),
                FilterParam = @params
            };
            model.GeneratePaging(result, @params.Take, @params.PageId);
            return model;
        }
    }
}
