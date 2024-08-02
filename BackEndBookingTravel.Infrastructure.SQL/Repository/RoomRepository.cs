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
    public class RoomRepository : BaseRepository<Room>, IRoomRepository
    {
        public RoomRepository(DataContext context) : base(context)
        {
        }

        public async Task<List<Room>> GetAllAvailableRoomsAsync()
        {
            var hotelRoom = _context.Set<HotelRoom>();
            var response = await _dbSet.Where(x => !hotelRoom.Select(y => y.IdRoom).Contains(x.Id) && x.IsActive).Include(x => x.RoomType).ToListAsync();
            return response;
        }

        public async Task<Room?> CreateRoomAsync(Room room)
        {
            var roomDB = await AddAsync(room);
            return roomDB;
        }

        public async Task DisableRoomAsync(Room room)
        {
            await UpdateAsync(room);
        }

        public async Task<Room?> GetRoomById(int id)
        {
            var roomDB = await GetByIdAsync(id);
            return roomDB;
        }

        public async Task<List<Room>> GetAllRoomsAsync()
        {
            var roomDB = await _dbSet.Include(x => x.RoomType).ToListAsync();
            return roomDB;
        }

        public async Task UpdateRoomAsync(Room room)
        {
            await UpdateAsync(room);
        }
    }
}
