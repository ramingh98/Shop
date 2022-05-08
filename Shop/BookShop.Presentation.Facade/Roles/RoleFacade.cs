using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Application.Roles.Add;
using BookShop.Application.Roles.Edit;
using BookShop.Query.Roles.DTOs;
using BookShop.Query.Roles.GetById;
using BookShop.Query.Roles.GetList;
using Common.Application;
using MediatR;

namespace BookShop.Presentation.Facade.Roles
{
    internal class RoleFacade : IRoleFacade
    {
        private readonly IMediator _mediator;

        public RoleFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> AddRoleAsync(AddRoleCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> EditRoleAsync(EditRoleCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<RoleDto?> GetRoleByIdAsync(long roleId)
        {
            return await _mediator.Send(new GetRoleByIdQuery(roleId));
        }

        public async Task<List<RoleDto>> GetRolesAsync()
        {
            return await _mediator.Send(new GetRoleListQuery());
        }
    }
}