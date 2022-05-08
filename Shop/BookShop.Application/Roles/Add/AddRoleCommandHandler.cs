using System;
using System.Collections.Generic;
using BookShop.Domain.RoleAgg;
using BookShop.Domain.RoleAgg.Repositories;
using Common.Application;
using BookShop.Domain.RoleAgg;

namespace BookShop.Application.Roles.Add
{
    public class AddRoleCommandHandler : IBaseCommandHandler<AddRoleCommand>
    {
        private IRoleRepository _roleRepository;

        public AddRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<OperationResult> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var permissions = new List<RolePermission>();
            request.Permissions.ForEach(q =>
            {
                permissions.Add(new RolePermission(q));
            });
            var role = new Role(request.Title, permissions);
            _roleRepository.Add(role);
            await _roleRepository.Save();
            return OperationResult.Success();
        }
    }
}
