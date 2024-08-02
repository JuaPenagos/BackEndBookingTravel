using BackEndBookingTravel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBookingTravel.Domain.Repository
{
    public interface IHotelRoomRepository
    {
        Task<List<HotelRoom>> AddRoomToHotel(List<HotelRoom> hotelRoom);

        Task<List<HotelRoom>> GetRoomsByHotelId(int idHotel);
    }
}
