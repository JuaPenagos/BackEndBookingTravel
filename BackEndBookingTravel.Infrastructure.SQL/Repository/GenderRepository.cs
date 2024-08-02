using BackEndBookingTravel.Domain.Entities;
using BackEndBookingTravel.Domain.Repository;
using BackEndBookingTravel.Infrastructure.SQL.Context;
using BackEndBookingTravel.Infrastructure.SQL.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBookingTravel.Infrastructure.SQL.Repository
{
    public class GenderRepository : BaseRepository<Gender>, IGenderRepository
    {
        public GenderRepository(DataContext context) : base(context)
        {
        }

        public async Task<List<Gender>> GetAllGendersAsync()
        {
            var genders = await GetAsync();
            return genders.ToList();
        }

        public async Task<Gender?> CreateGenderAsync(Gender gender)
        {
            var genderDB = await AddAsync(gender);
            return genderDB;
        }
    }
 }
