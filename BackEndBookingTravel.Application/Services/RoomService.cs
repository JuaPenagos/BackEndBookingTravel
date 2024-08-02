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

namespace BackEndBookingTravel.Application.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly ILog _logger;
        public RoomService(IRoomRepository roomRepository, ILog logger)
        {
            _roomRepository = roomRepository;
            _logger = logger;
        }

        public async Task<ApiResponse<List<RoomResponseDto>>> GetAllAvailableRoomsAsync()
        {
            var rooms = await _roomRepository.GetAllAvailableRoomsAsync();

            if (rooms.Any())
            {
                var response = rooms.Select(x => new RoomResponseDto()
                {

                    Name = x.Name,
                    Location = x.Location,
                    RoomType = x.RoomType.Description,
                    BasePrice = x.BasePrice,
                    Tax = x.Tax
                }).ToList();
                return new ApiResponse<List<RoomResponseDto>> { Success = true, Message = "Rooms Availables", Data = response };

            }
            else {

                return new ApiResponse<List<RoomResponseDto>> { Success = true, Message = "Data no Found" };
            }

        }

        public async Task<ApiResponse<string>> CreateRoomAsync(RoomDto roomDto)
        {
            Room room = new Room()
            {
                IdRoomType = roomDto.IdRoomType,
                Name = roomDto.Name,
                BasePrice = roomDto.BasePrice,
                Tax = roomDto.Tax,
                Location = roomDto.Location,
                IsActive = true,
            };

            var response = await _roomRepository.CreateRoomAsync(room);

            if (response != null)
            {
                return new ApiResponse<string> { Success = true, Message = "Room Created" };
            }
            else 
            {
                return new ApiResponse<string> { Success = true, Message = "Room was not created" };
            }

            
        }

        public async Task ChangeStatusRoomAsync(int idRoom)
        {

            var room = await _roomRepository.GetRoomById(idRoom);
            room.IsActive = room.IsActive == true ? false : true;
            await _roomRepository.DisableRoomAsync(room);
        }

        public async Task<ApiResponse<List<RoomResponseDto>>> GetAllRoomsAsync()
        {
            var rooms = await _roomRepository.GetAllRoomsAsync();

            if (rooms.Any())
            {
                var response = rooms.Select(x => new RoomResponseDto()
                {

                    Name = x.Name,
                    Location = x.Location,
                    RoomType = x.RoomType.Description,
                    BasePrice = x.BasePrice,
                    Tax = x.Tax
                }).ToList();
                return new ApiResponse<List<RoomResponseDto>> { Success = true, Message = "Rooms", Data = response };

            }
            else
            {

                return new ApiResponse<List<RoomResponseDto>> { Success = true, Message = "Data no Found" };
            }
        }

        public async Task<ApiResponse<string>> UpdateRoomAsync(RoomDto roomDto)
        {
            Room room = new Room()
            {
                Id = roomDto.Id,
                IdRoomType = roomDto.IdRoomType,
                Name = roomDto.Name,
                BasePrice = roomDto.BasePrice,
                Tax = roomDto.Tax,
                Location = roomDto.Location,
                IsActive = true,
            };
            try
            {
                await _roomRepository.UpdateRoomAsync(room);
                return new ApiResponse<string> { Success = true, Message = "Room Updated" };
            }
            catch (Exception ex)
            {
                _logger.Error($"Update Room Error: {ex.Message}");
                throw ex;
            }

        }
    }
}