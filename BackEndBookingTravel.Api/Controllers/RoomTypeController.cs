using BackEndBookingTravel.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEndBookingTravel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomTypeService _roomTypeService;
        public RoomTypeController(IRoomTypeService roomTypeService)
        {

            _roomTypeService = roomTypeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRoomTypesAsync()
        {
            return Ok(await _roomTypeService.GetAllRoomTypesAsync());
        }
    }
}
