using BackEndBookingTravel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBookingTravel.Utility
{
    public interface IUtilityJWT
    {
        string GenerateJWTToken(User model);

        bool ValidarToken(string token);
    }
}
