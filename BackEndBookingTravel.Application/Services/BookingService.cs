using BackEndBookingTravel.Application.Dtos;
using BackEndBookingTravel.Application.Interfaces;
using BackEndBookingTravel.Domain.Entities;
using BackEndBookingTravel.Domain.Repository;
using BackEndBookingTravel.Infrastructure.Mail;
using BackEndBookingTravel.Utility.Helpers;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBookingTravel.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly ILog _logger;
        private readonly IBookingCustomerRepository _bookingCustomerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IHotelRoomRepository _hotelRoomRepository;
        private readonly IEmailSender _emailSender;
        public BookingService(IBookingRepository bookingRepository, ILog logger, IBookingCustomerRepository bookingCustomerRepository,
            ICustomerRepository customerRepository , IHotelRoomRepository hotelRoomRepository, IEmailSender emailSender)
        {
            _bookingRepository = bookingRepository;
            _logger = logger;
            _bookingCustomerRepository = bookingCustomerRepository;
            _customerRepository = customerRepository;
            _hotelRoomRepository = hotelRoomRepository;
            _emailSender = emailSender;
        }

        public async Task<ApiResponse<BookingResponseDto>> CreateBookingAsync(BookingDto bookingDto)
        {
            Booking booking = new Booking()
            {
                EmergencyContactName = bookingDto.EmergencyContactName,
                EmergencyPhoneNumber = bookingDto.EmergencyPhoneNumber,
                StartDate = bookingDto.StartDate,
                EndDate = bookingDto.EndDate,
                IdRoom = bookingDto.IdRoom
            };

            var bookingDB = await _bookingRepository.CreateBookingAsync(booking);

            List<Customer?> customersDB = await AddCustomers(bookingDto);
            var customerBooking = customersDB.Select(x => new BookingCustomer()
            {
                IdBooking = bookingDB.Id,
                IdCustomer = x!.Id
            }).ToList();

            var response = await _bookingCustomerRepository.AddCustomersToBookingHotel(customerBooking);

            _emailSender.SendEmail(bookingDto.Customers.FirstOrDefault().Email, bookingDto.Customers.FirstOrDefault().FullName);

            if (bookingDB != null && response != null)
            {
                return new ApiResponse<BookingResponseDto> { Success = true, Message = "Booking Created, An email was sent with the reservation confirmation " };
            }
            else
            {
                return new ApiResponse<BookingResponseDto> { Success = true, Message = "Booking was not Created" };
            }
        }

        private async Task<List<Customer?>> AddCustomers(BookingDto bookingDto)
        {
            var customers = bookingDto.Customers.Select(x => new Customer()
            {
                FullName = x.FullName,
                BirthDate = x.BirthDate,
                DocumentNumber = x.DocumentNumber,
                IdDocumentType = x.IdDocumentType,
                IdGender = x.IdGender,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email
            }).ToList();

            var customersDB = await _customerRepository.CreateCustomerAsync(customers);
            return customersDB;
        }

        public async Task<ApiResponse<List<BookingResponseDto>>> GetBookingByHotelList(int idHotel)
        {
            var roomsIds = await _hotelRoomRepository.GetRoomsByHotelId(idHotel);

            var bookingDB = await _bookingRepository.GetAllBookingsByRoomsIdsAsync(roomsIds.Select(x => x.IdRoom).ToList());

            return BuildBookingResponse(bookingDB);
        }

        private static ApiResponse<List<BookingResponseDto>> BuildBookingResponse(List<Booking> bookingDB)
        {
           
            if (bookingDB.Any())
            {
                var response = bookingDB.Select(x => new BookingResponseDto()
                {
                    EmergencyContactName = x.EmergencyContactName,
                    RoomName = x.Room.Name,
                    EmergencyPhoneNumber = x.EmergencyPhoneNumber,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate
                }).ToList();
                return new ApiResponse<List<BookingResponseDto>> { Success = true, Message = "Booking List", Data = response };
            }
            else
            {
                return new ApiResponse<List<BookingResponseDto>> { Success = true, Message = "Data no Found" };
            }
        }

        public async Task<ApiResponse<BookingResponseDto>> GetBookingById(int idBooking)
        {
            var bookingDetail = await _bookingRepository.GetBookingById(idBooking);

            if (bookingDetail != null)
            {
                var response = new BookingResponseDto()
                {
                    EmergencyContactName = bookingDetail.EmergencyContactName,
                    RoomName = bookingDetail.Room.Name,
                    EmergencyPhoneNumber = bookingDetail.EmergencyPhoneNumber,
                    StartDate = bookingDetail.StartDate,
                    EndDate = bookingDetail.EndDate,
                    Customers = bookingDetail.Customers.Select(x => new CustomerResponseDto() { 
                        FullName = x.FullName,
                        PhoneNumber = x.PhoneNumber,
                        BirthDate = x.BirthDate,
                        DocumentNumber = x.DocumentNumber,
                        Email = x.Email
                    }).ToList()
                };
                return new ApiResponse<BookingResponseDto> { Success = true, Message = "Booking Detail", Data = response };
            }
            else
            {
                return new ApiResponse<BookingResponseDto> { Success = true, Message = "Data no Found" };
            }
        }
    }
}
