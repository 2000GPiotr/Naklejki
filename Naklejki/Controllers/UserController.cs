using Microsoft.AspNetCore.Mvc;
using Services.DataTransferModels;
using Services.DataTransferModels.User;
using Services.Interfaces;

namespace API.Controllers
{
    [Route("/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] CreateUserDto userDto)
        {
            try
            {
                var newUser = await _userService.CreateUser(userDto);
            return Ok(newUser);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDto>> DeleteUser([FromRoute]int id)
        {
            try
            {
                var deletedUser = await _userService.DeleteUser(id);
                return Ok(deletedUser);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            try
            {
                var toReturn = await _userService.GetAllUsers();
                return Ok(toReturn);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> UpdateUser([FromBody] UpdateUserDto userDto, [FromRoute] int id)
        {
            try
            {
                var user = await _userService.UpdateUser(userDto, id);
                return Ok(user);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
