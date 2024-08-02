using BackEndBookingTravel.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEndBookingTravel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeController : ControllerBase
    {
        private readonly IDocumentTypeService _documentTypeService;
        public DocumentTypeController(IDocumentTypeService documentTypeService)
        {

            _documentTypeService = documentTypeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDocumentTypesAsync()
        {
            return Ok(await _documentTypeService.GetAllDocumentTypesAsync());
        }
    }
}
