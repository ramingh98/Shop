using BookShop.API.Infrastructures.JwtUtil;
using BookShop.API.Models.ViewModels.Authentication;
using BookShop.Application.Users.AddToken;
using BookShop.Application.Users.DeleteToken;
using BookShop.Application.Users.Register;
using BookShop.Presentation.Facade.Users;
using BookShop.Query.Users.DTOs;
using Common.Application;
using Common.Application.SecurityUtil;
using Common.AspNetCore;
using Common.AspNetCore.Enums;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UAParser;

namespace BookShop.API.Controllers
{
    public class AuthenticationController : ApiController
    {
        private readonly IUserFacade _userFacade;
        private readonly IConfiguration _configuration;

        public AuthenticationController(IUserFacade userFacade, IConfiguration configuration)
        {
            _userFacade = userFacade;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<ApiResult<LoginResultViewModel?>> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return new ApiResult<LoginResultViewModel?>()
                {
                    Data = null,
                    IsSuccess = false,
                    MetaData = new()
                    {
                        AppStatusCode = Common.AspNetCore.Enums.StatusCode.BadRequest,
                        Message = ""
                    }
                };
            }

            var user = await _userFacade.GetUserByPhoneNumberAsync(model.PhoneNumber);
            if (user == null)
            {
                var result = OperationResult<LoginResultViewModel?>.Error("کاربری با این مشخصات یافت نشد");
                return CommandResult(result);
            }

            if (Sha256Hasher.IsCompare(user.Password, model.Password) == false)
            {
                var result = OperationResult<LoginResultViewModel?>.Error("کاربری با این مشخصات یافت نشد");
                return CommandResult(result);
            }

            if (!user.IsActive)
            {
                var result = OperationResult<LoginResultViewModel?>.Error("حساب کاربری شما غیرفعال است");
                return CommandResult(result);
            }

            var loginResult = await AddTokenAndGenerateJwt(user);
            return CommandResult(loginResult);
        }

        [HttpPost("register")]
        public async Task<ApiResult> Register(RegisterViewModel model)
        {
            var command = new RegisterUserCommand(new PhoneNumber(model.PhoneNumber), model.Password);
            var result = await _userFacade.RegisterUserAsync(command);
            return CommandResult(result);
        }

        [HttpPost("RefreshToken")]
        public async Task<ApiResult<LoginResultViewModel?>> RefreshToken(string refreshToken)
        {
            var token = await _userFacade.GetUserTokenByRefreshTokenAsync(refreshToken);
            if (token == null)
            {
                return CommandResult(OperationResult<LoginResultViewModel?>.NotFound());
            }

            if (token.TokenExpireDate > DateTime.Now)
            {
                return CommandResult(OperationResult<LoginResultViewModel?>.Error("Token منقضی نشده"));
            }

            if (token.RefreshTokenExpireDate < DateTime.Now)
            {
                return CommandResult(OperationResult<LoginResultViewModel?>.Error("Refresh token منقضی شده"));
            }

            var user = await _userFacade.GetUserByIdAsync(token.UserId);
            await _userFacade.DeleteTokenAsync(new DeleteUserTokenCommand(token.UserId, token.Id));
            var result = await AddTokenAndGenerateJwt(user);
            return CommandResult(result);
        }

        [Authorize]
        [HttpDelete("logout")]
        public async Task<ApiResult> Logout()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var result = await _userFacade.GetUserTokenByJwtTokenAsync(token);
            if (result == null)
            {
                return CommandResult(OperationResult.NotFound());
            }

            await _userFacade.DeleteTokenAsync(new DeleteUserTokenCommand(result.UserId, result.Id));
            return CommandResult(OperationResult.Success());
        }

        private async Task<OperationResult<LoginResultViewModel?>> AddTokenAndGenerateJwt(UserDto user)
        {
            var uaParser = Parser.GetDefault();
            var header = HttpContext.Request.Headers["user-agent"].ToString();
            var device = "windows";
            if (header != null)
            {
                var info = uaParser.Parse(header);
                device = $"{info.Device.Family}/{info.OS.Family} {info.OS.Major}.{info.OS.Minor} - {info.UA.Family}";
            }

            var token = JwtTokenBuilder.BuildToken(user, _configuration);
            var refreshToken = Guid.NewGuid().ToString();

            var hashJwt = Sha256Hasher.Hash(token);
            var hashRefreshToken = Sha256Hasher.Hash(refreshToken);

            var tokenResult = await _userFacade.AddTokenAsync(new AddUserTokenCommand(user.Id, hashJwt, hashRefreshToken, DateTime.Now.AddDays(3), DateTime.Now.AddDays(5), device));
            if (tokenResult.Status != OperationResultStatus.Success)
                return OperationResult<LoginResultViewModel?>.Error();

            return OperationResult<LoginResultViewModel?>.Success(new LoginResultViewModel()
            {
                Token = token,
                RefreshToken = refreshToken
            });
        }
    }
}