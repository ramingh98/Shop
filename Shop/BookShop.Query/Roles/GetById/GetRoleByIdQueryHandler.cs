using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Infrastructure.Persistent.EF;
using BookShop.Query.Roles.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Query.Roles.GetById
{
    internal class GetRoleByIdQueryHandler : IQueryHandler<GetRoleByIdQuery, RoleDto>
    {
        private ApplicationDbContext _context;

        public GetRoleByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RoleDto> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(q => q.Id == request.RoleId, cancellationToken);

            if (role == null)
            {
                return null;
            }

            return new RoleDto()
            {
                Id = role.Id,
                CreationDate = role.CreationDate,
                Permissions = role.Permissions.Select(s => s.Permission).ToList(),
                Title = role.Title
            };
        }
    }
}