using BookShop.Presentation.Facade.Users;
using Common.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace BookShop.API.Infrastructures.JwtUtil
{
    public class CustomJwtValidation
    {
        private readonly IUserFacade _userFacade;

        public CustomJwtValidation(IUserFacade userFacade)
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
                context.Fail("Token NotFound");
                return;
            }

            var user = await _userFacade.GetUserByIdAsync(userId);
            if (user == null || user.IsActive == false)
            {
                context.Fail("User InActive");
                return;
            }
        }
    }
}