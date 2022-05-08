using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Application.Users.AddAddress;
using BookShop.Application.Users.DeleteAddress;
using BookShop.Application.Users.EditAddress;
using BookShop.Application.Users.SetActiveAddress;
using BookShop.Query.Users.DTOs;
using Common.Application;

namespace BookShop.Presentation.Facade.Users.Addresses
{
    public interface IUserAddressFacade
    {
        Task<OperationResult> AddAddressAsync(AddUserAddressCommand command);
        Task<OperationResult> EditAddressAsync(EditUserAddressCommand command);
        Task<OperationResult> DeleteAddressAsync(DeleteUserAddressCommand command);
        Task<OperationResult> SetActiveAddressAsync(SetUserAddressActiveCommand command);
        Task<AddressDto?> GetAddressByIdAsync(long userAddressId);
        Task<List<AddressDto>> GetAddressesAsync(long userId);
    }
}