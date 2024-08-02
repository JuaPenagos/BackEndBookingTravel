using BackEndBookingTravel.Application.Dtos;
using BackEndBookingTravel.Application.Interfaces;
using BackEndBookingTravel.Domain.Entities;
using BackEndBookingTravel.Domain.Repository;
using BackEndBookingTravel.Utility;
using BackEndBookingTravel.Utility.Helpers;
using log4net;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBookingTravel.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILog _logger;
        private readonly IUtilityJWT _utilityJWT;
        private readonly Encrypt _encrypt;

        public UserService(IUserRepository userRepository, ILog logger, IUtilityJWT utilityJWT)
        {
            _userRepository = userRepository;
            _logger = logger;
            _utilityJWT = utilityJWT;
            _encrypt = new Encrypt(); 

        }
        public async Task<ApiResponse<string>> CreateUser(UserDto user)
        {
            User employeeEntity = new User
            {
                Name = user.Name,
                LastName = user.LastName,
                UserName = user.UserName,
                Password = _encrypt.encriptSHA256(user.Password),
            };

            var response = await _userRepository.CreateUserAsync(employeeEntity);
            return ValidateResponse(response);
        }

        private static ApiResponse<string> ValidateResponse(User? response)
        {
            if (response != null)
            {
                return new ApiResponse<string> { Success = true, Message = "User Created", Data = response.Name };

            }
            else
            {
                throw new GenericException("User was not created");
            }
        }

        public async Task<ApiResponse<string>> LoginAsync(string user, string password)
        {
            var employee = await _userRepository.LoginAsync(user, _encrypt.encriptSHA256(password));
            if (employee != null)
            {
                return new ApiResponse<string> { Success = true, Message = "Login", Data = _utilityJWT.GenerateJWTToken(employee) };
            }
            else
            {
                return new ApiResponse<string> { Success = false, Message = "Error Login", Data = "" };
            }

        }
    }
}
