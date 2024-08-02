using BackEndBookingTravel.Domain.Entities;
using BackEndBookingTravel.Domain.Repository;
using BackEndBookingTravel.Infrastructure.SQL.Context;
using BackEndBookingTravel.Infrastructure.SQL.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBookingTravel.Infrastructure.SQL.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
            
        }

        public async Task<User?> CreateUserAsync(User user)
        {
            var userDB = await AddAsync(user);
            return userDB;
        }

        public async Task<User?> LoginAsync(String user, String password)
        {
            var userDB = await _dbSet.Where(x => x.UserName == user && x.Password == password).FirstOrDefaultAsync();
            return userDB;
        }
    }
}
