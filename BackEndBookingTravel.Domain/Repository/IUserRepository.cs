using BackEndBookingTravel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBookingTravel.Domain.Repository
{
    public interface IUserRepository
    {
        Task<User?> CreateUserAsync(User user);

        Task<User?> LoginAsync(String user, String password);
    }
}
