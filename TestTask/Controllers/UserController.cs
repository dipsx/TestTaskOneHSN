using DotNetCore.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestTask.App.User;

namespace TestTask.Controllers {

    [ApiController]
    [Route("api/user")]
    public class UserController : BaseController {

        [AllowAnonymous]
        [HttpPost("auth")]
        public IActionResult Auth(AuthRequest request) => Mediator.HandleAsync<AuthRequest, AuthResponse>(request).ApiResult();
    }
}
