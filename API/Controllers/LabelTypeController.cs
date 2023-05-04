using Database.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.DataTransferModels;
using Services.Interfaces;

namespace API.Controllers
{
    [Route("/LabelType")]
    [ApiController]
    public class LabelTypeController : Controller
    {
        private readonly ILabelTypeService _labelTypeService;
        public LabelTypeController(ILabelTypeService labelTypeService)
        {
            _labelTypeService = labelTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<LabelTypeDto>>> GetAllLabelTypes()
        {
            var labels = await _labelTypeService.GetAllLabelTypes();
            return Ok(labels);
        }

        [HttpGet("{symbol}")]
        public async Task<ActionResult<LabelTypeDto>> GetLabelTypeBySymbol([FromRoute]string symbol)
        {
            var labelType = await _labelTypeService.GetLabelTypeBySymbol(symbol);
            return Ok(labelType);
        }

        [HttpPost]
        public async Task<ActionResult<LabelType>> CreateLabelType([FromBody]LabelTypeDto labelTypeDto)
        {
            var label = await _labelTypeService.CreateLabelType(labelTypeDto);
            return Ok(label);
        }

        [HttpDelete("{symbol}")]
        public async Task<ActionResult<LabelTypeDto>> DeleteLabelTypeBySymbol(string symbol)
        {
            var label = await _labelTypeService.DeleteLabelTypeBySymbol(symbol);
            return Ok(label);
        }

        [HttpPut("{symbol}")]
        public async Task<ActionResult<LabelType>> UpdateLabelTypeBySymbol([FromRoute]string symbol, [FromBody]UpdateLabelTypeDto labelTypeDto)
        {
            var label = await _labelTypeService.UpdateLabelTypeBySymbol(symbol, labelTypeDto);
            return Ok(label);
        }
    }
}
