using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.CommentAgg;
using BookShop.Query.Comments.DTOs;

namespace BookShop.Query.Comments
{
    internal static class CommentMapper
    {
        public static CommentDto? Map(this Comment? comment)
        {
            if (comment == null)
            {
                return null;
            }

            return new CommentDto()
            {
                Id = comment.Id,
                Status = comment.Status,
                CreationDate = comment.CreationDate,
                UserId = comment.UserId,
                Text = comment.Text,
                ProductId = comment.ProductId
            };
        }

        public static CommentDto MpFilterComment(this Comment comment)
        {
            if (comment == null)
            {
                return null;
            }

            return new CommentDto()
            {

                Id = comment.Id,
                CreationDate = comment.CreationDate,
                Status = comment.Status,
                UserId = comment.UserId,
                ProductId = comment.ProductId,
                Text = comment.Text
            };
        }
    }
}