using BookShop.Presentation.Facade.Users;
using Common.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace BookShop.API.Infrastructures.JwtUtil
{
    public class JwtValidation
    {
        private readonly IUserFacade _userFacade;

        public JwtValidation(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        public async Task Validate(TokenValidatedContext context)
        {
            var userId = context.Principal.GetUserId();
            var jwtToken = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var token = await _userFacade.GetUserTokenByJwtTokenAsync(jwtToken);
            if (token == null)
            {
                context.Fail("Token یافت نشد");
                return;
            }

            var user = await _userFacade.GetUserByIdAsync(userId);
            if (user == null || user.IsActive == false)
            {
                context.Fail("کاربر نامعتبر");
                return;
            }
        }
    }
}