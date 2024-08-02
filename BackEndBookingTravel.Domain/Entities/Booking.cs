using BackEndBookingTravel.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBookingTravel.Domain.Entities
{
    public class Booking : BaseEntity
    {
        public int IdRoom { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string EmergencyContactName { get; set; }

        public string EmergencyPhoneNumber { get; set; }

        public virtual Room Room { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
