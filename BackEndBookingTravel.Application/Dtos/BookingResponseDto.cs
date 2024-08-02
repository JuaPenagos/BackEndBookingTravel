using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBookingTravel.Application.Dtos
{
    public class BookingResponseDto
    {
        public string RoomName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string EmergencyContactName { get; set; }

        public string EmergencyPhoneNumber { get; set; }

        public List<CustomerResponseDto> Customers { get; set; }
    }
}
