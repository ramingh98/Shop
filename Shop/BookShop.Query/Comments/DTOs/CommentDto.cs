using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.CommentAgg.Enums;
using Common.Query;

namespace BookShop.Query.Comments.DTOs
{
    public class CommentDto : BaseDto
    {
        public long ProductId { get; set; }
        public long UserId { get; set; }
        public string UserFullName { get; set; }
        public string ProductTitle { get; set; }
        public string Text { get; set; }
        public CommentStatus Status { get; set; }
    }
}