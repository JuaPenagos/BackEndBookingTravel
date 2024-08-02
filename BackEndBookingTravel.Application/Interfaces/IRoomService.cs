using BackEndBookingTravel.Application.Dtos;
using BackEndBookingTravel.Domain.Entities;
using BackEndBookingTravel.Utility.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBookingTravel.Application.Interfaces
{
    public interface IRoomService
    {
        Task<ApiResponse<List<RoomResponseDto>>> GetAllAvailableRoomsAsync();

        Task<ApiResponse<string>> CreateRoomAsync(RoomDto roomDto);

        Task ChangeStatusRoomAsync(int idRoom);

        Task<ApiResponse<List<RoomResponseDto>>> GetAllRoomsAsync();
    }
}
