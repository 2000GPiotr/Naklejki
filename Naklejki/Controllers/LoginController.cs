using Microsoft.AspNetCore.Mvc;
using Services.DataTransferModels.Login;
using Services.DataTransferModels.User;
using Services.Interfaces;

namespace API.Controllers
{
    [Route("/Login")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto loginDto)
        {
            var user = await _loginService.Login(loginDto);
            if(user == null)
                return NotFound();

            return Ok(user);
        }
    }
}
