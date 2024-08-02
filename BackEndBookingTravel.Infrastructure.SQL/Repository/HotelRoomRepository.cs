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
    public class HotelRoomRepository : BaseRepository<HotelRoom>, IHotelRoomRepository
    {
        public HotelRoomRepository(DataContext context) : base(context)
        {
        }
        public async Task<List<HotelRoom>> AddRoomToHotel(List<HotelRoom> hotelRoom)
        {
            var hotelDB = await AddRangeAsync(hotelRoom);
            return hotelDB.ToList();
        }

        public async Task<List<HotelRoom>> GetRoomsByHotelId(int idHotel)
        {
            var hotelDB = await _dbSet.Where(x => x.IdHotel == idHotel).ToListAsync();
            return hotelDB.ToList();
        }

    }
}