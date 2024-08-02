using BackEndBookingTravel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBookingTravel.Domain.Repository
{
    public interface IBookingCustomerRepository
    {
        Task<List<BookingCustomer>> AddCustomersToBookingHotel(List<BookingCustomer> bookingCustomers);
    }
}
