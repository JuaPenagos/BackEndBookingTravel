using BackEndBookingTravel.Domain.Entities;
using BackEndBookingTravel.Domain.Repository;
using BackEndBookingTravel.Infrastructure.SQL.Context;
using BackEndBookingTravel.Infrastructure.SQL.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBookingTravel.Infrastructure.SQL.Repository
{
    public class BookingCustomerRepository : BaseRepository<BookingCustomer>, IBookingCustomerRepository
    {
        public BookingCustomerRepository(DataContext context) : base(context)
        {
        }

        public async Task<List<BookingCustomer>> AddCustomersToBookingHotel(List<BookingCustomer> bookingCustomers)
        {
            var bookingCustomersDB = await AddRangeAsync(bookingCustomers);
            return bookingCustomersDB.ToList();
        }
    }
}
