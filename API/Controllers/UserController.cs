using API.Requests;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("/signup")]
        public async Task<IActionResult> SignUp(SignupRequest model)
        {
            var result = await _userService.SignUpAsync(model);
            return Ok(result);
        }
    }
}
