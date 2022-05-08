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
using Common.Application;

namespace BookShop.Presentation.Facade.Users
{
    public interface IUserFacade
    {
        Task<OperationResult> RegisterUserAsync(RegisterUserCommand command);
        Task<OperationResult> EditUserAsync(EditUserCommand command);
        Task<OperationResult> AddUserAsync(AddUserCommand command);
        Task<UserDto?> GetUserByPhoneNumberAsync(string phoneNumber);
        Task<OperationResult> AddTokenAsync(AddUserTokenCommand command);
        Task<OperationResult> DeleteTokenAsync(DeleteUserTokenCommand command);
        Task<UserDto?> GetUserByIdAsync(long userId);
        Task<OperationResult> ChangePasswordAsync(ChangeUserPasswordCommand command);
        Task<UserFilterResult> GetUserByFilterAsync(UserFilterParams param);
        Task<UserTokenDto?> GetUserTokenByRefreshTokenAsync(string refreshToken);
        Task<UserTokenDto?> GetUserTokenByJwtTokenAsync(string jwtToken);
    }
}