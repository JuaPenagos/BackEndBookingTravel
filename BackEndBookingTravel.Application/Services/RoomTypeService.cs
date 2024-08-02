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
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IRoomTypeRepository _roomTypeRepository;
        private readonly ILog _logger;
        public RoomTypeService(IRoomTypeRepository roomTypeRepository, ILog logger)
        {
            _roomTypeRepository = roomTypeRepository;
            _logger = logger;
        }

        public async Task<List<RoomType>> GetAllRoomTypesAsync()
        {
            return await _roomTypeRepository.GetAllRoomTypesAsync();
        }

    }
}