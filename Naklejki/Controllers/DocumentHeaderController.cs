using Database.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.DataTransferModels;
using Services.Interfaces;

namespace API.Controllers
{
    [Route("/DocumentHeader")]
    [ApiController]
    public class DocumentHeaderController : Controller
    {
        private readonly IDocumentHeaderService _documentHeaderService;
        public DocumentHeaderController(IDocumentHeaderService documentHeaderService)
        {
            _documentHeaderService = documentHeaderService;
        }

        [HttpPost]
        public async Task<ActionResult<DocumentHeader>> CreateDocumentHeader(DocumentHeaderDto documentHeaderDto)
        {
            var documentHeader = await _documentHeaderService.CreateDocumentHeader(documentHeaderDto);
            return Ok(documentHeader);
        }
    }
}
