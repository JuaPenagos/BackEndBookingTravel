using BackEndBookingTravel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBookingTravel.Domain.Repository
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetAllBookingsAsync();

        Task<Booking?> CreateBookingAsync(Booking booking);

        Task<Booking?> GetBookingById(int id);

        Task<List<Booking>> GetAllBookingsByRoomsIdsAsync(List<int> roomsIds);
    }
}
