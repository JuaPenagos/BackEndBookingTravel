using BackEndBookingTravel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBookingTravel.Domain.Repository
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetAllAvailableRoomsAsync();

        Task<Room?> CreateRoomAsync(Room room);

        Task DisableRoomAsync(Room room);

        Task<Room?> GetRoomById(int id);

        Task<List<Room>> GetAllRoomsAsync();

        Task UpdateRoomAsync(Room room);
    }
}
