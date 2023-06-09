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
        public async Task<ActionResult<string>> Login([FromBody] LoginDto loginDto)
        {
            String token;
            try
            {
                token = await _loginService.Login(loginDto);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
            if (token == null)
                return NotFound();

            return Ok(token);
        }
    }
}
