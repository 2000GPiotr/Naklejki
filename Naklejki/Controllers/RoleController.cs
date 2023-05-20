using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DataTransferModels.Roles;
using Services.Interfaces;

namespace API.Controllers
{
    [Route("/Role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRolesService _roleService;
        public RoleController(IRolesService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<ActionResult<List<RoleDto>>> GetAllRoles()
        {
            var roles = await _roleService.GetAllRoles();
            return Ok(roles);
        }
    }
}
