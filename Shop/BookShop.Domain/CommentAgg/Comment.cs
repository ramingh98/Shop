using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.CommentAgg.Enums;
using Common.Domain;
using Common.Domain.Exceptions;

namespace BookShop.Domain.CommentAgg
{
    public class Comment : AggregateRoot
    {
        public Comment(long userId, long productId, string text)
        {
            UserId = userId;
            ProductId = productId;
            Text = text;
            Status = CommentStatus.Pending;
        }

        public long UserId { get; private set; }
        public long ProductId { get; private set; }
        public string Text { get; private set; }
        public CommentStatus Status { get; private set; }
        public DateTime UpdateDate { get; private set; }

        public void Edit(string text)
        {
            NullOrEmptyDomainDataException.CheckString(text, nameof(text));
            Text = text;
            UpdateDate = DateTime.Now;
        }

        public void ChangeStatus(CommentStatus status)
        {
            Status = status;
            UpdateDate = DateTime.Now;
        }
    }
}