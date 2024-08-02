using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBookingTravel.Utility.Helpers
{
    public class GenericException : Exception
    {
        public GenericException(string message) : base(message)
        {
        }
    }
}
