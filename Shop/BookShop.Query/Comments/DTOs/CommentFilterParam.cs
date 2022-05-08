using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.CommentAgg.Enums;
using Common.Query.Filter;

namespace BookShop.Query.Comments.DTOs
{
    public class CommentFilterParam : BaseFilterParam
    {
        public long? UserId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public CommentStatus? CommentStatus { get; set; }
    }
}