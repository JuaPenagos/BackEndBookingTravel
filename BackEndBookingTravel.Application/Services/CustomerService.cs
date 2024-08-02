using BackEndBookingTravel.Application.Dtos;
using BackEndBookingTravel.Application.Interfaces;
using BackEndBookingTravel.Domain.Entities;
using BackEndBookingTravel.Domain.Repository;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBookingTravel.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILog _logger;
        public CustomerService(ICustomerRepository customerRepository, ILog logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }

    }
}