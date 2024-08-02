using BackEndBookingTravel.Application.Interfaces;
using BackEndBookingTravel.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEndBookingTravel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IGenderService _genderService;
        public GenderController(IGenderService genderService)
        {

            _genderService = genderService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllGendersAsync()
        {
            return Ok(await _genderService.GetAllGendersAsync());
        }
    }
}
