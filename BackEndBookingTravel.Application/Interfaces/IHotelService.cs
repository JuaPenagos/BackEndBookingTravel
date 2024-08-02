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
    public interface IHotelService
    {
        Task<ApiResponse<List<HotelresponseDto>>> GetAllHotelsAsync();

        Task<Hotel> CreateHotelAsync(HotelDto hotelDto);

        Task<ApiResponse<string>> AddRoomsToHotelAsync(HotelRoomDto hotelRoomDto);

        Task<ApiResponse<string>> ChangeStatusHotelAsync(int idHotel);

        Task<ApiResponse<string>> UpdateHotelAsync(HotelDto hotelDto);
    }
}
