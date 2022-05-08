using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.CommentAgg.Enums;
using Common.Application;

namespace BookShop.Application.Comments.ChangeStatus
{
    public record ChangeCommentStatusCommand(long Id, CommentStatus Status) : IBaseCommand;
}
