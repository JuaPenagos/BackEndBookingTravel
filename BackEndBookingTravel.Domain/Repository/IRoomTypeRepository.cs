using BackEndBookingTravel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBookingTravel.Domain.Repository
{
    public interface IRoomTypeRepository
    {
        Task<List<RoomType>> GetAllRoomTypesAsync();

        Task<RoomType?> CreateRoomTypeAsync(RoomType roomType);
    }
}
