using Database.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.DataTransferModels.LabelType;
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

        [HttpGet/*, Authorize(Roles = "Admin, User")*/]
        public async Task<ActionResult<List<LabelTypeDto>>> GetAllLabelTypes()
        {
            try
            {
                var labels = await _labelTypeService.GetAllLabelTypes();
                return Ok(labels);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{symbol}")]
        public async Task<ActionResult<LabelTypeDto>> GetLabelTypeBySymbol([FromRoute]string symbol)
        {
            try
            {
                var labelType = await _labelTypeService.GetLabelTypeBySymbol(symbol);
                return Ok(labelType);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<LabelTypeDto>> CreateLabelType([FromBody]LabelTypeDto labelTypeDto)
        {
            try
            {
                var label = await _labelTypeService.CreateLabelType(labelTypeDto);
                return Ok(label);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{symbol}")]
        public async Task<ActionResult<LabelTypeDto>> DeleteLabelTypeBySymbol(string symbol)
        {
            try
            {
                var label = await _labelTypeService.DeleteLabelTypeBySymbol(symbol);
                return Ok(label);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{symbol}")]
        public async Task<ActionResult<LabelTypeDto>> UpdateLabelTypeBySymbol([FromRoute]string symbol, [FromBody]UpdateLabelTypeDto labelTypeDto)
        {
            try
            {
                var label = await _labelTypeService.UpdateLabelTypeBySymbol(symbol, labelTypeDto);
                return Ok(label);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
