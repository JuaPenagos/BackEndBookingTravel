using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBookingTravel.Application.Dtos
{
    public class CustomerDto
    {
        public string FullName { get; set; }

        public DateTime BirthDate { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string DocumentNumber { get; set; }

        public int IdGender { get; set; }

        public int IdDocumentType { get; set; }
    }
}
