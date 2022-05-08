using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Application.Users.AddAddress;
using BookShop.Application.Users.DeleteAddress;
using BookShop.Application.Users.EditAddress;
using BookShop.Application.Users.SetActiveAddress;
using BookShop.Query.Users.Addresses.GetById;
using BookShop.Query.Users.Addresses.GetList;
using BookShop.Query.Users.DTOs;
using Common.Application;
using MediatR;

namespace BookShop.Presentation.Facade.Users.Addresses
{
    internal class UserAddressFacade : IUserAddressFacade
    {
        private readonly IMediator _mediator;

        public UserAddressFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> AddAddressAsync(AddUserAddressCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> EditAddressAsync(EditUserAddressCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> DeleteAddressAsync(DeleteUserAddressCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<AddressDto?> GetAddressByIdAsync(long userAddressId)
        {
            return await _mediator.Send(new GetUserAddressByIdQuery(userAddressId));
        }

        public async Task<List<AddressDto>> GetAddressesAsync(long userId)
        {
            return await _mediator.Send(new GetUserAddressesQuery(userId));
        }

        public async Task<OperationResult> SetActiveAddressAsync(SetUserAddressActiveCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}