using AutoMapper;
using BookShop.API.Models.ViewModels.Users;
using BookShop.Application.Users.AddAddress;
using BookShop.Application.Users.DeleteAddress;
using BookShop.Application.Users.EditAddress;
using BookShop.Application.Users.SetActiveAddress;
using BookShop.Presentation.Facade.Users.Addresses;
using BookShop.Query.Users.DTOs;
using Common.AspNetCore;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.API.Controllers
{
    [Authorize]
    public class UserAddressController : ApiController
    {
        private readonly IUserAddressFacade _addressFacade;
        private readonly IMapper _mapper;

        public UserAddressController(IUserAddressFacade addressFacade, IMapper mapper)
        {
            _addressFacade = addressFacade;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ApiResult<List<AddressDto>>> GetAddresses()
        {
            var result = await _addressFacade.GetAddressesAsync(User.GetUserId());
            return QueryResult(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<AddressDto>> GetAddressById(long id)
        {
            var result = await _addressFacade.GetAddressByIdAsync(id);
            return QueryResult(result);
        }

        [HttpPost]
        public async Task<ApiResult> AddAddress(AddUserAddressViewModel model)
        {
            var command = new AddUserAddressCommand(User.GetUserId(), model.Shire, model.City, model.PostalCode,
                model.PostalAddress, new PhoneNumber(model.PhoneNumber), model.Name, model.Family, model.NationalCode);
            var result = await _addressFacade.AddAddressAsync(command);
            return CommandResult(result);
        }

        [HttpPut]
        public async Task<ApiResult> EditAddress(EditUserAddressViewModel model)
        {
            var command = new EditUserAddressCommand(model.Shire, model.City, model.PostalCode, model.PostalAddress,
                new PhoneNumber(model.PhoneNumber), model.Name, model.Family, model.NationalCode, User.GetUserId(), model.Id);
            var result = await _addressFacade.EditAddressAsync(command);
            return CommandResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<ApiResult> DeleteAddress(long id)
        {
            var result = await _addressFacade.DeleteAddressAsync(new DeleteUserAddressCommand(User.GetUserId(), id));
            return CommandResult(result);
        }

        [HttpPut("setActiveAddress/{addressId}")]
        public async Task<ApiResult> SetAddressActive(long addressId)
        {
            var result = await _addressFacade.SetActiveAddressAsync(new SetUserAddressActiveCommand(User.GetUserId(), addressId));
            return CommandResult(result);
        }
    }
}