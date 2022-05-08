using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Query.Comments.DTOs;
using Common.Query;

namespace BookShop.Query.Comments.GetByFilter
{
    public class GetCommentByFilterQuery : QueryFilter<CommentFilterResult, CommentFilterParam>
    {
        public GetCommentByFilterQuery(CommentFilterParam filterParams) : base(filterParams)
        {

        }
    }
}