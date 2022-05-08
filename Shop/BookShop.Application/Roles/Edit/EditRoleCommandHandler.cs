using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.RoleAgg;
using BookShop.Domain.RoleAgg.Repositories;
using Common.Application;

namespace BookShop.Application.Roles.Edit
{
    public class EditRoleCommandHandler : IBaseCommandHandler<EditRoleCommand>
    {
        private IRoleRepository _roleRepository;

        public EditRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<OperationResult> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetTracking(request.Id);
            if (role == null)
            {
                return OperationResult.NotFound();
            }
            role.Edit(request.Title);
            var permissions = new List<RolePermission>();
            request.Permissions.ForEach(q =>
            {
                permissions.Add(new RolePermission(q));
            });
            role.SetPermission(permissions);
            await _roleRepository.Save();
            return OperationResult.Success();
        }
    }
}
