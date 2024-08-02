using BackEndBookingTravel.Application.Dtos;
using BackEndBookingTravel.Application.Interfaces;
using BackEndBookingTravel.Application.Services;
using BackEndBookingTravel.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEndBookingTravel.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class RoomController : ControllerBase
    {

        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {

            _roomService = roomService;
        }

        [HttpPost("AddRoom")]
        public async Task<IActionResult> CreateRoomAsync(RoomDto roomDto)
        {
           return Ok(await _roomService.CreateRoomAsync(roomDto));
        }

        [HttpGet("GetAvailableRooms")]
        public async Task<IActionResult> GetAllAvailableRoomsAsync()
        {
            return Ok(await _roomService.GetAllAvailableRoomsAsync());
        }

        [HttpPost("ChangeStatusRoom")]
        public async Task<IActionResult> ChangeStatusRoomAsync(int idRoom)
        {
            await _roomService.ChangeStatusRoomAsync(idRoom);
            return Ok();
        }

        [HttpPost("GetAllRoom")]
        public async Task<IActionResult> GetAllRoomsAsync()
        {
            return Ok(await _roomService.GetAllRoomsAsync());
        }
    }
}
