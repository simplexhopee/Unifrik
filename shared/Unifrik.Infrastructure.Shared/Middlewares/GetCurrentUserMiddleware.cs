using Microsoft.AspNetCore.Http;
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
            var roles = user.Claims
            .Where(c => c.Type == "roles")
            .Select(c => c.Value)
            .ToList();

            var permissions = user.Claims
           .Where(c => c.Type == "permissions")
           .Select(c => c.Value)
           .ToList();

          //  if (user.FindFirst("email") != null) _currentUser.SetUser(user?.FindFirst("email").Value, roles, permissions);
            await _next(context);
        }
    }
}
