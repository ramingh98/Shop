using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Infrastructure.Persistent.EF;
using BookShop.Query.Users.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Query.Users.GetByPhoneNumber
{
    internal class GetUserByPhoneNumberHandler : IQueryHandler<GetUserByPhoneNumber, UserDto>
    {
        private readonly ApplicationDbContext _context;

        public GetUserByPhoneNumberHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserDto> Handle(GetUserByPhoneNumber request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(q => q.PhoneNumber == request.PhoneNumber, cancellationToken);
            if (user == null)
            {
                return null;
            }

            return await user.Map().SetUserRoleTitles(_context);
        }
    }
}