using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBookingTravel.Utility
{
    public class Encrypt
    {
        public string encriptSHA256(string text)
        {
            using (SHA256 sHA256Hash = SHA256.Create())
            {
                byte[] bytes = sHA256Hash.ComputeHash(Encoding.UTF8.GetBytes(text));

                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
