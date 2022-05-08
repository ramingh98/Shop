using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.CommentAgg;
using BookShop.Domain.CommentAgg.Repositories;
using BookShop.Infrastructure._Utilities;

namespace BookShop.Infrastructure.Persistent.EF.CommentAgg
{
    internal class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}