using BackEndBookingTravel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBookingTravel.Domain.Repository
{
    public interface ICustomerRepository
    {
        Task<List<Customer?>> CreateCustomerAsync(List<Customer> customer);
    }
}
