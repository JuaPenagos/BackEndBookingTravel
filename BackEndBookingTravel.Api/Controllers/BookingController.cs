using BackEndBookingTravel.Application.Dtos;
using BackEndBookingTravel.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEndBookingTravel.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {

            _bookingService = bookingService;
        }
        [AllowAnonymous]
        [HttpPost("CreateBooking")]
        public async Task<IActionResult> GetAllDocumentTypesAsync(BookingDto bookingDto)
        {
            return Ok(await _bookingService.CreateBookingAsync(bookingDto));
        }

        [HttpGet("GetBookingByHotel")]
        public async Task<IActionResult> GetBookingByHotelList(int idHotel)
        {
            return Ok(await _bookingService.GetBookingByHotelList(idHotel));
        }

        [HttpGet("GetBookingDetail")]
        public async Task<IActionResult> GetBookingByIdAsync(int idBooking)
        {
            return Ok(await _bookingService.GetBookingById(idBooking));
        }
        }
}
