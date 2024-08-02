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
    public class HotelRepository : BaseRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(DataContext context) : base(context)
        {
        }

        public async Task<List<Hotel>> GetAllHotelsAsync()
        {
            var hotelDB = await _dbSet.Include(x => x.Rooms).ToListAsync();
            return hotelDB;
        }

        public async Task<Hotel?> CreateHotelAsync(Hotel hotel)
        {
            var hotelDB = await AddAsync(hotel);
            return hotelDB;
        }

        public async Task DisableHotelAsync(Hotel hotel)
        {
            await UpdateAsync(hotel);
        }

        public async Task<Hotel?> GetHotelById(int id)
        {
            var hotelDB = await GetByIdAsync(id);
            return hotelDB;
        }

        public async Task UpdateHotelAsync(Hotel hotel)
        {
            await UpdateAsync(hotel);
        }
    }
}
