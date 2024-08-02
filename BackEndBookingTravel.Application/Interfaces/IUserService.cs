using BackEndBookingTravel.Application.Dtos;
using BackEndBookingTravel.Domain.Entities;
using BackEndBookingTravel.Utility.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBookingTravel.Application.Interfaces
{
    public interface IUserService
    {
        Task<ApiResponse<string>> CreateUser(UserDto user);

        Task<ApiResponse<string>> LoginAsync(string user, string password);
    }
}
