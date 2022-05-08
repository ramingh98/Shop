using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.UserAgg;
using BookShop.Domain.UserAgg.Repositories;
using BookShop.Infrastructure._Utilities;

namespace BookShop.Infrastructure.Persistent.EF.UserAgg
{
    internal class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}