using BackEndBookingTravel.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBookingTravel.Domain.Entities
{
    public class BookingCustomer : BaseEntity
    {
        public int IdBooking { get; set; }

        public int IdCustomer { get; set; }

    }
}
