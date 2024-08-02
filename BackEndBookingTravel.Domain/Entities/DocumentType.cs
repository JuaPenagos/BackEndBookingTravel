using BackEndBookingTravel.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBookingTravel.Domain.Entities
{
    public class DocumentType : BaseEntity
    {
        public string Code { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
