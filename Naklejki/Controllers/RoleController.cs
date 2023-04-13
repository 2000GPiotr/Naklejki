using Microsoft.AspNetCore.Mvc;
using Services.DataTransferModels;
using Services.Interfaces;

namespace API.Controllers
{
    [Route("/Role")]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<ActionResult<List<RoleDto>>> GetAllRoles()
        {
            var roles = await _roleService.GetAllRoles();
            return Ok(roles);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<RoleDto>> GetRoleById([FromRoute] int Id)
        {
            var role = await _roleService.GetRoleById(Id);
            return Ok(role);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateRole([FromBody] RoleDto roleDto)
        {
            var role = await _roleService.CreateRole(roleDto);
            return Ok(true);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<RoleDto>> DeleteRoleById([FromRoute] int Id)
        {
            var role = await _roleService.DeleteRoleById(Id);
            return Ok(role);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<bool>> UpdateRoleById([FromRoute] int Id, [FromBody] RoleDto roleDto)
        {
            var role = await _roleService.UpdateRoleById(Id, roleDto);
            return Ok(role);
        }
    }
}
