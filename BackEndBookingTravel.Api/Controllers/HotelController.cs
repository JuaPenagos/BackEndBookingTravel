using BackEndBookingTravel.Application.Dtos;
using BackEndBookingTravel.Application.Interfaces;
using BackEndBookingTravel.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEndBookingTravel.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        public HotelController(IHotelService hotelService)
        {

            _hotelService = hotelService;
        }

        [HttpPost("CreateHotel")]
        public async Task<IActionResult> CreateHotelAsync(HotelDto hotelDto)
        {
            var response = await _hotelService.CreateHotelAsync(hotelDto);
            return Ok(response);
        }

        [HttpPost("AddRoomsToHotel")]
        public async Task<IActionResult> AddRoomsToHotelAsync(HotelRoomDto hotelRoomDto)
        {
            var response = await _hotelService.AddRoomsToHotelAsync(hotelRoomDto);
            return Ok(response);
        }

        [HttpPost("ChangeStatusHotel")]
        public async Task<IActionResult> ChangeStatusHotelAsync(int idHotel)
        {
            var response = await _hotelService.ChangeStatusHotelAsync(idHotel);
            return Ok(response);
        }

        [HttpGet("GetAllHotels")]
        public async Task<IActionResult> GetAllHotelsAsync()
        {
            var response = await _hotelService.GetAllHotelsAsync();
            return Ok(response);
        }
    }
}
