using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.CommentAgg;
using Common.Domain.Repository;

namespace BookShop.Domain.CommentAgg.Repositories
{
    public interface ICommentRepository : IBaseRepository<Comment>
    {

    }
}
