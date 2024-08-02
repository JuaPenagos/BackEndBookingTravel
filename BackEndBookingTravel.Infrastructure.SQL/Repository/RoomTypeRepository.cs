using BackEndBookingTravel.Domain.Entities;
using BackEndBookingTravel.Domain.Repository;
using BackEndBookingTravel.Infrastructure.SQL.Context;
using BackEndBookingTravel.Infrastructure.SQL.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBookingTravel.Infrastructure.SQL.Repository
{
    public class RoomTypeRepository : BaseRepository<RoomType>, IRoomTypeRepository
    {
        public RoomTypeRepository(DataContext context) : base(context)
        {
        }

        public async Task<List<RoomType>> GetAllRoomTypesAsync()
        {
            var roomTypes = await GetAsync();
            return roomTypes.ToList();
        }

        public async Task<RoomType?> CreateRoomTypeAsync(RoomType roomType)
        {
            var roomTypeDB = await AddAsync(roomType);
            return roomTypeDB;
        }
    }
}
