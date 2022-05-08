using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Infrastructure.Persistent.EF;
using BookShop.Query.Comments.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Query.Comments.GetById
{
    internal class GetCommentByIdQueryHandler : IQueryHandler<GetCommentByIdQuery, CommentDto>
    {
        private ApplicationDbContext _context;

        public GetCommentByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<CommentDto> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(q => q.Id == request.CommentId, cancellationToken);
            return comment.Map();
        }
    }
}