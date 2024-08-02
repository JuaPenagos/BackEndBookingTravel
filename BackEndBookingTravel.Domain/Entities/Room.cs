using BackEndBookingTravel.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBookingTravel.Domain.Entities
{
    public class Room : BaseEntity
    {
        public string Name { get; set; }

        public double BasePrice { get; set; }

        public double Tax { get; set; }

        public string Location { get; set; }

        public int IdRoomType { get; set; }

        public virtual RoomType RoomType { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public bool IsActive { get; set; }
        public int CreateUser { get; set; }

        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}
