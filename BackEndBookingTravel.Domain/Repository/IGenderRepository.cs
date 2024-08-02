using BackEndBookingTravel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBookingTravel.Domain.Repository
{
    public interface IGenderRepository
    {
        Task<List<Gender>> GetAllGendersAsync();

        Task<Gender?> CreateGenderAsync(Gender gender);
    }
}
