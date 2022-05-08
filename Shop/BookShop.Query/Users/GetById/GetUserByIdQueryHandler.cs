using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Infrastructure.Persistent.EF;
using BookShop.Query.Users.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Query.Users.GetById
{
    internal class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery,UserDto>
    {
        private readonly ApplicationDbContext _context;

        public GetUserByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(q => q.Id == request.UserId, cancellationToken);
            if (user == null)
            {
                return null;
            }

            return await user.Map().SetUserRoleTitles(_context);
        }
    }
}