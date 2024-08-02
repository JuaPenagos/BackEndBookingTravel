using BackEndBookingTravel.Application.Dtos;
using BackEndBookingTravel.Application.Interfaces;
using BackEndBookingTravel.Domain.Entities;
using BackEndBookingTravel.Domain.Repository;
using BackEndBookingTravel.Utility.Helpers;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BackEndBookingTravel.Application.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly ILog _logger;
        private readonly IHotelRoomRepository _hotelRoomRepository;
        public HotelService(IHotelRepository hotelRepository, ILog logger, IHotelRoomRepository hotelRoomRepository)
        {
            _hotelRepository = hotelRepository;
            _logger = logger;
            _hotelRoomRepository = hotelRoomRepository;
        }

        public async Task<ApiResponse<List<HotelresponseDto>>> GetAllHotelsAsync()
        {
            var response = await _hotelRepository.GetAllHotelsAsync();

            if (response.Any())
            {
                var hotelDetail = response.Select(x => new HotelresponseDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Rooms = x.Rooms.Select(y => new RoomResponseDto() { BasePrice = y.BasePrice, Location = y.Location, Name = y.Name, Tax = y.Tax }).ToList()

                }).ToList();
                return new ApiResponse<List<HotelresponseDto>> { Success = true, Message = "Hotels", Data = hotelDetail };
            }
            else {
                return new ApiResponse<List<HotelresponseDto>> { Success = true, Message = "Data not Found" };
            }

        }

        public async Task<Hotel> CreateHotelAsync(HotelDto hotelDto)
        {
            Hotel hotel = new Hotel()
            {
                Name = hotelDto.Name,
                IsActive = true,
                CreateUser = 1
            };

            return await _hotelRepository.CreateHotelAsync(hotel);
        }

        public async Task<ApiResponse<string>> AddRoomsToHotelAsync(HotelRoomDto hotelRoomDto)
        {
            var hotelroom = hotelRoomDto.IdRooms.Select(x => new HotelRoom() { IdRoom = x, IdHotel = hotelRoomDto.IdHotel }).ToList();

            try
            {
                await _hotelRoomRepository.AddRoomToHotel(hotelroom);
                return new ApiResponse<string> { Success = true, Message = "Rooms Added" };
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<ApiResponse<string>> ChangeStatusHotelAsync(int idHotel)
        {
            var hotel = await _hotelRepository.GetHotelById(idHotel);
            hotel.IsActive = hotel.IsActive == true ? false : true;

            try
            {
                await _hotelRepository.DisableHotelAsync(hotel);
                return new ApiResponse<string> { Success = true, Message = "Statud Changed" };
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<ApiResponse<string>> UpdateHotelAsync(HotelDto hotelDto)
        {
            Hotel hotel = new Hotel()
            {
                Id = hotelDto.Id,
                Name = hotelDto.Name,
                IsActive = true,
                CreateUser = 1
            };
            try
            {
                await _hotelRepository.UpdateHotelAsync(hotel);
                return new ApiResponse<string> { Success = true, Message = "Hotel Updated" };
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
