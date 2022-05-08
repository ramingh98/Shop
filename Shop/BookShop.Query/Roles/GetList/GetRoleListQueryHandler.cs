using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Infrastructure.Persistent.EF;
using BookShop.Query.Roles.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Query.Roles.GetList
{
    internal class GetRoleListQueryHandler : IQueryHandler<GetRoleListQuery, List<RoleDto>>
    {
        private ApplicationDbContext _context;

        public GetRoleListQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<RoleDto>> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Roles.Select(q => new RoleDto()
            {
                Id = q.Id,
                CreationDate = q.CreationDate,
                Permissions = q.Permissions.Select(s => s.Permission).ToList(),
                Title = q.Title
            }).ToListAsync(cancellationToken);
        }
    }
}