using BackEndBookingTravel.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBookingTravel.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
