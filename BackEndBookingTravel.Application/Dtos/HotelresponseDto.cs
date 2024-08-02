using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBookingTravel.Application.Dtos
{
    public class HotelresponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<RoomResponseDto> Rooms { get; set; }
    }
}
