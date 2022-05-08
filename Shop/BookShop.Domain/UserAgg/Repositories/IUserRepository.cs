using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.UserAgg;
using Common.Domain.Repository;

namespace BookShop.Domain.UserAgg.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
    }
}
