using BackEndBookingTravel.Application.Interfaces;
using BackEndBookingTravel.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Moq;
using BackEndBookingTravel.Application.Services;
using BackEndBookingTravel.Application.Dtos;
using BackEndBookingTravel.Domain.Entities;

namespace BackendBookingTravel.Test.Services
{
    public class RoomServiceTest
    {

        private IRoomService _roomService;
        private Mock<IRoomRepository> _mockRoomRepository;
        private Mock<ILog> _mockLogger;
        public RoomServiceTest()
        {
            _mockRoomRepository = new Mock<IRoomRepository>();
            _mockLogger = new Mock<ILog>();
            _roomService = new RoomService(_mockRoomRepository.Object, _mockLogger.Object);
        }

        [Fact]
        public void CreateRoomCorrectTest()
        {

            RoomDto roomDto = new RoomDto()
            {
                Name = "Habitacion Principal",
                BasePrice = 120000,
                Tax = 36000,
                IdRoomType = 1
            };

            Room room = new Room() { 
            Name = "Habitacion Principal",
            BasePrice = 120000,
            Tax = 36000,
            IdRoomType = 1
            };
            _mockRoomRepository.Setup(x => x.CreateRoomAsync(It.IsAny<Room>())).ReturnsAsync(room);

            var response  = _roomService.CreateRoomAsync(roomDto);

            Assert.Equal("Room Created", response.Result.Message);
        }

        [Fact]
        public void GetAllAvailableRoomsCoorectTest()
        {

            List<Room> rooms = new List<Room>();

            _mockRoomRepository.Setup(x => x.GetAllAvailableRoomsAsync()).ReturnsAsync(rooms);

            var response = _roomService.GetAllAvailableRoomsAsync();

            Assert.Equal("Data no Found", response.Result.Message);
        }
    }
}
