using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBookingTravel.Application.Dtos
{
    public class HotelRoomDto
    {
        public int IdHotel { get; set; }

        public List<int> IdRooms { get; set; }
    }
}
