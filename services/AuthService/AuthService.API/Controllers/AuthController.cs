using Microsoft.AspNetCore.Mvc;

namespace AuthService.API.Controllers
{
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        [HttpPost("register")]
        public IActionResult Register()
        {
            return Ok();
        }
    }
}
