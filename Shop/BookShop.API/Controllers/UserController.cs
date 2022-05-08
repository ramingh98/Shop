using AutoMapper;
using BookShop.API.Infrastructures.Security;
using BookShop.API.Models.ViewModels.Users;
using BookShop.Application.Users.Add;
using BookShop.Application.Users.ChangePassword;
using BookShop.Application.Users.Edit;
using BookShop.Domain.RoleAgg.Enums;
using BookShop.Presentation.Facade.Users;
using BookShop.Presentation.Facade.Users.Addresses;
using BookShop.Query.Users.DTOs;
using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.API.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        private readonly IUserFacade _userFacade;
        private readonly IMapper _mapper;

        public UserController(IUserFacade userFacade, IMapper mapper)
        {
            _userFacade = userFacade;
            _mapper = mapper;
        }

        [CheckPermission(Permission.UserManagement)]
        [HttpGet]
        public async Task<ApiResult<UserFilterResult>> GetUsers([FromQuery] UserFilterParams param)
        {
            var result = await _userFacade.GetUserByFilterAsync(param);
            return QueryResult(result);
        }

        [HttpGet("current")]
        public async Task<ApiResult<UserDto>> GetCurrentUser()
        {
            var result = await _userFacade.GetUserByIdAsync(User.GetUserId());
            return QueryResult(result);
        }

        [CheckPermission(Permission.UserManagement)]
        [HttpGet("{userId}")]
        public async Task<ApiResult<UserDto?>> GetById(long userId)
        {
            var result = await _userFacade.GetUserByIdAsync(userId);
            return QueryResult(result);
        }

        [HttpPost]
        public async Task<ApiResult> Create(AddUserCommand command)
        {
            var result = await _userFacade.AddUserAsync(command);
            return CommandResult(result);
        }

        [HttpPut("changePassword")]
        public async Task<ApiResult> ChangePassword(ChangePasswordViewModel model)
        {
            var changePasswordModel = _mapper.Map<ChangeUserPasswordCommand>(model);
            changePasswordModel.UserId = User.GetUserId();
            var result = await _userFacade.ChangePasswordAsync(changePasswordModel);
            return CommandResult(result);
        }

        [HttpPut("current")]
        public async Task<ApiResult> EditUser([FromForm] EditUserViewModel model)
        {
            var command = new EditUserCommand(User.GetUserId(), model.Avatar, model.Name, model.Family, model.PhoneNumber, model.Email, model.Gender);
            var result = await _userFacade.EditUserAsync(command);
            return CommandResult(result);
        }

        [CheckPermission(Permission.UserManagement)]
        [HttpPut]
        public async Task<ApiResult> Edit([FromForm] EditUserCommand command)
        {
            var result = await _userFacade.EditUserAsync(command);
            return CommandResult(result);
        }
    }
}