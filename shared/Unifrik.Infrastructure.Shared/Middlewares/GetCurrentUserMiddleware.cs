using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Unifrik.Domain.Shared.Enums;
using Unifrik.Infrastructure.Shared.User;

namespace Unifrik.Infrastructure.Shared.Middlewares
{
    public class GetCurrentUserMiddleware
    {
        private readonly RequestDelegate _next;


        public GetCurrentUserMiddleware(RequestDelegate next)
        {
            _next = next;

        }

        public async Task Invoke(HttpContext context, ICurrentUser _currentUser)
        {
            var user = context.User; 
            if (user.Identity.IsAuthenticated)
            {
                var roleString = user.Claims
               .First(c => c.Type == ClaimTypes.Role).Value;
                UserTypeEnum role = Enum.Parse<UserTypeEnum>(roleString);
                string email = user.Claims
                    .First(c => c.Type == ClaimTypes.Email).Value;
                _currentUser.SetUser(email, role);
            }
               
           
            await _next(context);
        }
    }
}
