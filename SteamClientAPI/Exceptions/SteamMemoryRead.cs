using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamClientAPI.Exceptions
{
    public class SteamMemoryRead : System.Exception
    {
        public string SteamExeption { get; set; }

        public SteamMemoryRead(string inputExceptionType)
        {
            SteamExeption = inputExceptionType;
        }
    }
}
