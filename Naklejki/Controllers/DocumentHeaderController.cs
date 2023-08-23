using Microsoft.AspNetCore.Mvc;
using Services.DataTransferModels.Document;
using Services.Interfaces;

namespace API.Controllers
{
    [Route("DocumentHeader")]
    [ApiController]
    public class DocumentHeaderController : Controller
    {
        private readonly IDocumentHeaderService _documentHeaderService;

        public DocumentHeaderController(IDocumentHeaderService documentHeaderService)
        {
            _documentHeaderService = documentHeaderService; 
        }

        [HttpPost]
        public async Task<ActionResult<DocumentDto>> CreateDocument(AddDocumentDto documentDto)
        {
            try
            {
                var newDocument = await _documentHeaderService.AddDocument(documentDto);
                return Ok(newDocument);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<DocumentDto>>> GetAllDocumentsHeader()
        {
            try
            {
                var documentHeaders = await _documentHeaderService.GetAllDocuments();
                return Ok(documentHeaders);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
