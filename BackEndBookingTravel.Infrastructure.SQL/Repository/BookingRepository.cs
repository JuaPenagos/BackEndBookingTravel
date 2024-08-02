using BackEndBookingTravel.Domain.Entities;
using BackEndBookingTravel.Domain.Repository;
using BackEndBookingTravel.Infrastructure.SQL.Context;
using BackEndBookingTravel.Infrastructure.SQL.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBookingTravel.Infrastructure.SQL.Repository
{
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        public BookingRepository(DataContext context) : base(context)
        {
        }

        public async Task<List<Booking>> GetAllBookingsAsync()
        {
            var bookings = await GetAsync();
            return bookings.ToList();
        }

        public async Task<Booking?> CreateBookingAsync(Booking booking)
        {
            var bookingDB = await AddAsync(booking);
            return bookingDB;
        }
         
        public async Task<Booking?> GetBookingById(int id)
        {
            var booking = await _dbSet.Where(x => x.Id == id).Include(x => x.Room).Include(x => x.Customers).FirstOrDefaultAsync();
            return booking;
        }

        public async Task<List<Booking>> GetAllBookingsByRoomsIdsAsync(List<int> roomsIds )
        {
            var bookings = await _dbSet.Where(x => roomsIds.Contains(x.IdRoom)).Include(x => x.Room).ToListAsync();
            return bookings.ToList();
        }
    }
}