using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            SteamClientAPI.SteamClientAPI.Profile profile = new SteamClientAPI.SteamClientAPI.Profile();
            Console.WriteLine("Баланс: " + profile.Balance);
            Console.ReadKey();
        }
    }
}
