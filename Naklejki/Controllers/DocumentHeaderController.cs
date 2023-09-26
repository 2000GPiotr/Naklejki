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
        public async Task<ActionResult<DocumentDto>> CreateDocument([FromBody]AddDocumentDto documentDto)
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

        [HttpPut("{id}")]
        public async Task<ActionResult<DocumentDto>> UpdateDocumentHeader([FromBody] UpdateDocumentHeaderDto updateDocumentHeaderDto, int id)
        {
            try
            {
                var documentHeader = await _documentHeaderService.UpdateDocument(updateDocumentHeaderDto, id);
                return Ok(documentHeader);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
