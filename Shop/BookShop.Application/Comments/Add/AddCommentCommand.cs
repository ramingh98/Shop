using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;

namespace BookShop.Application.Comments.Add
{
    public record AddCommentCommand(string Text, long UserId, long ProductId) : IBaseCommand;
}
