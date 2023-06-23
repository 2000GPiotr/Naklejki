using Microsoft.AspNetCore.Mvc;
using Services.DataTransferModels.LabelStatus;
using Services.Interfaces;

namespace API.Controllers
{
    [Route("/LabelStatus")]
    [ApiController]
    public class LabelStatusController : Controller
    {
        private readonly ILabelStatusService _labelStatusService;
        public LabelStatusController(ILabelStatusService labelStatusService)
        {
            _labelStatusService = labelStatusService;
        }

        [HttpGet]
        public async Task<ActionResult<List<LabelStatusDto>>> GetAllStatuses()
        {
            var statuses = await _labelStatusService.GetLabelStatuses();
            return Ok(statuses);
        }

        [HttpGet("{symbol}")]
        public async Task<ActionResult<LabelStatusDto>> GetStatusBySymbol(string symbol)
        {
            var status = await _labelStatusService.GetLabelStatusBySymbol(symbol);
            return Ok(status);
        }
    }
}
