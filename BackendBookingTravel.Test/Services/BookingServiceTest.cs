using BackEndBookingTravel.Application.Dtos;
using BackEndBookingTravel.Application.Interfaces;
using BackEndBookingTravel.Application.Services;
using BackEndBookingTravel.Domain.Entities;
using BackEndBookingTravel.Domain.Repository;
using BackEndBookingTravel.Infrastructure.Mail;
using log4net;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendBookingTravel.Test.Services
{
    public class BookingServiceTest
    {
        private IBookingService _bookingService;
        private Mock<IBookingRepository> _mockBookingRepository;
        private Mock<IBookingCustomerRepository> _mockBookingCustomerRepository;
        private Mock<IHotelRoomRepository> _mockHotelRoomRepository;
        private Mock<ICustomerRepository> _mockCustomerRepository;
        private Mock<IEmailSender> _mockEmailSenderRepository;
        

        public BookingServiceTest()
        {
            _mockBookingRepository = new Mock<IBookingRepository>();
            _mockBookingCustomerRepository = new Mock<IBookingCustomerRepository>();
            _mockHotelRoomRepository = new Mock<IHotelRoomRepository>();
            _mockCustomerRepository = new Mock<ICustomerRepository>();
            _mockEmailSenderRepository = new Mock<IEmailSender>();
            _bookingService = new BookingService(_mockBookingRepository.Object, _mockBookingCustomerRepository.Object, _mockCustomerRepository.Object, 
                _mockHotelRoomRepository.Object, _mockEmailSenderRepository.Object);
        }

        [Fact]
        public void CreateBookingCorrectTest()
        {
            BookingDto bookingDto = new BookingDto()
            { 
                Customers =  new List<CustomerDto> { new CustomerDto() {
                FullName = "juanpenagos",
                BirthDate = DateTime.UtcNow,
                Email = "juan@juan.com",
                DocumentNumber = "12345",
                PhoneNumber = "23151",
                IdDocumentType = 1,
                IdGender = 2,
                } },
                EmergencyContactName = "Marta ramirez",
                EmergencyPhoneNumber = "231561563",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(3),
                IdRoom = 2

            };

            Booking booking = new Booking()
            {
                EmergencyContactName = "Marta ramirez",
                EmergencyPhoneNumber = "231561563",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(3),
                IdRoom = 2
            };

            Customer customer = new Customer()
            {
                FullName = "juanpenagos",
                BirthDate = DateTime.UtcNow,
                Email = "juan@juan.com",
                DocumentNumber = "12345",
                PhoneNumber = "23151",
                IdDocumentType = 1,
                IdGender = 2,
                Id = 1
            };

            BookingCustomer bookingCustomer = new BookingCustomer()
            {
                IdBooking = 1,
                IdCustomer = 2

            };

            List<Customer> customers = new List<Customer>() { customer };

            List<BookingCustomer> bookingCustomers = new List<BookingCustomer>() { bookingCustomer };

            _mockBookingRepository.Setup(x => x.CreateBookingAsync(It.IsAny<Booking>())).ReturnsAsync(booking);

            _mockCustomerRepository.Setup(x => x.CreateCustomerAsync(It.IsAny<List<Customer>>())).ReturnsAsync(customers);

            _mockBookingCustomerRepository.Setup(x => x.AddCustomersToBookingHotel(It.IsAny<List<BookingCustomer>>())).ReturnsAsync(bookingCustomers);

            _mockEmailSenderRepository.Setup(x => x.SendEmail(It.IsAny<string>(), It.IsAny<string>())).Verifiable();

            var response  = _bookingService.CreateBookingAsync(bookingDto);

            Assert.Equal("Booking Created, An email was sent with the reservation confirmation ", response.Result.Message);
        }

    }
}
