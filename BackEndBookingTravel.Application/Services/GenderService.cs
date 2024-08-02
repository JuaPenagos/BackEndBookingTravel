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
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _genderRepository;
        private readonly ILog _logger;
        public GenderService(IGenderRepository genderRepository, ILog logger)
        {
            _genderRepository = genderRepository;
            _logger = logger;
        }

        public async Task<List<Gender>> GetAllGendersAsync()
        {
            return await _genderRepository.GetAllGendersAsync();
        }

    }
}