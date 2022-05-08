using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Query.Comments.DTOs;
using Common.Query;

namespace BookShop.Query.Comments.GetById
{
    public record GetCommentByIdQuery(long CommentId) : IQuery<CommentDto>;
}