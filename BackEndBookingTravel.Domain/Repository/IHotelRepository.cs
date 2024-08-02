using BackEndBookingTravel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBookingTravel.Domain.Repository
{
    public interface IHotelRepository
    {
        Task<List<Hotel>> GetAllHotelsAsync();

        Task<Hotel?> CreateHotelAsync(Hotel hotel);

        Task DisableHotelAsync(Hotel hotel);

        Task<Hotel?> GetHotelById(int id);

        Task UpdateHotelAsync(Hotel hotel);
    }
}
