using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Application.Users.Add;
using BookShop.Application.Users.AddToken;
using BookShop.Application.Users.ChangePassword;
using BookShop.Application.Users.DeleteToken;
using BookShop.Application.Users.Edit;
using BookShop.Application.Users.Register;
using BookShop.Query.Users.DTOs;
using BookShop.Query.Users.GetByFilter;
using BookShop.Query.Users.GetById;
using BookShop.Query.Users.GetByPhoneNumber;
using BookShop.Query.Users.UserToken.GetByJwt;
using BookShop.Query.Users.UserToken.GetByRefresh;
using Common.Application;
using Common.Application.SecurityUtil;
using MediatR;

namespace BookShop.Presentation.Facade.Users
{
    internal class UserFacade : IUserFacade
    {
        private readonly IMediator _mediator;

        public UserFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> RegisterUserAsync(RegisterUserCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> EditUserAsync(EditUserCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> AddUserAsync(AddUserCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<UserDto?> GetUserByPhoneNumberAsync(string phoneNumber)
        {
            return await _mediator.Send(new GetUserByPhoneNumber(phoneNumber));
        }

        public async Task<OperationResult> AddTokenAsync(AddUserTokenCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> DeleteTokenAsync(DeleteUserTokenCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<UserDto?> GetUserByIdAsync(long userId)
        {
            return await _mediator.Send(new GetUserByIdQuery(userId));
        }

        public async Task<OperationResult> ChangePasswordAsync(ChangeUserPasswordCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<UserFilterResult> GetUserByFilterAsync(UserFilterParams param)
        {
            return await _mediator.Send(new GetUserByFilterQuery(param));
        }

        public async Task<UserTokenDto?> GetUserTokenByRefreshTokenAsync(string refreshToken)
        {
            var hashRefreshToken = Sha256Hasher.Hash(refreshToken);
            return await _mediator.Send(new GetUserTokenByRefreshTokenQuery(hashRefreshToken));
        }

        public async Task<UserTokenDto?> GetUserTokenByJwtTokenAsync(string jwtToken)
        {
            var hashJwtToken = Sha256Hasher.Hash(jwtToken);
            return await _mediator.Send(new GetUserTokenByJwtTokenQuery(hashJwtToken));
        }
    }
}