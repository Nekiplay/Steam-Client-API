using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamClientAPI.Exceptions
{
    public class Steam : System.Exception
    {
        public string SteamExeption { get; set; }

        public Steam(string inputExceptionType)
        {
            SteamExeption = inputExceptionType;
        }
    }
}
