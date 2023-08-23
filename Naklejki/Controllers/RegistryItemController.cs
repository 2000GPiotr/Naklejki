using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DataTransferModels.Registry;
using Services.Interfaces;

namespace API.Controllers
{
    [Route("/Registry")]
    [ApiController]
    public class RegistryItemController : ControllerBase
    {
        private readonly IRegistryService _registryService;
        public RegistryItemController(IRegistryService registryService)
        {
            _registryService = registryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<RegistryItemDto>>> GetAllRegistryItems()
        {
            var registryItems = await _registryService.GetAllRegistryItems();
            return Ok(registryItems);
        }

        [HttpPost]
        public async Task<ActionResult<RegistryItemDto>> CreateRegistryItem([FromBody]AddRegistryItemDto registryItemDto)
        {
            var registryItem = await _registryService.AddRegistryItem(registryItemDto);
            return Ok(registryItem);
        }

        [HttpPut]
        public async Task<ActionResult<RegistryItemDto>> CreateManyRegistryItem([FromBody] List<AddRegistryItemDto> registryItemsDto)
        {
            var registryItems = new List<RegistryItemDto>();
            foreach (var item in registryItemsDto)
            {
                registryItems.Add(await _registryService.AddRegistryItem(item));

            }
            return Ok(registryItems);
        }
    }
}
