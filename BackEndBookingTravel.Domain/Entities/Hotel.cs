using BackEndBookingTravel.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBookingTravel.Domain.Entities
{
    public class Hotel : BaseEntity
    {
        public string Name { get; set; }

        public bool IsActive { get; set; }

        public int CreateUser { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
