using BackEndBookingTravel.Application.Dtos;
using BackEndBookingTravel.Application.Interfaces;
using BackEndBookingTravel.Application.Services;
using BackEndBookingTravel.Domain.Entities;
using BackEndBookingTravel.Domain.Repository;
using log4net;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendBookingTravel.Test.Services
{
    public class HotelServiceTest
    {
        private IHotelService _hotelService;
        private Mock<IHotelRepository> _mockHotelRepository;
        private Mock<IHotelRoomRepository> _mockHotelRoomRepository;
        private Mock<ILog> _mockLogger;
        public HotelServiceTest()
        {
            _mockHotelRepository = new Mock<IHotelRepository>();
            _mockHotelRoomRepository = new Mock<IHotelRoomRepository>();
            _mockLogger = new Mock<ILog>();
            _hotelService = new HotelService(_mockHotelRepository.Object, _mockLogger.Object, _mockHotelRoomRepository.Object);
        }


        [Fact]
        public void CreateHotelCorrectTest()
        {
            HotelDto hotelDto = new HotelDto()
            {
                Name = "Hotel las margaritas"
            };

            Hotel hotel = new Hotel()
            {
                Name = "Hotel las margaritas",
                IsActive = true,
                Id = 5

            };

            _mockHotelRepository.Setup(x => x.CreateHotelAsync(It.IsAny<Hotel>())).ReturnsAsync(hotel);

            var response = _hotelService.CreateHotelAsync(hotelDto);

            Assert.Equal(5, response.Result.Id);
        }

        [Fact]
        public void AddRoomsToHotelCorrectTest()
        {
            HotelRoomDto hotelDto = new HotelRoomDto()
            {
                IdHotel = 5,
                IdRooms = new List<int> { 1 }
            };

            HotelRoom hotelRoom = new HotelRoom()
            {
               IdHotel = 5,
               IdRoom = 1
            };

            List<HotelRoom> hotelRooms = new List<HotelRoom>();
            hotelRooms.Add(hotelRoom);

            _mockHotelRoomRepository.Setup(x => x.AddRoomToHotel(It.IsAny<List<HotelRoom>>())).ReturnsAsync(hotelRooms);

            var response = _hotelService.AddRoomsToHotelAsync(hotelDto);

            Assert.Equal("Rooms Added", response.Result.Message);
        }
    }
}
