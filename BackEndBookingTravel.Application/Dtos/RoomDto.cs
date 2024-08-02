using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBookingTravel.Application.Dtos
{
    public class RoomDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double BasePrice { get; set; }

        public double Tax { get; set; }

        public string Location { get; set; }

        public int IdRoomType { get; set; }
    }
}
