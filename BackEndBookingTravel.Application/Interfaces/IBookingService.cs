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
    public interface IBookingService
    {
        Task<ApiResponse<BookingResponseDto>> CreateBookingAsync(BookingDto bookingDto);

        Task<ApiResponse<List<BookingResponseDto>>> GetBookingByHotelList(int idHotel);

        Task<ApiResponse<BookingResponseDto>> GetBookingById(int idBooking);

    }
}
