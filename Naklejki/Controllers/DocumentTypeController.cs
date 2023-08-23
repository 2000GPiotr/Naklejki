using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DataTransferModels.Document;
using Services.Interfaces;

namespace API.Controllers
{
    [Route("/DocumentType")]
    [ApiController]
    public class DocumentTypeController : Controller
    {
        private readonly IDocumentTypeService _documentTypeService;

        public DocumentTypeController(IDocumentTypeService documentTypeService)
        {
            _documentTypeService = documentTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DocumentTypeDto>>> GetAllDocumentTypes()
        {
            var documentTypes = await _documentTypeService.GetAllDocumentTypes();
            return Ok(documentTypes);
        }
    }
}
